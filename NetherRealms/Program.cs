using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    public class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] demonsInput = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Regex healthRegex = new Regex(@"[^-\\*\/\d.+]");
            Regex damageRegex = new Regex(@"[+\-]*\d+\.?\d*");
            Regex amplifiersRegex = new Regex(@"[*\/]");

            List<Demon> demons = new List<Demon>();


            foreach (var demon in demonsInput)
            {
                MatchCollection letterMatches = healthRegex.Matches(demon);

                int health = healthRegex.Matches(demon)
                    .Select(m => char.Parse(m.Value))
                    .Sum(x => x);

                MatchCollection damageMatches = damageRegex.Matches(demon);

                double damage = GetDamage(damageMatches);

                MatchCollection amplifiersMatches = amplifiersRegex.Matches(demon);

                foreach (Match match in amplifiersMatches)
                {
                    if (match.Value == "*")
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }
                demons.Add(new Demon{
                        Name = demon,
                        Damage = damage,
                        Health = health

                });
            }
            List<Demon> sorted = demons
                .OrderBy(d=>d.Name)
                .ToList();

            foreach (Demon demon in sorted)
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
            }
        }

        private static double GetDamage(MatchCollection damageMatches)
        {
            double damage = 0;

            foreach (Match match in damageMatches)
            {
                damage += double.Parse(match.Value);
            }

            return damage;
        }
    }
}
