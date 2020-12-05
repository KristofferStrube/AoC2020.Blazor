using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day4Task1
    {
        public static string Execute(string input)
        {
            var passports = input.Replace("\r", "").Split("\n\n");
            return passports.Select(p => p.Split("\n").Select(l => l.Split(" ")).SelectMany(field => field)).Count(p => p.Count(field =>
            field.StartsWith("byr") ||
            field.StartsWith("iyr") ||
            field.StartsWith("eyr") ||
            field.StartsWith("hgt") ||
            field.StartsWith("hcl") ||
            field.StartsWith("ecl") ||
            field.StartsWith("pid")
            ) == 7).ToString();
        }
    }
}
