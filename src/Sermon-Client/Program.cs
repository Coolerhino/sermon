using System;

namespace Sermon_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Server("127.0.0.1", 4425);
            server.Send("EHLO WERLD");
            var resp = server.Receive();
            System.Console.WriteLine(resp);
        }
    }
}
