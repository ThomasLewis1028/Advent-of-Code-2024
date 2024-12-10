using System.Text;

namespace Advent_of_Code_2024;

public static class Day6
{
    static List<(int x,int y)> _plots = new ();

    public static void Run()
    {
        Console.WriteLine("--- Day 6: Guard Gallivant ---");

        Console.WriteLine("\tPart 1: " + Part1());
        Console.WriteLine("\tPart 2: " + Part2());
    }

    private static int Part1()
    {
        var map = ReadMap();

        int x = 0;
        int y = 0;

        var escaped = false;

        var currentDir = Direction.Up;

        for (int i = 0; i < map.Count; i++)
        {
            if (!map[i].Contains('^')) continue;

            x = i;
            y = map[i].IndexOf('^');
        }

        while (!escaped)
        {
            if (!_plots.Any(p => p.Item1 == x && p.Item2 == y))
                _plots.Add((x, y));

            switch (currentDir)
            {
                case Direction.Up:
                    if (x == 0)
                    {
                        map[x][y] = 'X';
                        escaped = true;
                    }
                    else if (map[x - 1][y] == '#')
                    {
                        currentDir = Direction.Right;
                    }
                    else
                    {
                        map[x - 1][y] = '^';
                        map[x][y] = 'X';
                        x--;
                    }

                    break;

                case Direction.Right:
                    if (y == map[0].Count - 1)
                    {
                        map[x][y] = 'X';
                        escaped = true;
                    }
                    else if (map[x][y + 1] == '#')
                    {
                        currentDir = Direction.Down;
                    }
                    else
                    {
                        map[x][y + 1] = '>';
                        map[x][y] = 'X';
                        y++;
                    }

                    break;

                case Direction.Down:
                    if (x == map[0].Count - 1)
                    {
                        map[x][y] = 'X';
                        escaped = true;
                    }
                    else if (map[x + 1][y] == '#')
                    {
                        currentDir = Direction.Left;
                    }
                    else
                    {
                        map[x + 1][y] = 'V';
                        map[x][y] = 'X';
                        x++;
                    }

                    break;

                case Direction.Left:
                    if (y == 0)
                    {
                        map[x][y] = 'X';
                        escaped = true;
                    }
                    else if (map[x][y - 1] == '#')
                    {
                        currentDir = Direction.Up;
                    }
                    else
                    {
                        map[x][y - 1] = '<';
                        map[x][y] = 'X';
                        y--;
                    }

                    break;
            }
        }

        var count = map
            .Sum(row => row
                .Count(plot => plot == 'X'));

        return count;
    }

    private static int Part2()
    {
        int x = 0;
        int y = 0;
        int count = 0;

        int startX = 0;
        int startY = 0;


        var currentDir = Direction.Up;

        var map = ReadMap();

        for (int i = 0; i < map.Count; i++)
        {
            if (!map[i].Contains('^')) continue;

            x = i;
            y = map[i].IndexOf('^');

            startX = x;
            startY = y;
        }

        foreach (var plot in _plots)
        {
            if (plot.x == startX && plot.y == startY) continue;
            
             Dictionary<Tuple<int, int>, List<Direction>> plots = new Dictionary<Tuple<int, int>, List<Direction>>();

                var escaped = false;
                var looped = false;

                if (map[plot.x][plot.y] == '#') continue;
                if (plot.x == startX && plot.y == startY) continue;

                map = ReadMap();

                map[plot.x][plot.y] = 'O';

                x = startX;
                y = startY;
                currentDir = Direction.Up;

                while (!escaped && !looped)
                {
                    escaped = false;


                    if (plots.ContainsKey(new Tuple<int, int>(x, y)))
                    {
                        if (plots[new Tuple<int, int>(x, y)].Contains(currentDir))
                            looped = true;
                        else
                            plots[new Tuple<int, int>(x, y)].Add(currentDir);
                    }
                    else
                        plots.Add(new Tuple<int, int>(x, y), new List<Direction> { currentDir });

                    switch (currentDir)
                    {
                        case Direction.Up:
                            if (x == 0)
                            {
                                map[x][y] = (char)Direction.Up;
                                escaped = true;
                            }
                            else if (map[x - 1][y] == '#' || map[x - 1][y] == 'O')
                            {
                                currentDir = Direction.Right;
                            }
                            else
                            {
                                map[x - 1][y] = (char)Direction.Up;
                                map[x][y] = (char)Direction.Up;

                                x--;
                            }

                            break;

                        case Direction.Right:
                            if (y == map[0].Count - 1)
                            {
                                map[x][y] = (char)Direction.Right;
                                escaped = true;
                            }
                            else if (map[x][y + 1] == '#' || map[x][y + 1] == 'O')
                            {
                                currentDir = Direction.Down;
                            }
                            else
                            {
                                map[x][y + 1] = (char)Direction.Right;
                                map[x][y] = (char)Direction.Right;
                                y++;
                            }

                            break;

                        case Direction.Down:
                            if (x == map[0].Count - 1)
                            {
                                map[x][y] = (char)Direction.Down;
                                escaped = true;
                            }
                            else if (map[x + 1][y] == '#' || map[x + 1][y] == 'O')
                            {
                                currentDir = Direction.Left;
                            }
                            else
                            {
                                map[x + 1][y] = (char)Direction.Down;
                                map[x][y] = (char)Direction.Down;
                                x++;
                            }

                            break;

                        case Direction.Left:
                            if (y == 0)
                            {
                                map[x][y] = (char)Direction.Left;
                                escaped = true;
                            }
                            else if (map[x][y - 1] == '#' || map[x][y - 1] == 'O')
                            {
                                currentDir = Direction.Up;
                            }
                            else
                            {
                                map[x][y - 1] = (char)Direction.Left;
                                map[x][y] = (char)Direction.Left;
                                y--;
                            }

                            break;
                    }
                }

                if (looped)
                {
                    count++;
                    // PrintMap(map);
                }
        }

        PrintMap(map);
        return count;
    }

    private enum Direction
    {
        Up = '^',
        Down = 'V',
        Left = '<',
        Right = '>'
    }

    // For testing purposes
    private static void PrintMap(List<List<char>> map)
    {
        StringBuilder mapString = new StringBuilder();

        foreach (var row in map)
        {
            foreach (var c in row)
            {
                mapString.Append(c);
            }

            mapString.Append("\n");
        }

        Console.WriteLine(mapString);
    }

    private static List<List<char>> ReadMap()
    {
        return File
            .ReadAllText("input/day6.txt")
            .Trim()
            .Split("\n")
            .Select(line => line
                .ToCharArray()
                .ToList())
            .ToList();
    }
}