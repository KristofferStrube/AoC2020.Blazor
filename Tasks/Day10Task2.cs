using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day10Task2
    {
        private static Dictionary<int, long> subtree = new();

        private static List<long> lines = new();

        private static long deviceJolt;

        public static string Execute(string input)
        {
            lines = input.Replace("\r", "").Split("\n").Select(line => long.Parse(line)).ToList();
            lines.Add(0);
            lines.Sort();
            deviceJolt = lines.Last() + 3;
            return calcPerms(0).ToString();
        }

        private static long calcPerms(int index)
        {
            if (index == lines.Count())
            {
                return 1;
            }
            else if (subtree.ContainsKey(index))
            {
                return subtree[index];
            }
            else
            {
                var result = Enumerable.Range(index + 1, 3)
                        .Where(i => (i < lines.Count() && lines[i] - lines[index] <= 3)
                        || (i == lines.Count() && deviceJolt- lines[index] <= 3))
                        .Select(i => calcPerms(i))
                        .Sum();
                subtree[index] = result;
                return result;
            }
        }
    }

}
