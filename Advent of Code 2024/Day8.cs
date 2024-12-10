namespace Advent_of_Code_2024;

public static class Day8
{
    public static void Run()
    {
        Console.WriteLine("--- Day 8: Resonant Collinearity ---");

        List<List<char>> input = File
            .ReadAllText("input/day8.txt")
            .Trim()
            .Split("\n")
            .Select(line => line
                .ToCharArray()
                .ToList())
            .ToList();

        Dictionary<(int X, int Y), List<char>> map = new();

        for (int i = 0; i < input.Count; i++)
        {
            for (int j = 0; j < input[i].Count; j++)
            {
                List<char> current = new List<char>();
                current.Add(input[i][j]);
                map.Add((i, j), current);
            }
        }

        Dictionary<char, List<(int X, int Y)>> antennas = new();

        foreach (var list in map)
        {
            foreach (var item in list.Value)
            {
                if (item == '.') continue;

                if (!antennas.ContainsKey(item))
                    antennas.Add(item, new List<(int x, int y)>());

                antennas[item].Add(list.Key);
            }
        }

        Console.WriteLine("\tPart 1: " + Part1(map, antennas));
        Console.WriteLine("\tPart 2: " + Part2(map, antennas));
    }

    private static long Part1(Dictionary<(int X, int Y), List<char>> map,
        Dictionary<char, List<(int X, int Y)>> antennas)
    {
        foreach (var frequency in antennas)
        {
            for (int i = 0; i < frequency.Value.Count - 1; i++)
            {
                for (int j = i + 1; j < frequency.Value.Count; j++)
                {
                    (int X, int Y) key = (frequency.Value[j].X - frequency.Value[i].X,
                        frequency.Value[j].Y - frequency.Value[i].Item2);

                    (int X, int Y) antinode1 = (frequency.Value[i].X + key.X * -1,
                        frequency.Value[i].Y + key.Y * -1);
                    (int X, int Y) antinode2 = (frequency.Value[j].X + key.X,
                        frequency.Value[j].Y + key.Y);

                    if (map.ContainsKey(antinode1))
                        map[antinode1].Add('#');
                    if (map.ContainsKey(antinode2))
                        map[antinode2].Add('#');
                }
            }
        }

        return map.Values.Count(a => a.Contains('#'));
    }

    private static long Part2(Dictionary<(int X, int Y), List<char>> map,
        Dictionary<char, List<(int X, int Y)>> antennas)
    {
        foreach (var frequency in antennas)
        {
            for (int i = 0; i < frequency.Value.Count - 1; i++)
            {
                for (int j = i + 1; j < frequency.Value.Count; j++)
                {
                    (int X, int Y) key = (frequency.Value[j].X - frequency.Value[i].X,
                        frequency.Value[j].Y - frequency.Value[i].Y);

                    (int X, int Y) antinode1 = (frequency.Value[i].X + key.X * -1,
                        frequency.Value[i].Y + key.Y * -1);
                    (int X, int Y) antinode2 = (frequency.Value[j].X + key.X,
                        frequency.Value[j].Y + key.Y);

                    
                    
                    map[frequency.Value[i]].Add('#');
                    map[frequency.Value[j]].Add('#');
                    
                    if (map.ContainsKey(antinode1))
                    {
                        map[antinode1].Add('#');

                        antinode1.X += key.X * -1;
                        antinode1.Y += key.Y * -1;

                        while (antinode1.X >= 0
                               && antinode1.X <= map.Last().Key.X
                               && antinode1.Y >= 0
                               && antinode1.Y <= map.Last().Key.Y)
                        {
                            map[antinode1].Add('#');
                            antinode1.X += key.X * -1;
                            antinode1.Y += key.Y * -1;
                        }
                    }

                    if (map.ContainsKey(antinode2))
                    {
                        map[antinode2].Add('#');

                        antinode2.X += key.X;
                        antinode2.Y += key.Y;

                        while (antinode2.X >= 0
                               && antinode2.X <= map.Last().Key.X
                               && antinode2.Y >= 0
                               && antinode2.Y <= map.Last().Key.Y)
                        {
                            map[antinode2].Add('#');
                            antinode2.X += key.X;
                            antinode2.Y += key.Y;
                        }
                    }
                }
            }
        }

        return map.Values.Count(a => a.Contains('#'));
    }

    private static void PrintMap(Dictionary<(int X, int Y), List<char>> map)
    {
        foreach (var plot in map)
        {
            if(plot.Key.Y == 0) 
                Console.WriteLine("\n");
            
            Console.Write("{0}", plot.Value.Last());
        }
    }
}