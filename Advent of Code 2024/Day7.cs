namespace Advent_of_Code_2024;

public static class Day7
{
    public static void Run()
    {
        Console.WriteLine("--- Day 7: Bridge Repair ---");

        List<List<char>> map = File
            .ReadAllText("input/day7.txt")
            .Trim()
            .Split("\n")
            .Select(line => line
                .ToCharArray()
                .ToList())
            .ToList();


        Console.WriteLine("\tPart 1: " + Part1());
        Console.WriteLine("\tPart 2: " + Part2());
    }

    private static int Part1()
    {
        
        return 0;
    }

    private static int Part2()
    {
        return 0;
    }
}