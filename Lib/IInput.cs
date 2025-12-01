namespace Aoc2025.Lib;

public interface IInput
{
    string Text { get; }
    
    IList<string> Lines { get; }
}