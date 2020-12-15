using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day13Task1
    {
        public static string Execute(string input)
        {
            var lines = input.Replace("\r", "").Split("\n");
            var earliest = int.Parse(lines[0]);
            var busses = lines[1].Split(",").Where(bus => bus != "x").Select(bus => int.Parse(bus)).ToList();
            var shortest = Enumerable.Range(0, busses.Count()).Aggregate((min: 10000000000, id: 0), (prev, i) => busses[i]-(earliest % busses[i]) < prev.min ? (busses[i] - (earliest % busses[i]), busses[i]) : prev);
            return (shortest.min * shortest.id).ToString();
        }
    }

}
