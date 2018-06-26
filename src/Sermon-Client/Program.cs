using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Colorful;
using Console = Colorful.Console;
using Sermon_Core.Model;

namespace Sermon_Client
{
    class Program
    {
        static void Main(string[] args)
        {

            WriteSermonWord();
            
            var server = new AsyncServer();
            server.Connect();
            while (true)
            {
                var letter = CollectArguments();
                System.Console.WriteLine(server.GetSermon(letter.ToString()));
                Console.Read();
            }

            //server.Send("DOMINUS VOBISCUM");
            //var resp = server.Receive();
            //System.Console.WriteLine(resp);
            //server.Send(letter.ToString());
            //var rp = server.Receive();
            //System.Console.WriteLine(rp);

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

        public static Epistula CollectArguments()
        {
            var selectedMode = "";
            var finalLength = 0;
            var language = "";

            var modusesLength = 2;
            var moduses = new[] {
                "PONTIFEX",
                "SAPIENTIA" };
            var modusDescriptions = new[]
            {
                "Generate sermon from Pope's twitter",
                "Generate smart theological mumble"
            };
            var selectedModus = new[]
            {
                true,
                false
            };
            var selectedModeIndex = 0;
            ConsoleKeyInfo key;
            while (key.Key != ConsoleKey.Enter)
            {
                Console.Clear();
                WriteSermonWord();
                for (int i = 0; i < modusesLength; i++)
                {
                    System.Console.WriteLine(selectedModus[i] ? $"[■] - {modusDescriptions[i]}" : $"[ ] - {modusDescriptions[i]}");
                }

                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedModeIndex--;
                        if (selectedModeIndex < 0)
                        {
                            selectedModeIndex = modusesLength - 1;
                        }
                        for (int i = 0; i < modusesLength; i++)
                        {
                            if (i == selectedModeIndex)
                            {
                                selectedModus[i] = true;
                            }
                            else
                            {
                                selectedModus[i] = false;
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        selectedModeIndex++;
                        if (selectedModeIndex == modusesLength)
                        {
                            selectedModeIndex = 0;
                        }
                        for (int i = 0; i < modusesLength; i++)
                        {
                            if (i == selectedModeIndex)
                            {
                                selectedModus[i] = true;
                            }
                            else
                            {
                                selectedModus[i] = false;
                            }
                        }
                        break;
                }
            }

            key = new ConsoleKeyInfo();
            if (moduses[selectedModeIndex] == "PONTIFEX")
            {
                var languagesLength = 9;
                var languages = new[] {
                    "EN",
                    "PL",
                    "IT",
                    "ES",
                    "FR",
                    "DE",
                    "PT",
                    "LN",
                    "AR"
                };
                // en, pl, it, es, lt, ar(tu bedzie hardkor), fr, de, pt
                var languagesDescriptions = new[]
                {
                    "English",
                    "Polish",
                    "Italian",
                    "Spanish",
                    "French",
                    "German",
                    "Portugalese",
                    "Latin",
                    "Aramaic"
                };
                var selectedLanguage = new bool[9];
                selectedLanguage[0] = true;
                var selectedLanguageIndex = 0;
                while (key.Key != ConsoleKey.Enter)
                {
                    Console.Clear();
                    WriteSermonWord();
                    for (int i = 0; i < languagesLength; i++)
                    {
                        System.Console.WriteLine(selectedLanguage[i] ? $"[■] - {languagesDescriptions[i]}" : $"[ ] - {languagesDescriptions[i]}");
                    }

                    key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedLanguageIndex--;
                            if (selectedLanguageIndex < 0)
                            {
                                selectedLanguageIndex = languagesLength - 1;
                            }
                            for (int i = 0; i < languagesLength; i++)
                            {
                                if (i == selectedLanguageIndex)
                                {
                                    selectedLanguage[i] = true;
                                }
                                else
                                {
                                    selectedLanguage[i] = false;
                                }
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            selectedLanguageIndex++;
                            if (selectedLanguageIndex == languagesLength)
                            {
                                selectedLanguageIndex = 0;
                            }
                            for (int i = 0; i < languagesLength; i++)
                            {
                                if (i == selectedLanguageIndex)
                                {
                                    selectedLanguage[i] = true;
                                }
                                else
                                {
                                    selectedLanguage[i] = false;
                                }
                            }
                            break;
                    }
                }
                language = languages[selectedLanguageIndex];
            }
            Console.Clear();
            WriteSermonWord();
            System.Console.WriteLine("How long you need your text?");
            var length = Console.ReadLine();
            var lengthSuccess = int.TryParse(length, out finalLength);
            if (!lengthSuccess)
            {
                finalLength = 10;
            }
            selectedMode = moduses[selectedModeIndex];
            Console.Clear();
            WriteSermonWord();
            return new Epistula()
            {
                Modus = selectedMode,
                Preparatio = finalLength,
                Lingua = language
            };
        }
    }
}
