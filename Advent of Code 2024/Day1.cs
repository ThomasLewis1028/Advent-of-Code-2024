namespace Advent_of_Code_2024;

public class Day1
{
    public static void Run()
    {
        Console.WriteLine("--- Day 1: Historian Hysteria ---");
        
        var input = File.ReadAllText("input/day1.txt");

        var split = input.Replace("   ", ",").Replace("\n", ",").Split(',');
        List<int> left = new List<int>();
        List<int> right = new List<int>();

        bool flip = false;
        
        foreach (var item in split)
        {
            if (flip)
            {
                right.Add(int.Parse(item));
                flip = false;
            }
            else
            {
                left.Add(int.Parse(item));
                flip = true;
            }
        }

        left.Sort();
        right.Sort();

        Console.WriteLine("\tPart 1: " + Part1(left, right));
        Console.WriteLine("\tPart 2: " + Part2(left, right));
    }

    private static int Part1(List<int> left, List<int> right)
    {
        var sum = left.Select((t, i) => Math.Abs(t - right[i])).Sum();

        return sum;
    }

    private static int Part2(List<int> left, List<int> right)
    {
        var similarity = left.Select((l) => Math.Abs(l * right.Count(r => r == l))).Sum();
        
        return similarity;
    }
}