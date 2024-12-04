using System.Text.RegularExpressions;

namespace Advent_of_Code_2024;

public class Day3
{
    public static void Run()
    {
        Console.WriteLine("--- Day 3: Mull It Over ---");
        
        var input = File.ReadAllText("input/day3.txt").Trim();
        
        Console.WriteLine("\tPart 1: " + Part1(input));
        Console.WriteLine("\tPart 2: " + Part2(input));
    }

    private static int Part1(string input)
    {
        var memory = Regex.Matches(input, @"mul\(\d{1,3},\d{1,3}\)").ToList();
        
        var sum = 0;
        
        foreach (var match in memory)
        {
            var equation = match.Value
                .Replace("mul(", "")
                .Replace(")", "")
                .Split(",")
                .Select(int.Parse)
                .ToList();
            
            sum += equation[0] * equation[1];
        }
        
        return sum;
    }

    private static int Part2(string input)
    {
        var memory = Regex.Matches(input, @"(mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\))").ToList();
        
        var sum = 0;
        var disabled = false;
        
        foreach (var match in memory)
        {
            if (Regex.IsMatch(match.Value, @"^do\(\)"))
            {
                disabled = false;
                continue;
            }
            if (Regex.IsMatch(match.Value, @"^don't\(\)"))
            {
                disabled = true;
                continue;
            }

            if (disabled) continue;
            
            var equation = match.Value
                .Replace("mul(", "")
                .Replace(")", "")
                .Split(",")
                .Select(int.Parse)
                .ToList();

            sum += equation[0] * equation[1];
        }
        
        return sum;
    }
}