using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day9Task2
    {
        public static string Execute(string preambleSize, string input)
        {
            var lines = input.Replace("\r", "").Split("\n").Select(line => long.Parse(line)).ToList();
            var invalidNumber = int.Parse(Day9Task1.Execute(preambleSize, input));
            var ranges = Enumerable.Range(0, lines.Count()).Select(x => Enumerable.Range(0, lines.Count() - x).Select(offset => new Tuple<int, int>(x, offset))).SelectMany(r => r);
            var correctRange = ranges.First(r => lines.GetRange(r.Item1, r.Item2).Sum() == invalidNumber);
            var smallest = lines.GetRange(correctRange.Item1, correctRange.Item2).Min();
            var largest = lines.GetRange(correctRange.Item1, correctRange.Item2).Max();
            return (smallest + largest).ToString();
        }
    }

}
