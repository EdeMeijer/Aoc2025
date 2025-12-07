using System.Text.RegularExpressions;
using Aoc2025.Lib;
using Aoc2025.Lib.Matrix;

namespace Aoc2025.Days;

public sealed class Day07 : IDay
{
    private const string ExampleInput =
        """
        .......S.......
        ...............
        .......^.......
        ...............
        ......^.^......
        ...............
        .....^.^.^.....
        ...............
        ....^.^...^....
        ...............
        ...^.^...^.^...
        ...............
        ..^...^.....^..
        ...............
        .^.^.^.^.^...^.
        ...............
        """;

    private static readonly Regex Splitter = new(@"\s+");

    [Example(ExampleInput, 21)]
    public object Part1(IInput input)
    {
        var grid = Matrix.Parse(input.Text);

        var splits = 0;
        
        var beamXs = new HashSet<int>();
        beamXs.Add(grid.Row(0).ToList().IndexOf('S'));
        
        for (var y = 1; y < grid.Height - 1; y++)
        {
            var newBeamXs = new HashSet<int>();
            
            foreach (var x in beamXs)
            {
                if (grid[y + 1, x] == '^')
                {
                    splits++;
                    newBeamXs.Add(x - 1);
                    newBeamXs.Add(x + 1);
                }
                else
                {
                    newBeamXs.Add(x);
                }
            }
            
            beamXs = newBeamXs;
        }

        return splits;
    }

    [Example(ExampleInput, 40)]
    public object Part2(IInput input)
    {
        var grid = Matrix.Parse(input.Text);

        var beamXs = new Dictionary<int, long>();
        beamXs.Add(grid.Row(0).ToList().IndexOf('S'), 1);
        
        for (var y = 1; y < grid.Height - 1; y++)
        {
            var newBeamXs = new Dictionary<int, long>();

            void AddBeam(int x, long n)
            {
                newBeamXs[x] = newBeamXs.GetValueOrDefault(x, 0) + n;
            }
            
            foreach (var (x, n) in beamXs)
            {
                if (grid[y + 1, x] == '^')
                {
                    AddBeam(x - 1, n);
                    AddBeam(x + 1, n);
                }
                else
                {
                    AddBeam(x, n);
                }
            }
            
            beamXs = newBeamXs;
        }

        return beamXs.Values.Sum();
    }
}