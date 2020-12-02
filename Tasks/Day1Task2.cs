using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day1Task2
    {
        public static string Execute(string input)
        {
            var year = 2020;
            var numbers = input.Split("\n").Select(s => int.Parse(s));
            return numbers
                .Where(x => numbers.Any(y => numbers.Any(z => x + y + z == year)))
                .Select(x => new Tuple<int, int>(x, numbers.Where(y => numbers.Any(z => x + y + z == year)).First()))
                .Select(xy => xy.Item1 * xy.Item2 * (year - xy.Item1 - xy.Item2)).First().ToString();
        }
    }
}
