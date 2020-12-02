using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Example
    {
        public static string Execute(string input)
        {
            return input.Split("\n").Select(s => long.Parse(s)).Max().ToString();
        }
    }
}
