namespace Advent_of_Code_2024;

public static class Day10
{
    public static void Run()
    {
        Console.WriteLine("--- Day 10: Hoof It ---");

        List<List<int>> input = File
            .ReadAllText("input/day10.txt")
            .Split('\n')
            .Select(line => line
                .ToCharArray()
                .Select(a => int
                    .Parse(a
                        .ToString()))
                .ToList())
            .ToList();

        Dictionary<(int X, int Y), int> map = new ();

        for (int x = 0; x < input.Count; x++)
        {
            for (int y = 0; y < input[x].Count; y++)
            {
                map.Add((x, y), input[x][y]);
            }
        }

        Console.WriteLine("\tPart 1: " + Part1(map));
        Console.WriteLine("\tPart 2: " + Part2(map));
    }

    private static int Part1(Dictionary<(int X, int Y), int> map)
    {
        var total = 0;
        
        foreach (var head in map.Where(p => p.Value == 0))
        {
            Dictionary<(int X, int Y), List<(int X, int Y)>> endpoints = new();
            
            Traverse(map, (head.Key.X, head.Key.Y), (head.Key.X, head.Key.Y, head.Value), endpoints);
            
            total += endpoints.Count;
        }
        
        return total;
    }

    private static long Part2(Dictionary<(int X, int Y), int> map)
    {
        var total = 0;
        
        foreach (var head in map.Where(p => p.Value == 0))
        {
            Dictionary<(int X, int Y), List<(int X, int Y)>> endpoints = new();
            
            Traverse(map, (head.Key.X, head.Key.Y), (head.Key.X, head.Key.Y, head.Value), endpoints, false);
            
            total += endpoints[(head.Key.X, head.Key.Y)].Count;
        }
        
        return total;
    }

    private static void Traverse(Dictionary<(int X, int Y), int> map, 
        (int X, int Y) head,
        (int X, int Y, int Val) start, 
        Dictionary<(int X, int Y), List<(int X, int Y)>> endpoints,
        bool part1 = true)
    
    {
        (int X, int Y) up = (start.X - 1, start.Y);
        (int X, int Y) right = (start.X, start.Y + 1);
        (int X, int Y) down = (start.X + 1, start.Y);
        (int X, int Y) left = (start.X, start.Y - 1);

        
        // Up
        if (map.ContainsKey(up) && map[up] == start.Val + 1)
        {
            if (map[up] == 9)
            {
                if(part1)
                {
                    if (endpoints.ContainsKey(up))
                        endpoints[up].Add(head);
                    else
                        endpoints.Add(up, new List<(int X, int Y)> { head });
                }
                else
                {
                    if (endpoints.ContainsKey(head))
                        endpoints[head].Add(up);
                    else
                        endpoints.Add(head, new List<(int X, int Y)> { up });
                }
            }
            else
                Traverse(map, head, (up.X, up.Y, start.Val + 1), endpoints, part1);
        }
        // Right
        if (map.ContainsKey(right) && map[right] == start.Val + 1)
        {
            if (map[right] == 9)
            {
                if (part1)
                {
                    if (endpoints.ContainsKey(right))
                        endpoints[right].Add(head);
                    else
                        endpoints.Add(right, new List<(int X, int Y)> { head });
                }
                else
                {
                    if (endpoints.ContainsKey(head))
                        endpoints[head].Add(right);
                    else
                        endpoints.Add(head, new List<(int X, int Y)> { right });
                }
            }
            else
                Traverse(map, head, (right.X, right.Y, start.Val + 1), endpoints, part1);
        }
        // Down
        if (map.ContainsKey(down) && map[down] == start.Val + 1)
        {
            if (map[down] == 9)
            {
                if (part1)
                {
                    if (endpoints.ContainsKey(down))
                        endpoints[down].Add(head);
                    else
                        endpoints.Add(down, new List<(int X, int Y)> { head });
                }
                else
                {
                    if (endpoints.ContainsKey(head))
                        endpoints[head].Add(down);
                    else
                        endpoints.Add(head, new List<(int X, int Y)> { down });
                }
            }
            else
                Traverse(map, head, (down.X, down.Y, start.Val + 1), endpoints, part1);
        }
        // Left
        if (map.ContainsKey(left) && map[left] == start.Val + 1)
        {
            if (map[left] == 9)
            {
                if (part1)
                {
                    if (endpoints.ContainsKey(left))
                        endpoints[left].Add(head);
                    else
                        endpoints.Add(left, new List<(int X, int Y)> { head });
                }
                else
                {
                    if (endpoints.ContainsKey(head))
                        endpoints[head].Add(left);
                    else
                        endpoints.Add(head, new List<(int X, int Y)> { left });
                }
            }
            else
                Traverse(map, head, (left.X, left.Y, start.Val + 1), endpoints, part1);
        }
    }
}