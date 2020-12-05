using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day5Task1
    {
        public static string Execute(string input)
        {
            return input.Replace("\r", "").Split("\n").Select(line =>
            line.Substring(0, 7).Select((c, i) => c == 'B' ? Math.Pow(2, 7 - i - 1) : 0).Sum()*8+
            line.Substring(7, 3).Select((c, i) => c == 'R' ? Math.Pow(2, 3 - i - 1) : 0).Sum()
            ).Max().ToString();
        }
    }
}
