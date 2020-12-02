using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day1Task1
    {
        public static string Execute(string input)
        {
            var year = 2020;
            var numbers = input.Split("\n").Select(s => int.Parse(s));
            return numbers.Where(x => numbers.Any(y => x + y == year)).Select(x => x * (year - x)).First().ToString();
        }
    }
}
