using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day9Task1
    {
        public static string Execute(string preambleSize, string input)
        {
            var preamble_size = int.Parse(preambleSize);
            var lines = input.Replace("\r", "").Split("\n").Select(line => long.Parse(line)).ToList();
            return lines[Enumerable.Range(preamble_size, lines.Count()-preamble_size).First(x => !lines.GetRange(x- preamble_size, preamble_size).Any(y => lines.GetRange(x - preamble_size, preamble_size).Any(z => y + z == lines[x])))].ToString();
        }
    }

}
