using System;
using System.Drawing;
using Colorful;
using Console = Colorful.Console;

namespace Sermon_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //var server = new Server("127.0.0.1", 4425);
            //server.Send("EHLO WERLD");
            //var resp = server.Receive();
            var font = FigletFont.Load("E:/Repos/sermon/src/Sermon-Client/res/isometric4.flf");
            var figlet = new Figlet(font);
            WriteSermonWord();
            //Console.Write(figlet.ToAscii("Ser"), Color.Yellow);
            //Console.Write(figlet.ToAscii("mon"), Color.White);
            //Console.WriteLine(resp);
            Console.Read();
        }

        public static void WriteSermonWord()
        {
            Console.Write("      ___           ___           ___	  ", Color.Yellow);
            Console.WriteLine("     ___           ___           ___", Color.White);

            Console.Write(@"     /  /\         /  /\         /  /\	  ", Color.Yellow);
            Console.WriteLine(@"    /  /\         /  /\         /  /\", Color.White);

            Console.Write(@"    /  /::\       /  /::\       /  /::\   ", Color.Yellow);
            Console.WriteLine(@"   /  /::|       /  /::\       /  /::|", Color.White);

            Console.Write(@"   /__/:/\:\     /  /:/\:\     /  /:/\:\  ", Color.Yellow);
            Console.WriteLine(@"  /  /:|:|      /  /:/\:\     /  /:|:|", Color.White);

            Console.Write(@"  _\_ \:\ \:\   /  /::\ \:\   /  /::\ \:\ ", Color.Yellow);
            Console.WriteLine(@" /  /:/|:|__   /  /:/  \:\   /  /:/|:|__", Color.White);

            Console.Write(@" /__/\ \:\ \:\ /__/:/\:\ \:\ /__/:/\:\_\:\", Color.Yellow);
            Console.WriteLine(@"/__/:/_|::::\ /__/:/ \__\:\ /__/:/ |:| /\", Color.White);

            Console.Write(@" \  \:\ \:\_\/ \  \:\ \:\_\/ \__\/~|::\/:/", Color.Yellow);
            Console.WriteLine(@"\__\/  /~~/:/ \  \:\ /  /:/ \__\/  |:|/:/", Color.White);

            Console.Write(@"  \  \:\_\:\    \  \:\ \:\      |  |:|::/ ", Color.Yellow);
            Console.WriteLine(@"      /  /:/   \  \:\  /:/      |  |:/:/", Color.White);

            Console.Write(@"   \  \:\/:/     \  \:\_\/      |  |:|\/  ", Color.Yellow);
            Console.WriteLine(@"     /  /:/     \  \:\/:/       |__|::/", Color.White);

            Console.Write(@"    \  \::/       \  \:\        |__|:|~   ", Color.Yellow);
            Console.WriteLine(@"    /__/:/       \  \::/        /__/:/", Color.White);

            Console.Write(@"     \__\/         \__\/         \__\|    ", Color.Yellow);
            Console.WriteLine(@"    \__\/         \__\/         \__\/", Color.White);
        }
    }
}
