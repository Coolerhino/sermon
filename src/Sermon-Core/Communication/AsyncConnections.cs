using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Sermon_Core.Protocol;

namespace Sermon_Core.Communication
{
    public class AsyncConnections
    {
        private byte[] _buffer = new byte[2048];
        private List<Socket> _clientSockets = new List<Socket>();
        private Socket _serverSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);

        public void Setup()
        {
            Console.WriteLine("Launching server...");
            _serverSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4425));
            _serverSocket.Listen(5);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            var socket = _serverSocket.EndAccept(ar);
            _clientSockets.Add(socket);
            Console.WriteLine("Client connected");
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            var socket = (Socket) ar.AsyncState;
            int received = socket.EndReceive(ar);
            byte[] tempBuf = new byte[received];
            Array.Copy(_buffer, tempBuf, received);
            string messageReceived = Encoding.UTF8.GetString(tempBuf);
            Console.WriteLine("Received:" + messageReceived);

            byte[] data = Encoding.UTF8.GetBytes(new Process().Request(messageReceived));
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
        }

        private void SendCallback(IAsyncResult ar)
        {
            var socket = (Socket) ar.AsyncState;
            socket.EndSend(ar);
        }
    }
}