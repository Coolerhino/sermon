using System;
using Sermon_Core.Communication;

namespace Sermon_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var connections = new Connections(4425);
            connections.Handle().Wait();
            
        }
    }
}