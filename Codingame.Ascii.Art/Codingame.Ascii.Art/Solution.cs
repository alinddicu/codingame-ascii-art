namespace Codingame.Ascii.Art
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;

    /**
     * Auto-generated code below aims at helping you parse
     * the standard input according to the problem statement.
     **/
    public class Solution
    {
        private static readonly string[] Caracters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?".Select(c => c.ToString()).ToArray();
        private static readonly string QuestionMark = Caracters.Last();

        static void Main(string[] args)
        {
            int L = int.Parse(Console.ReadLine());
            int H = int.Parse(Console.ReadLine());
            string T = Console.ReadLine();
            var ROWS = new string[H];
            for (int i = 0; i < H; i++)
            {
                ROWS[i] = Console.ReadLine();
            }

            var result = new AsciiArtParser().Execute(L, H, T, ROWS);

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine(result);
        }

        public class AsciiArtParser
        {
            public string Execute(int width, int height, string text, string[] asciiArtAlphabet)
            {
                var asciiAlphabet = AsciiAlphabet.Init(width, height, text, asciiArtAlphabet);

                var textOfAsciiCaracters = new List<CaracterAsciiArt>();
                foreach (var caracter in text)
                {
                    textOfAsciiCaracters.Add(asciiAlphabet.Translate(caracter.ToString()));
                }

                var output = string.Empty;
                for (int heightIndex = 0; heightIndex < height; heightIndex++)
                {
                    foreach (var textOfAsciiCaracter in textOfAsciiCaracters)
                    {
                        output += textOfAsciiCaracter.GetLine(heightIndex);
                    }

                    output += Environment.NewLine;
                }

                return output;
            }
        }

        public class AsciiAlphabet
        {
            private readonly IEnumerable<CaracterAsciiArt> _caractersAsciis;

            public AsciiAlphabet(IEnumerable<CaracterAsciiArt> caractersAsciis)
            {
                _caractersAsciis = caractersAsciis;
            }

            public CaracterAsciiArt Translate(string caracter)
            {
                return _caractersAsciis.FirstOrDefault(ca => ca.Is(caracter));
            }

            public static AsciiAlphabet Init(int width, int height, string text, string[] asciiArtAlphabet)
            {
                var caractersAsciis = new List<CaracterAsciiArt>();
                var rowIndex = 0;
                for (var caracterIndex = 0; caracterIndex < Caracters.Length; caracterIndex++)
                {
                    var caracter = Caracters[caracterIndex];
                    var lines = new List<string>();
                    for (var heightIndex = 0; heightIndex < height; heightIndex++)
                    {
                        var line = asciiArtAlphabet[heightIndex].Substring(rowIndex, width);
                        lines.Add(line);
                    }

                    caractersAsciis.Add(new CaracterAsciiArt(caracter, lines.ToArray()));
                    lines.Clear();
                    rowIndex += width;
                }

                return new AsciiAlphabet(caractersAsciis);
            }
        }

        public class CaracterAsciiArt
        {
            private readonly string _caracter;
            private readonly string[] _caracterLines;

            public CaracterAsciiArt(string caracter, string[] caracterLines)
            {
                _caracter = caracter;
                _caracterLines = caracterLines;
            }

            public bool Is(string caracter)
            {
                return string.Equals(_caracter, caracter, StringComparison.OrdinalIgnoreCase);
            }

            public string GetLine(int height)
            {
                return _caracterLines[height];
            }
        }
    }
}