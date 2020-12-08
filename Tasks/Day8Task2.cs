using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day8Task2
    {
        public static string Execute(string input)
        {
            var insts_orig = input.Replace("\r", "").Split("\n");
            for(int i = 0; i<insts_orig.Length; i++)
            {
                var visited = new HashSet<int>();
                var insts = insts_orig.Select(s => (string)s.Clone()).ToList();
                int index = 0;
                int acc = 0;
                switch (insts[i].Substring(0, 3))
                {
                    case "nop":
                        insts[i] = insts[i].Replace("nop", "jmp");
                        break;
                    case "jmp":
                        insts[i] = insts[i].Replace("jmp", "nop");
                        break;
                    default:
                        continue;
                }
                while (!visited.Contains(index))
                {
                    if (index == insts.Count())
                    {
                        return acc.ToString();
                    }
                    visited.Add(index);
                    switch (insts[index].Substring(0, 3))
                    {
                        case "acc":
                            acc += int.Parse(insts[index].Substring(4, insts[index].Length - 4));
                            break;
                        case "jmp":
                            index += int.Parse(insts[index].Substring(4, insts[index].Length - 4));
                            continue;
                        default:
                            break;
                    }
                    index++;
                }
            }
            return "";
        }
    }

}
