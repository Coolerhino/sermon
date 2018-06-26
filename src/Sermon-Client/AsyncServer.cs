using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sermon_Client
{
    public class AsyncServer
    {
        private Socket _clientSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);

        public void Connect()
        {
            var address = IPAddress.Parse("127.0.0.1");
            int attempts = 0;
            while (!_clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    _clientSocket.Connect(address, 4425);
                }
                catch (SocketException e)
                {
                    Console.WriteLine($"{e.Message}, attempts: {attempts}");
                }
            }
        }

        public string GetSermon(string request)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(request);
            _clientSocket.Send(buffer);
            var response = GetResponse();
            return response;
        }

        private string GetResponse()
        {
            string result = "";
            byte[] receivedBuffer = new byte[2048];
            int received = _clientSocket.Receive(receivedBuffer);
            byte[] sermonFragment = new byte[received];
            Array.Copy(receivedBuffer, sermonFragment, received);
            result += Encoding.UTF8.GetString(sermonFragment);
            return result;
        }
    }
}