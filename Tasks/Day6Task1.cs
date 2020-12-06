using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day6Task1
    {
        public static string Execute(string input)
        {
            return input.Replace("\r", "").Split("\n\n").Select(g => g.Replace("\n", "").Distinct().Count()).Sum().ToString();
        }
    }
}
