using Aoc2025.Lib;
using Aoc2025.Lib.Matrix;

namespace Aoc2025.Days;

public sealed class Day04 : IDay
{
    private const string ExampleInput =
        """
        ..@@.@@@@.
        @@@.@.@.@@
        @@@@@.@.@@
        @.@@@@..@.
        @@.@@@@.@@
        .@@@@@@@.@
        .@.@.@.@@@
        @.@@@.@@@@
        .@@@@@@@@.
        @.@.@@@.@.
        """;

    [Example(ExampleInput, 13)]
    public object Part1(IInput input)
    {
        var grid = Matrix.Parse(input.Text);

        var result = 0;
        foreach (var coord in grid.Coords)
        {
            if (grid[coord] != '@')
            {
                continue;
            }

            if (coord.GetNeighbors().Count(n => grid.Contains(n) && grid[n] == '@') < 4)
            {
                result++;
            }
        }

        return result;
    }

    [Example(ExampleInput, 43)]
    public object Part2(IInput input)
    {
        var grid = Matrix.Parse(input.Text);

        var result = 0;


        for (;;)
        {
            var toRemove = new HashSet<Vec2D>();
            foreach (var coord in grid.Coords)
            {
                if (grid[coord] != '@')
                {
                    continue;
                }

                if (coord.GetNeighbors().Count(n => grid.Contains(n) && grid[n] == '@') < 4)
                {
                    result++;
                    toRemove.Add(coord);
                }
            }

            if (toRemove.Count == 0)
            {
                break;
            }

            foreach (var coord in toRemove)
            {
                grid[coord] = '.';
            }
        }

        return result;
    }
}