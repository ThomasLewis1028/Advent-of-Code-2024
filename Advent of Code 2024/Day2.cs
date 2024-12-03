namespace Advent_of_Code_2024;

public class Day2
{
    public void Run()
    {
        Console.WriteLine("--- Day 2: Red-Nosed Reports ---");

        var input = File
            .ReadAllText("input/day2.txt")
            .Split('\n');

        var data = input
            .Select(l => l
                .Split(" ")
                .Select(long.Parse)
                .ToList())
            .ToList();

        Part1(data);
        Part2(data);
    }

    private static void Part1(List<List<long>> data)
    {
        var safeCount = 0;

        foreach (var report in data)
        {
            var decCount = 0;
            var incCount = 0;
            var safe = true;

            for (var i = 1; i < report.Count; i++)
            {
                if (report[i] < report[i - 1] && report[i - 1] - report[i] <= 3)
                    decCount++;
                else if (report[i] > report[i - 1] && report[i] - report[i - 1] <= 3)
                    incCount++;
                else
                {
                    safe = false;
                    break;
                }
            }

            if (decCount > 0 && incCount > 0)
            {
                safe = false;
            }

            if (safe) safeCount++;
        }

        Console.WriteLine("\tPart 1: " + safeCount);
    }

    private static void Part2(List<List<long>> data)
    {
        var safeCount = 0;

        foreach (var report in data)
        {
            var safe = false;

            for (var i = 0; i < report.Count; i++)
            {
                var decCount = 0;
                var incCount = 0;

                var permutation = new List<long>(report);

                permutation.RemoveAt(i);

                for (var j = 1; j < permutation.Count; j++)
                {
                    safe = true;

                    if (permutation[j] < permutation[j - 1] && permutation[j - 1] - permutation[j] <= 3)
                    {
                        decCount++;
                        continue;
                    }

                    if (permutation[j] > permutation[j - 1] && permutation[j] - permutation[j - 1] <= 3)
                    {
                        incCount++;
                        continue;
                    }

                    safe = false;
                    break;
                }

                if (decCount > 0 && incCount > 0)
                    safe = false;

                if (safe) break;
            }


            if (safe)
                safeCount++;
        }

        Console.WriteLine("\tPart 2: " + safeCount);
    }
}