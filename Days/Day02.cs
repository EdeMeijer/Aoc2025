using Aoc2025.Lib;

namespace Aoc2025.Days;

public sealed class Day02 : IDay
{
    private const string ExampleInput =
        """
        11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124
        """;

    [Example(ExampleInput, 1227775554L)]
    public object Part1(IInput input)
    {
        long sum = 0;
        foreach (var range in input.Text.Split(','))
        {
            var parts = range.Split('-');
            var end = long.Parse(parts[1]);
            for (var i = long.Parse(parts[0]); i <= end; i++)
            {
                var str = i.ToString();
                if (str.Length % 2 == 0 && str[..(str.Length / 2)] == str[(str.Length / 2)..])
                {
                    sum += i;
                }
            }
        }
        
        return sum;
    }

    [Example(ExampleInput, 4174379265L)]
    public object Part2(IInput input)
    {
        long sum = 0;
        foreach (var range in input.Text.Split(','))
        {
            var parts = range.Split('-');
            var end = long.Parse(parts[1]);
            for (var i = long.Parse(parts[0]); i <= end; i++)
            {
         
                if (IsInvalid(i))
                {
                    sum += i;
                }
            }
        }
        
        return sum;

        static bool IsInvalid(long id)
        {
            var str = id.ToString();

            for (var l = 1; l <= str.Length / 2; l++)
            {
                if (str.Length % l == 0)
                {
                    var invalid = true;
                    var n = str.Length / l;
                    var chunk = str[..l];
                    for (var i = 1; i < n; i++)
                    {
                        if (str[(l * i)..(l * (i + 1))] != chunk)
                        {
                            invalid = false;
                            break;
                        }
                    }
                    
                    if (invalid)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}