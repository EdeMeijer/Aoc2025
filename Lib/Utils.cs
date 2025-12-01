namespace Aoc2025.Lib;

public static class Utils
{
    public static int Modulo(this int x, int m) => ( x % m + m ) % m;
}