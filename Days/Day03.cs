using Aoc2025.Lib;

namespace Aoc2025.Days;

public sealed class Day03 : IDay
{
    private const string ExampleInput =
        """
        987654321111111
        811111111111119
        234234234234278
        818181911112111
        """;

    [Example(ExampleInput, 357)]
    public object Part1(IInput input)
    {
        var result = 0;

        foreach (var bank in input.Lines)
        {
            var values = bank.Select(c => int.Parse(c.ToString())).ToArray();
            var firstMax = values[..^1].Max();
            var firstMaxPos = values.IndexOf(firstMax);

            var secondMax = values[(firstMaxPos + 1)..].Max();
            result += firstMax * 10 + secondMax;
        }

        return result;
    }

    [Example(ExampleInput, 3121910778619)]
    public object Part2(IInput input)
    {
        var result = 0L;

        foreach (var bank in input.Lines)
        {
            var values = bank.Select(c => int.Parse(c.ToString())).ToArray();

            var digits = new List<int>();
            for (var b = 0; b < 12; b++)
            {
                var max = values[..^(11 - b)].Max();
                digits.Add(max);
                var maxPos = values.IndexOf(max);
                values = values[(maxPos + 1)..];
            }
            
            result += long.Parse(string.Join("", digits));
        }

        return result;
    }
}