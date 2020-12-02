using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day2Task1
    {
        public static string Execute(string input)
        {
            var lines = input.Split("\n")
                .Select(line =>
                    new Line(
                        Min: int.Parse(line.Split('-')[0]),
                        Max: int.Parse(line.Split(' ')[0].Split('-')[1]),
                        Character: line.Split(':')[0].Last(),
                        Password: line.Split(' ')[2]
                    )
                ).ToList();
            return lines.Count(line => Enumerable.Range(line.Min, line.Max - line.Min + 1).Contains(line.Password.Count(c => c == line.Character))).ToString();
        }

        public record Line(int Min, int Max, char Character, string Password);

    }
}
