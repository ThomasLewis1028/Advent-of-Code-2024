namespace Advent_of_Code_2024;

public static class Day9
{
    public static void Run()
    {
        Console.WriteLine("--- Day 9: Disk Defragmenter ---");

        List<int> disk = File
            .ReadAllText("input/day9.txt")
            .ToCharArray()
            .Select(a => int
                .Parse(a
                    .ToString()))
            .ToList();


        Console.WriteLine("\tPart 1: " + Part1(disk));
        // Console.WriteLine("\tPart 2: " + Part2(disk));
    }

    private static long Part1(List<int> disk)
    {
        List<string> defraggedDisk = new List<string>();

        int val = 0;

        for (int i = 0; i < disk.Count; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < disk[i]; j++)
                    defraggedDisk.Add(val.ToString());

                val++;
            }
            else
            {
                for (int j = 0; j < disk[i]; j++)
                    defraggedDisk.Add(".");
            }
        }

        List<int> sortedDisk = new List<int>();

        for (int i = 0; i < defraggedDisk.Count; i++)
        {
            if (defraggedDisk[i] != ".")
            {
                sortedDisk.Add(int.Parse(defraggedDisk[i]));
                defraggedDisk[i] = ".";
            }
            else if (defraggedDisk[i] == ".")
            {
                for (int j = defraggedDisk.Count - 1; j >= 0; j--)
                {
                    if (defraggedDisk[j] != ".")
                    {
                        sortedDisk.Add(int.Parse(defraggedDisk[j]));
                        defraggedDisk.RemoveAt(j);
                        break;
                    }
                }
            }
        }

        long sum = 0;
        val = 0;

        foreach (var t in sortedDisk)
        {
            sum += t * val;
            val++;
        }

        return sum;
    }

    private static long Part2(List<int> disk)
    {
        List<(int count, string value)> defraggedDisk = new();

        int val = 0;

        for (int i = 0; i < disk.Count; i++)
        {
            if (i % 2 == 0)
            {
                defraggedDisk.Add((disk[i], val.ToString()));
                val++;
            }
            else
                defraggedDisk.Add((disk[i], "."));
        }
        
        
        List<(int count, string value)> sortedDisk = new (defraggedDisk);

        for (int i = defraggedDisk.Count - 1; i > 0; i--)
        {
            if (defraggedDisk[i].value != ".")
            {
                for (int j = 0; j < i; j++)
                {
                    if (sortedDisk[j].value == "." && defraggedDisk[i].count <= sortedDisk[j].count)
                    {
                        var count = sortedDisk[j].count - defraggedDisk[i].count;
                        
                        sortedDisk[j] = (count, ".");
                        
                        sortedDisk.RemoveAt(i);
                        
                        sortedDisk.Insert(j, defraggedDisk[i]);
                        
                        break;
                    }
                }
            }
        }
        
        List<string> defragged = new List<string>();
        
        foreach (var t in sortedDisk)
        {
            for (int i = 0; i < t.count; i++)
            {
                defragged.Add(t.value);
            }
        }
        
        long sum = 0;
        val = 0;
        
        
        foreach (var t in defragged)
        {
            if (t == ".") continue;
            
            sum += int.Parse(t) * val;
            val++;
        }

        return sum;
    }

    private static void PrintInt(List<int> disk)
    {
        foreach (var c in disk)
        {
            Console.Write(c);
        }

        Console.WriteLine();
    }
    
    private static void PrintString(List<string> disk)
    {
        foreach (var c in disk)
        {
            Console.Write(c);
        }

        Console.WriteLine();
    }
}