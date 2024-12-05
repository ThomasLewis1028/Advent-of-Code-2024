namespace Advent_of_Code_2024;

public static class Day5
{
    public static void Run()
    {
        Console.WriteLine("--- Day 5: Print Queue ---");

        var input = File.ReadAllText("input/day5.txt").Trim().Split("\n\n");

        Dictionary<int, List<int>> rules = new Dictionary<int, List<int>>();
        List<List<int>> pageGroups = input[1]
            .Split("\n")
            .Select(line => line.Split(",")
                .Select(int.Parse).
                ToList())
            .ToList();

        foreach (var rule in input[0].Split('\n'))
        {
            int key = int.Parse(rule.Substring(0, rule.IndexOf('|')));
            int value = int.Parse(rule.Substring(rule.IndexOf('|') + 1));
            
            if (!rules.ContainsKey(key))
                rules.Add(key, new List<int> { value });
            else
                rules[key].Add(value);
        }

        Console.WriteLine("\tPart 1: " + Part1(rules, pageGroups));
        Console.WriteLine("\tPart 2: " + Part2(rules, pageGroups));
    }

    private static int Part1(Dictionary<int, List<int>> rules, List<List<int>> pageGroups)
    {
        var sum = 0;

        foreach (var pages in pageGroups)
        {
            bool correct = true;
            
            for (int i = pages.Count-1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (!rules.ContainsKey(pages[i])) continue;
                    if (!rules[pages[i]].Contains(pages[j])) continue;
                    
                    correct = false;
                    break;
                }
                
                if (!correct)
                    break;
            }
            
            if (correct)
                sum += pages[pages.Count/2];
        }
       
        return sum;
    }

    private static int Part2(Dictionary<int, List<int>> rules, List<List<int>> pageGroups)
    {
        var sum = 0;
        var badPageGroups = new List<List<int>>();

        foreach (var pages in pageGroups)
        {
            bool correct = true;
            
            for (int i = pages.Count-1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (!rules.ContainsKey(pages[i])) continue;
                    if (!rules[pages[i]].Contains(pages[j])) continue;
                    
                    correct = false;
                    break;
                }
                
                if (!correct)
                    break;
            }

            if (!correct)
                badPageGroups.Add(pages);
        }

        foreach (var badPageGroup in badPageGroups)
        {
            
        }
       
        return badPageGroups.Count;
    }
}