using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(=|/)(?<name>[A-Z][a-zA-z]{2,})\1";
            string text = Console.ReadLine();
            List<string> destinationList = new List<string>();
            MatchCollection matchcollection = Regex.Matches(text, pattern);
            int points = 0;
            foreach (Match match in matchcollection)
            {
                string current = match.Groups["name"].Value;
                destinationList.Add(current);
                points += int.Parse(current.Length.ToString());
            }
            Console.WriteLine($"Destinations: {string.Join(", ",destinationList)}");
            Console.WriteLine($"Travel Points: {points}");

        }
    }
}
