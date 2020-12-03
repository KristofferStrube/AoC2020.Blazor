using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day3Task1
    {
        public static string Execute(string input)
        {
            var lines = input.Replace("\r", "").Split("\n");
            var width = lines[0].Length;
            return Enumerable.Range(0, lines.Count()).Sum(i => lines[i][(i * 3) % width] == '#' ? 1 : 0).ToString();
        }
    }
}
