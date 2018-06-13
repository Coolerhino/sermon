using System.Net;
using System.Net.Sockets;
using System;
using System.Text;

namespace Sermon_Client
{
    //todo pobierz 100 losowych twittow papieza z twittera i z nich uloz 
    // pobieranie z twittera oczywiscie za pomoca socketow i tcp, pobrac z wiresharka 
    //todo zaimplementuj fajny frontend z http://colorfulconsole.com/
    public class Server : IDisposable
    {
        private Socket _socket;
        private byte[] _buffer = new byte[2048];
        private EndPoint _remoteEP;

        public Server(string ip, int port)
        {
            var address = IPAddress.Parse(ip);
            _remoteEP = new IPEndPoint(address, port);
            _socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect(_remoteEP);
        }
        public void Send(string data)
        {
            var raw = Encoding.UTF8.GetBytes(data);
            _socket.Send(raw);
        }
        public string Receive()
        {
            var length = _socket.Receive(_buffer);
            var data = Encoding.UTF8.GetString(_buffer, 0, length);
            return data;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _socket.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}