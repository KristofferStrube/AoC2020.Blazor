using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day6Task2
    {
        public static string Execute(string input)
        {
            return input.Replace("\r", "").Split("\n\n").Select(g => g.Split("\n").Skip(1).Aggregate((IEnumerable<char>)g.Split("\n").First(), (inter, p) => inter.Intersect(p)).Count()).Sum().ToString();
        }
    }
}
