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
    public class Program
    {
        private static readonly string[] Caracters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?".Select(c => c.ToString()).ToArray();
        private static string QuestionMark = Caracters.Last();

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

            var caractersAsciis = new List<CaracterAscii>();
            for (var caracterIndex = 0; caracterIndex < Caracters.Length; caracterIndex++)
            {
                var caracter = Caracters[caracterIndex];
                List<string> lines = new List<string>();
                for (var rowIndex = 0; rowIndex < Caracters.Length * L; rowIndex += L)
                {
                    for (var heightIndex = 0; heightIndex < H; heightIndex++)
                    {
                        lines.Add(ROWS[heightIndex].Substring(rowIndex + L));
                    }

                    caractersAsciis.Add(new CaracterAscii(caracter, lines.ToArray()));
                    lines.Clear();
                }
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine("answer");
        }

        private class CaracterAscii
        {
            private readonly string _caracter;
            private readonly string[] _caracterLines;

            public CaracterAscii(string caracter, string[] caracterLines)
            {
                _caracter = caracter;
                _caracterLines = caracterLines;
            }
        }
    }
}