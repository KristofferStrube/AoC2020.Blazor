using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day4Task2
    {
        public static string Execute(string input)
        {
            var passports = input.Replace("\r", "").Split("\n\n");
            return passports.Select(p => p.Split("\n").Select(l => l.Split(" ")).SelectMany(field => field)).Count(p => p.Count(field => { var kv = field.Split(":");
                return
                (kv[0] == "byr" && int.Parse(kv[1]) >= 1920 && int.Parse(kv[1]) <= 2002) ||
                (kv[0] == "iyr" && int.Parse(kv[1]) >= 2010 && int.Parse(kv[1]) <= 2020) ||
                (kv[0] == "eyr" && int.Parse(kv[1]) >= 2020 && int.Parse(kv[1]) <= 2030) ||
                (kv[0] == "hgt" && (new Regex(@"^(1([5-8][0-9]|9[0-3])cm|(59|6[0-9]|7[0-6])in)$")).IsMatch(kv[1])) ||
                (kv[0] == "hcl" && (new Regex(@"^#([a-f0-9]{6})$")).IsMatch(kv[1])) ||
                (kv[0] == "ecl" && new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(kv[1])) ||
                (kv[0] == "pid" && (new Regex("^([0-9]{9})$")).IsMatch(kv[1]));
            }
            ) == 7).ToString();
        }
    }
}
