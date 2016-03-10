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

            var result = new AsciiArtConverter().Execute(L, H, T, ROWS);

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine(result);
        }

        public class AsciiArtConverter
        {
            public string Execute(int width, int height, string text, string[] asciiArtAlphabet)
            {
                var asciiAlphabet = AsciiArtAlphabet.Init(width, height, text, asciiArtAlphabet);

                var textOfAsciiCaracters = new List<AsciiArtCaracter>();
                foreach (var caracter in text)
                {
                    textOfAsciiCaracters.Add(asciiAlphabet.Translate(caracter.ToString()));
                }

                var output = string.Empty;
                for (int heightIndex = 0; heightIndex < height; heightIndex++)
                {
                    foreach (var textOfAsciiCaracter in textOfAsciiCaracters)
                    {
                        output += textOfAsciiCaracter.GetAsciiArtLine(heightIndex);
                    }

                    output += Environment.NewLine;
                }

                return output;
            }
        }

        private class AsciiArtAlphabet
        {
            private readonly IEnumerable<AsciiArtCaracter> _caractersAsciis;
            private readonly AsciiArtCaracter _questionMarkAsciiArt;

            protected AsciiArtAlphabet(IEnumerable<AsciiArtCaracter> caractersAsciis)
            {
                _caractersAsciis = caractersAsciis;
                _questionMarkAsciiArt = Translate(QuestionMark);
            }

            public AsciiArtCaracter Translate(string caracter)
            {
                var translation = _caractersAsciis.FirstOrDefault(ca => ca.Is(caracter));
                if (translation != null)
                {
                    return translation;
                }

                return _questionMarkAsciiArt;
            }

            public static AsciiArtAlphabet Init(int asciiArtCharWidth, int asciiArtCharHeight, string textToConvert, string[] asciiArtInlineAlphabet)
            {
                var caractersAsciis = new List<AsciiArtCaracter>();
                var rowIndex = 0;
                for (var caracterIndex = 0; caracterIndex < Caracters.Length; caracterIndex++)
                {
                    var caracter = Caracters[caracterIndex];
                    var lines = new List<string>();
                    for (var heightIndex = 0; heightIndex < asciiArtCharHeight; heightIndex++)
                    {
                        var line = asciiArtInlineAlphabet[heightIndex].Substring(rowIndex, asciiArtCharWidth);
                        lines.Add(line);
                    }

                    caractersAsciis.Add(new AsciiArtCaracter(caracter, lines.ToArray()));
                    lines.Clear();
                    rowIndex += asciiArtCharWidth;
                }

                return new AsciiArtAlphabet(caractersAsciis);
            }
        }

        private class AsciiArtCaracter
        {
            private readonly string _caracter;
            private readonly string[] _asciiArtLines;

            public AsciiArtCaracter(string caracter, string[] asciiArtLines)
            {
                _caracter = caracter;
                _asciiArtLines = asciiArtLines;
            }

            public bool Is(string caracter)
            {
                return string.Equals(_caracter, caracter, StringComparison.OrdinalIgnoreCase);
            }

            public string GetAsciiArtLine(int height)
            {
                return _asciiArtLines[height];
            }
        }
    }
}