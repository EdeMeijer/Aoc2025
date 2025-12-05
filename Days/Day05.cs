using Aoc2025.Lib;

namespace Aoc2025.Days;

public sealed class Day05 : IDay
{
    private const string ExampleInput =
        """
        3-5
        10-14
        16-20
        12-18
        
        1
        5
        8
        11
        17
        32
        """;

    [Example(ExampleInput, 3)]
    public object Part1(IInput input)
    {
        var parts = input.Text.Split("\n\n");

        var freshRanges = parts[0].Split('\n').Select(line =>
        {
            var parts = line.Split('-');
            return (long.Parse(parts[0]), long.Parse(parts[1]));
        }).ToList();

        return parts[1].Split("\n").Count(line =>
        {
            var id = long.Parse(line);
            return freshRanges.Any(range => id >= range.Item1 && id <= range.Item2);
        });
    }

    [Example(ExampleInput, 14)]
    public object Part2(IInput input)
    {
        var parts = input.Text.Split("\n\n");

        var freshRanges = parts[0].Split('\n').Select(line =>
        {
            var parts = line.Split('-');
            return (long.Parse(parts[0]), long.Parse(parts[1]));
        }).ToList();

        bool TryMergeOverlappingRanges()
        {
            for (var i = 0; i < freshRanges.Count; i++)
            {
                var range1 = freshRanges[i];
                for (var j = i + 1; j < freshRanges.Count; j++)
                {
                    var range2 = freshRanges[j];
                    if (range1.Item1 <= range2.Item2 && range1.Item2 >= range2.Item1)
                    {
                        freshRanges.RemoveAt(j);
                        freshRanges.RemoveAt(i);
                        freshRanges.Add((long.Min(range1.Item1, range2.Item1), long.Max(range1.Item2, range2.Item2)));
                        return true;
                    }
                }
            }

            return false;
        }
        
        while (TryMergeOverlappingRanges())
        {}

        return freshRanges.Sum(range => range.Item2 - range.Item1 + 1);
    }
}