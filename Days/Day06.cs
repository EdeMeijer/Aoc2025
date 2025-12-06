using System.Text.RegularExpressions;
using Aoc2025.Lib;
using Aoc2025.Lib.Matrix;

namespace Aoc2025.Days;

public sealed class Day06 : IDay
{
    private const string ExampleInput =
        """
        123 328  51 64 
         45 64  387 23 
          6 98  215 314
        *   +   *   + 
        """;
    
    private static readonly Regex Splitter = new(@"\s+");

    [Example(ExampleInput, 4277556)]
    public object Part1(IInput input)
    {
       var rows = input.Lines.Select(line => Splitter.Split(line.Trim())).ToArray();

       var result = 0L;

       for (var i = 0; i < rows[0].Length; i++)
       {
           var op = rows[^1][i];
           result += rows[..^1].Select(row => long.Parse(row[i])).Aggregate((a, b) => op == "+" ? a + b : a * b);
       }
       
       return result;
    }

    [Example(ExampleInput, 3263827)]
    public object Part2(IInput input)
    {
        var grid = Matrix.Parse(input.Text);

        var result = 0L;
        List<long> operands = [];
        
        for (var x = grid.Width - 1; x >= 0; x--)
        {
            long? operand = null;
            for (var y = 0; y < grid.Height; y++)
            {
                var c = grid[y, x];
                if (c == ' ')
                {
                    continue;
                }

                if (c is '+' or '*')
                {
                    if (operand != null)
                    {
                        operands.Add(operand.Value);
                        operand = null;
                    }
                    
                    result += operands.Aggregate((a, b) => c == '+' ? a + b : a * b);
                    
                    operands.Clear();
                    continue;
                }

                // Digit
                operand ??= 0;
                operand *= 10;
                operand += long.Parse(c.ToString());
            }

            if (operand != null)
            {
                operands.Add(operand.Value);
            }
        }

        return result;
    }
}