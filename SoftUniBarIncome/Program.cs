using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"^[^|$%.]*%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>\d+.?\d*)[^|$%.]*\$$");

            double total = 0;
            while (true)
            {
                string input = Console.ReadLine();

                if (input=="end of shift")
                {
                    break;
                }
                Match match = regex.Match(input); 

                if (!match.Success)
                {
                    continue;
                }

                string customer = match.Groups["customer"].Value;
                string product = match.Groups["product"].Value;
                int quantity = int.Parse(match.Groups["quantity"].Value);
                double price = double.Parse(match.Groups["price"].Value);

                double customerIncome = price * quantity;
                total += customerIncome;

                Console.WriteLine($"{customer}: {product} - {customerIncome:F2}");
            }

            Console.WriteLine($"Total income: {total:F2}");
        }
    }
}
