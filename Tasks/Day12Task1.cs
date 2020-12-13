using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC2020.Blazor.Tasks
{
    public static class Day12Task1
    {
        public static string Execute(string input)
        {
            var lines = input.Replace("\r", "").Split("\n");
            var endState = lines.Aggregate((orientation: 90, x: 0, y: 0), (state, comm) =>
            {
                switch (comm[0])
                {
                    case 'N': state.x += int.Parse(comm[1..]); break;
                    case 'S': state.x -= int.Parse(comm[1..]); break;
                    case 'E': state.y += int.Parse(comm[1..]); break;
                    case 'W': state.y -= int.Parse(comm[1..]); break;
                    case 'L': state.orientation = (360 + state.orientation - int.Parse(comm[1..])) % 360; break;
                    case 'R': state.orientation = (state.orientation + int.Parse(comm[1..])) % 360; break;
                    case 'F':
                        switch (state.orientation)
                        {
                            case 0: state.x += int.Parse(comm[1..]); break;
                            case 90: state.y += int.Parse(comm[1..]); break;
                            case 180: state.x -= int.Parse(comm[1..]); break;
                            case 270: state.y -= int.Parse(comm[1..]); break;
                        }; break;
                }
                return state;
            });
            return (Math.Abs(endState.x) + Math.Abs(endState.y)).ToString();
        }
    }

}
