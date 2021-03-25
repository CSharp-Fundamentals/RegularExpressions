using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Regex keyRegex = new Regex(@"[STARstar]");
            Regex regex = new Regex(@"^[^@\-!:>]*@(?<name>[A-Za-z]+)[^@\-!:>]*\:(?<population>\d+)[^@\-:!>]*!(?<type>[AD])![^@\-:!>]*->(?<soulgers>\d+)[^@\-:!>]*$");

            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                int key = keyRegex.Matches(text).Count;

                string decryptedText = DecryptedText(text,key);

                Match match = regex.Match(decryptedText);

                if (!match.Success)
                {
                    continue;
                }

                string name = match.Groups["name"].Value;
                string type = match.Groups["type"].Value;

                if (type=="A")
                {
                    attacked.Add(name);
                }
                else
                {
                    destroyed.Add(name);
                }
            }

            Console.WriteLine($"Attacked planets: {attacked.Count}");
            PrintSortedPlanets(attacked);

            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            PrintSortedPlanets(destroyed);

        }

        private static void PrintSortedPlanets(List<string> planets)
        {
            List<string> sorted = planets
                .OrderBy(x => x)
                .ToList();

            foreach (string planet in sorted)
            {
                Console.WriteLine($"-> {planet}");
            }
        }

        private static string DecryptedText(string text,int key)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char letter in text)
            {
                sb.Append((char)(letter-key));
            }

            return sb.ToString();
        }
    }
}
