using Aoc2025.Lib;

namespace Aoc2025.Days;

public sealed class Day01 : IDay
{
    private const string ExampleInput =
        """
        L68
        L30
        R48
        L5
        R60
        L55
        L1
        L99
        R14
        L82
        """;

    [Example(ExampleInput, 3)]
    public object Part1(IInput input)
    {
        var pos = 50;
        var result = 0;
        foreach (var line in input.Lines)
        {
            var offset = (line[0] == 'L' ? -1 : 1) * int.Parse(line[1..]);
            pos = (pos + offset).Modulo(100);
            if (pos == 0)
            {
                result++;
            }
        }

        return result;
    }

    [Example(ExampleInput, 6)]
    public object Part2(IInput input)
    {
        var pos = 50;
        var result = 0;
        foreach (var line in input.Lines)
        {
            var sign = line[0] == 'L' ? -1 : 1;
            var magnitude = int.Parse(line[1..]);
            var fullRotations = magnitude / 100;
            result += fullRotations;
            magnitude -= fullRotations * 100;
            var newPos = pos + sign * magnitude;

            if (pos != 0 && newPos is <= 0 or >= 100)
            {
                result++;
            }

            pos = newPos.Modulo(100);
        }

        return result;
    }
}