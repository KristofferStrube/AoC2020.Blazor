using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day7Task2
    {
        public static string Execute(string input)
        {
            var network = input.Replace("\r", "").Replace(".", "").Replace("s", "").Split("\n").Select(rule => new Node(
                rule.Split(" contain ")[0],
                rule.Split(" contain ")[1] == "no other bag" ? new List<Tuple<string, int>>() : rule.Split(" contain ")[1].Split(", ").Select(child => new Tuple<string, int>(
                    child.Replace(child.Split(" ")[0] + " ", ""),
                    int.Parse(child.Split(" ")[0])
                    ))));
            return (Children(network, "hiny gold bag")- 1).ToString();
        }

        public static int Children(IEnumerable<Node> network, string from)
        {
            return 1 + network.First(n => n.Name == from).Children.Select(t => Children(network, t.Item1) * t.Item2).Sum();
        }

        public record Node(string Name, IEnumerable<Tuple<string, int>> Children);
    }
}
