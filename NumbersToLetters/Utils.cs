using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;

namespace NumbersToLetters
{
    class Utils
    {
        public static void WriteOptions()
        {
            Console.Clear();
            DrawOption("1", "Convert text to numbers");
            DrawOption("2", "Convert numbers to letters");
            DrawOption("3", "Quit");
        }

        private static void DrawOption(string prefix, string message)
        {
            Console.Write("[");
            Console.Write(prefix, Color.BlueViolet);
            Console.WriteLine($"] {message}");
        }

        public static void WriteMessage(string message, Color color)
        {
            Console.WriteLine(message, color);
        }
    }
}
