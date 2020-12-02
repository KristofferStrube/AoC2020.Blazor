using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day2Task2
    {
        public static string Execute(string input)
        {
            var lines = input.Split("\n")
                .Select(line =>
                    new Line(
                        Pos1: int.Parse(line.Split('-')[0])-1,
                        Pos2: int.Parse(line.Split(' ')[0].Split('-')[1])-1,
                        Character: line.Split(':')[0].Last(),
                        Password: line.Split(' ')[2]
                    )
                ).ToList();
            return lines.Count(line => line.Password[line.Pos1] == line.Character ^ line.Password[line.Pos2] == line.Character).ToString();
        }

        public record Line(int Pos1, int Pos2, char Character, string Password);

    }
}
