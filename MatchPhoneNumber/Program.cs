using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"\+359([ -])2\1\d{3}\1\d{4}\b";
            string phones = Console.ReadLine();
            var phoneMatches = Regex.Matches(phones,regex);

            string[] matchedPhones = phoneMatches
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ",matchedPhones)); ;
        }
    }
}