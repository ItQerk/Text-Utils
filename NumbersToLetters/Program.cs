using NumbersToLetters;
using System.Drawing;

namespace NumberToLetterConverter
{
    class Program
    {
        static readonly Dictionary<int, char> numberToLetterMap = new()
            {
                { 1, 'a' },
                { 2, 'ą' },
                { 3, 'b' },
                { 4, 'c' },
                { 5, 'ć' },
                { 6, 'd' },
                { 7, 'e' },
                { 8, 'ę' },
                { 9, 'f' },
                { 10, 'g' },
                { 11, 'h' },
                { 12, 'i' },
                { 13, 'j' },
                { 14, 'k' },
                { 15, 'l' },
                { 16, 'ł' },
                { 17, 'm' },
                { 18, 'n' },
                { 19, 'ń' },
                { 20, 'o' },
                { 21, 'ó' },
                { 22, 'p' },
                { 23, 'q' },
                { 24, 'r' },
                { 25, 's' },
                { 26, 'ś' },
                { 27, 't' },
                { 28, 'u' },
                { 29, 'v' },
                { 30, 'w' },
                { 31, 'x' },
                { 32, 'y' },
                { 33, 'z' },
                { 34, 'ź' },
            { 35, 'ż' }
        };

        static readonly Dictionary<string, int> letterToNumberMap = new()
            {
                {"a", 1},
                {"ą", 2},
                {"b", 3},
                {"c", 4},
                {"ć", 5},
                {"d", 6},
                {"e", 7},
                {"ę", 8},
                {"f", 9},
                {"g", 10},
                {"h", 11},
                {"i", 12},
                {"j", 13},
                {"k", 14},
                {"l", 15},
                {"ł", 16},
                {"m", 17},
                {"n", 18},
                {"ń", 19},
                {"o", 20},
                {"ó", 21},
                {"p", 22},
                {"q", 23},
                {"r", 24},
                {"s", 25},
                {"ś", 26},
                {"t", 27},
                {"u", 28},
                {"v", 29},
                {"w", 30},
                {"x", 31},
                {"y", 32},
                {"z", 33},
                {"ź", 34},
                {"ż", 35}
            };
        static void Main(string[] args)
        {
            Utils.WriteOptions();
            SelectOption(args);
        }

        private static void SelectOption(string[] args)
        {
            string option = Console.ReadLine();
            if (option == null || option.Length == 0) 
            {
                Console.Clear();
                Utils.WriteMessage("You have chosen the incorrect option", Color.Red);
                Console.ReadLine();
                Main(args);
            }

            if(option == "1")
            {
                Console.Clear();
                Utils.WriteMessage("Enter text to convert", Color.Red);
                string text = Console.ReadLine();
                if(text == string.Empty)
                {
                    Utils.WriteMessage("The text must not be empty!", Color.Red);
                    Console.ReadLine();
                    Main(args);
                }
                Utils.WriteMessage(LetterstToNumbers(text), Color.Gold);
                Console.ReadLine();
                Main(args);
            }
            else if(option == "2")
            {
                Console.Clear();
                Utils.WriteMessage("Enter text to convert", Color.Red);
                string text = Console.ReadLine();
                if (text == string.Empty)
                {
                    Utils.WriteMessage("The text must not be empty!", Color.Red);
                    Console.ReadLine();
                    Main(args);
                }
                Utils.WriteMessage(NumbersToLetters(text), Color.Gold);
                Console.ReadLine();
                Main(args);
            }else if(option == "3")
            {
                Environment.Exit(-1);
            }
            else
            {
                Console.Clear();
                Utils.WriteMessage("You have chosen the incorrect option", Color.Red);
                Console.ReadLine();
                Main(args);
            }



        }

        public static string NumbersToLetters(string textToConvert)
        {
            string output = "";

            string[] sentences = textToConvert.Split(',');

            foreach (string sentence in sentences)
            {
                string[] words = sentence.Split(' ');

                foreach (string word in words)
                {
                    string[] letters = word.Split('.');

                    foreach (string letter in letters)
                    {
                        int number;
                        char convertedLetter;
                        if (int.TryParse(letter, out number))
                        {
                            convertedLetter = (numberToLetterMap.ContainsKey(number) ? numberToLetterMap[number] : letter[0]);
                        }
                        else
                        {
                            convertedLetter = letter[0];
                        }

                        

                        output += convertedLetter;
                    }

                    if (output.Length > 0)
                        output += " ";
                }

                if (output.Length > 0)
                    output += "\n";
            }
            return output;
        }

        public static string LetterstToNumbers(string textToConvert)
        {
            string output = "";

            string[] sentences = textToConvert.Split(',');
            foreach (string sentence in sentences)
            {
                string[] words = sentence.Split(' ');

                foreach (string word in words)
                {
                    char[] tablicaZnakow = word.ToCharArray();

                    string[] tablicaStringow = Array.ConvertAll(tablicaZnakow, c => c.ToString());

                    foreach (var letter in tablicaStringow)
                    {
                        if (output.Length > 0 && !output.EndsWith(" "))
                            output += $".{(letterToNumberMap.ContainsKey(letter.ToLower()) ?letterToNumberMap[letter.ToLower()]: letter)}";
                        else
                            output += (letterToNumberMap.ContainsKey(letter.ToLower()) ? letterToNumberMap[letter.ToLower()] : letter);
                    }
                    output += " ";

                }
                if (output.Length > 0)
                    output += "\n";
            }

            return output;
        }
    }
}