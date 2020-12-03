using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day3Task2
    {
        public static string Execute(string input)
        {
            var lines = input.Replace("\r", "").Split("\n");
            var width = lines[0].Length;
            var vectors = new List<Vector> { new(1, 1), new(3, 1), new(5, 1), new(7, 1), new (1, 2) };

            return vectors.Select(v => Enumerable.Range(0, lines.Count()/v.y).Sum(i => lines[i*v.y][(i * v.x) % width] == '#' ? 1 : 0))
                .Aggregate((long)1, (res, trees) => res*trees).ToString();
        }

        public record Vector(int x, int y);
    }
}
