using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Sermon_Core.DataAccess;
using Sermon_Core.Model;
using Sermon_Twitter;
using Sermon_Core.Protocol;
using Sermon_Core.StringExtensions;

namespace Sermon_Core.Communication
{
    public class Connections
    {
        private Socket _socket;
        private List<Socket> _clients = new List<Socket>();
        private readonly int BufferSize = 2048;
        public readonly int Port;
        public bool Accepting{get;private set;}
        public Connections(int port)
        {
            Port = port;
            Accepting = false;
            _socket = new Socket(SocketType.Stream, ProtocolType.IP);
            _socket.Bind(
                new IPEndPoint(IPAddress.Parse("127.0.0.1"),Port)
            );
        }
        public void Stop(){
            Accepting = false;
            System.Console.WriteLine("Server shutdown");
        }
        public async Task Handle()
        {
            //var document = new Documents();
            //var keys = document.GetKeys();
            //var api = new TwitterApi(keys);
            //var sentences = api.GiveMeMostRecentTweets("Pontifex_ln");
            //var tweets = new List<TweetInDatabase>();
            //foreach (var sentence in sentences)
            //{
            //    var tweet = new TweetInDatabase() { Text = sentence.CleanTweet() };
            //    tweets.Add(tweet);
            //}
            //document.StoreSermonTweetFragments(tweets, "ln");
            var epis = new Epistula() { Preparatio = 20, Lingua = "ln", Modus = "pontifex" };
            var proc = new Sermon();
            Console.WriteLine(proc.Generate(epis));

            System.Console.WriteLine($"Starting TCP Server on port {Port}");
            Accepting = true;
            _socket.Listen(100);
            //handle new connection
            //check for disconnects
            //check for new requests
            //send back messages
            while (Accepting){
                var acceptTask =  _socket.AcceptAsync();
                foreach (var conn in _clients){
                    ProcessConnectionAsync(conn);
                }
                var client = await acceptTask;
                _clients.Add(client);

            }
            //accept
            //invoke connecteD?
            //receive messages?
        }
        private async void ProcessConnectionAsync(Socket client){
            var buffer = new byte[BufferSize];
            var segment = new ArraySegment<byte> (buffer);
            var length = await client.ReceiveAsync(segment, SocketFlags.None);
            var msg = Encoding.UTF8.GetString(segment.Array, 0, length);
            System.Console.WriteLine("received message:" + msg);
            var response = new Process().Request(msg);
            Array.Clear(buffer, 0, buffer.Length);
            System.Console.WriteLine("Sending response");
            buffer = Encoding.UTF8.GetBytes(response);
            segment = new ArraySegment<byte> (buffer);
            var asd = await client.SendAsync(segment.Slice(0, response.Length), SocketFlags.None);
        }
    }
}