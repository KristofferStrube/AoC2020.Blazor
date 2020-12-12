using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day10Task1
    {
        public static string Execute(string input)
        {
            var lines = input.Replace("\r", "").Split("\n").Select(line => int.Parse(line)).ToList();
            lines.Sort();
            var ones = Enumerable.Range(0, lines.Count() - 1).Count(x => lines[x + 1] - lines[x] == 1)+1;
            var threes = Enumerable.Range(0, lines.Count() - 1).Count(x => lines[x + 1] - lines[x] == 3)+1;
            return (ones * threes).ToString();
        }
    }

}
