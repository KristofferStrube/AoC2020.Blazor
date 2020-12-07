using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day7Task1
    {
        public static string Execute(string input)
        {
            var network = input.Replace("\r", "").Replace(".", "").Replace("s", "").Split("\n").Select(rule => new Node(
                rule.Split(" contain ")[0],
                rule.Split(" contain ")[1] == "no other bag" ? new List<Tuple<string, int>>() : rule.Split(" contain ")[1].Split(", ").Select(child => new Tuple<string, int>(
                    child.Replace(child.Split(" ")[0] + " ", ""),
                    int.Parse(child.Split(" ")[0])
                    )
                ).ToList()
                )).ToList();
            return (PossibleParents(network, "hiny gold bag").Distinct().Count()-1).ToString();
        }
        public static IEnumerable<string> PossibleParents(IEnumerable<Node> network, string from)
        {
            return network.Where(node => node.Children.Select(t => t.Item1).Contains(from)).Select(ps => PossibleParents(network, ps.Name)).SelectMany(ps => ps).Append(from);
        }

        public record Node(string Name, IEnumerable<Tuple<string, int>> Children);
    }

}
