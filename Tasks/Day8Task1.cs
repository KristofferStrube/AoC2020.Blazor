using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day8Task1
    {
        public static string Execute(string input)
        {
            var visited = new HashSet<int>();
            var inst = input.Replace("\r", "").Split("\n").ToList();
            int index = 0;
            int acc = 0;
            while(!visited.Contains(index))
            {
                visited.Add(index);
                switch (inst[index].Substring(0,3))
                {
                    case "acc":
                        acc += int.Parse(inst[index].Substring(4, inst[index].Length - 4));
                        break;
                    case "jmp":
                        index += int.Parse(inst[index].Substring(4, inst[index].Length - 4));
                        continue;
                    default:
                        break;
                }
                index++;
            }
            return acc.ToString();
        }
    }

}
