using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day12Task2
    {
        public static string Execute(string input)
        {
            var lines = input.Replace("\r", "").Split("\n");
            var endState = lines.Aggregate((x: 0, y: 0, wx: 1, wy: 10), (state, comm) =>
            {
                var letter = comm[0];
                var numb = int.Parse(comm[1..]);
                switch (letter)
                {
                    case 'N': state.wx += numb; break;
                    case 'S': state.wx -= numb; break;
                    case 'E': state.wy += numb; break;
                    case 'W': state.wy -= numb; break;
                    case 'L':
                        switch (numb)
                        {
                            case 90: (state.wx, state.wy ) = (state.wy, -state.wx); break;
                            case 180: state.wx *= -1; state.wy *= -1; break;
                            case 270: (state.wx, state.wy) = (-state.wy, state.wx); break;
                        }
                        break;
                    case 'R':
                        switch (numb)
                        {
                            case 90: (state.wx, state.wy) = (-state.wy, state.wx); break;
                            case 180: state.wx *= -1; state.wy *= -1; break;
                            case 270: (state.wx, state.wy) = (state.wy, -state.wx); break;
                        }
                        break;
                    case 'F': state.x += numb * state.wx; state.y += numb * state.wy; break;
                }
                return state;
            });
            return (Math.Abs(endState.x) + Math.Abs(endState.y)).ToString();
        }
    }

}
