using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex regex = new Regex(@"(^|(?<=\s))[A-Aa-z\d]+([-._][A-Za-z\d]+)*@[A-Za-z]+(\-[A-Za-z]+)*(\.[A-Za-z]+)+");

            MatchCollection matches = regex.Matches(text);

            foreach (Match email in matches)
            {
                Console.WriteLine(email.Value);
            }
        }
    }
}
