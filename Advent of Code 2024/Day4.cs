namespace Advent_of_Code_2024;

public static class Day4
{
    public static void Run()
    {
        Console.WriteLine("--- Day 4: Ceres Search ---");

        var input = File.ReadAllText("input/day4.txt").Trim().Split('\n');

        List<List<char>> wordSearch = [];

        for (var i = 0; i < input.Length; i++)
        {
            wordSearch.Add(new List<char>());

            for (var j = 0; j < input[i].Length; j++)
            {
                wordSearch[i].Add(input[i][j]);
            }
        }

        Console.WriteLine("\tPart 1: " + Part1(wordSearch));
        Console.WriteLine("\tPart 2: " + Part2(wordSearch));
    }

    private static int Part1(List<List<char>> wordSearch)
    {
        var finds = 0;

        for (var i = 0; i < wordSearch.Count; i++)
        {
            for (var j = 0; j < wordSearch[i].Count; j++)
            {
                if (wordSearch[i][j] != 'X') continue;

                // Right
                if (j <= wordSearch[i].Count - 4)
                    if (wordSearch[i][j + 1] == 'M' && wordSearch[i][j + 2] == 'A' && wordSearch[i][j + 3] == 'S')
                        finds++;

                // Down
                if (i <= wordSearch.Count - 4)
                    if (wordSearch[i + 1][j] == 'M' && wordSearch[i + 2][j] == 'A' && wordSearch[i + 3][j] == 'S')
                        finds++;

                // Left
                if (j >= 3)
                    if (wordSearch[i][j - 1] == 'M' && wordSearch[i][j - 2] == 'A' && wordSearch[i][j - 3] == 'S')
                        finds++;

                // Up
                if (i >= 3)
                    if (wordSearch[i - 1][j] == 'M' && wordSearch[i - 2][j] == 'A' && wordSearch[i - 3][j] == 'S')
                        finds++;

                // Down Right
                if (j <= wordSearch[i].Count - 4 && i <= wordSearch.Count - 4)
                    if (wordSearch[i + 1][j + 1] == 'M' && wordSearch[i + 2][j + 2] == 'A' &&
                        wordSearch[i + 3][j + 3] == 'S')
                        finds++;

                // Up Right
                if (j <= wordSearch[i].Count - 4 && i >= 3)
                    if (wordSearch[i - 1][j + 1] == 'M' && wordSearch[i - 2][j + 2] == 'A' &&
                        wordSearch[i - 3][j + 3] == 'S')
                        finds++;

                // Down Left
                if (j >= 3 && i <= wordSearch.Count - 4)
                    if (wordSearch[i + 1][j - 1] == 'M' && wordSearch[i + 2][j - 2] == 'A' &&
                        wordSearch[i + 3][j - 3] == 'S')
                        finds++;

                // Up Left
                if (j >= 3 && i >= 3)
                    if (wordSearch[i - 1][j - 1] == 'M' && wordSearch[i - 2][j - 2] == 'A' &&
                        wordSearch[i - 3][j - 3] == 'S')
                        finds++;
            }
        }

        return finds;
    }

    private static int Part2(List<List<char>> wordSearch)
    {
        var finds = 0;

        for (var i = 0; i < wordSearch.Count; i++)
        {
            for (var j = 0; j < wordSearch[i].Count; j++)
            {
                if (wordSearch[i][j] != 'A') continue;

                if (j <= wordSearch[i].Count - 2 && i <= wordSearch.Count - 2 && j >= 1 && i >= 1)
                {
                    // Left M's
                    if (wordSearch[i + 1][j - 1] == 'M'
                        && wordSearch[i - 1][j - 1] == 'M'
                        && wordSearch[i - 1][j + 1] == 'S'
                        && wordSearch[i + 1][j + 1] == 'S')
                    {
                        finds++;
                    }

                    // Right M's
                    if (wordSearch[i - 1][j + 1] == 'M'
                        && wordSearch[i + 1][j + 1] == 'M'
                        && wordSearch[i + 1][j - 1] == 'S'
                        && wordSearch[i - 1][j - 1] == 'S')
                    {
                        finds++;
                    }

                    // Top M's
                    if (wordSearch[i - 1][j + 1] == 'M'
                        && wordSearch[i - 1][j - 1] == 'M'
                        && wordSearch[i + 1][j - 1] == 'S'
                        && wordSearch[i + 1][j + 1] == 'S')
                    {
                        finds++;
                    }

                    // Bottom M's
                    if (wordSearch[i + 1][j + 1] == 'M'
                        && wordSearch[i + 1][j - 1] == 'M'
                        && wordSearch[i - 1][j + 1] == 'S'
                        && wordSearch[i - 1][j - 1] == 'S')
                    {
                        finds++;
                    }
                }
            }
        }

        return finds;
    }
}