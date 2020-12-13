using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day11Task1
    {
        public static string Execute(string input)
        {
            var seatings = input.Replace("\r", "").Split("\n").Select(s => new StringBuilder(s)).ToList();
            var prevSeatings = Enumerable.Range(0, seatings.Count()).Select(line => new StringBuilder(seatings[0].Length)).ToList();
            while (new string(seatings.Select(line => line.ToString().Select(c => c)).SelectMany(c => c).ToArray()) !=
                new string(prevSeatings.Select(line => line.ToString().Select(c => c)).SelectMany(c => c).ToArray()))
            {
                prevSeatings = seatings.Select(s => new StringBuilder(s.ToString())).ToList();
                Enumerable.Range(0, prevSeatings.Count)
                    .Select(x => Enumerable.Range(0, prevSeatings[0].Length).Select(y => (x, y)))
                    .SelectMany(pos => pos)
                    .Select(pos => (pos, status: prevSeatings[pos.x][pos.y], adj: adjacentOccupiedSeats(pos, prevSeatings))).ToList()
                    .ForEach(seat => seatings[seat.pos.x][seat.pos.y] = (seat.status == 'L' && seat.adj == 0) ? '#'
                    : (seat.status == '#' && seat.adj >= 4) ? 'L'
                    : seat.status);
            }
            return seatings.Select(line => line.ToString().ToArray()).SelectMany(c => c).Count(c => c == '#').ToString();
        }

        public static int adjacentOccupiedSeats((int x, int y) pos, List<StringBuilder> seatings)
        {
            (int x, int y)[] offsets = new (int x, int y)[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };
            return offsets.Where(offset =>
                (pos.x + offset.x < seatings.Count() && pos.x + offset.x >= 0) &&
                (pos.y + offset.y < seatings[0].Length && pos.y + offset.y >= 0) &&
                (seatings[pos.x + offset.x][pos.y + offset.y] == '#')
            ).Count();
        }
    }

}
