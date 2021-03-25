using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex patten = new Regex(@"\b([A-Z][a-z]+) ([A-Z][a-z]+)");

            MatchCollection match = patten.Matches(text);

            foreach (Match name in match)
            {
                Console.Write(name.Value+" ");
            }
        }
    }
}