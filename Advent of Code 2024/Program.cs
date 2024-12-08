using System.Diagnostics;
using Advent_of_Code_2024;

while (true)
{
    int day = 0;
    try
    {
        Console.Write("Select the day: ");
        day = Int32.Parse(Console.ReadLine() ?? string.Empty);
    }
    catch
    {
        Console.Clear();
        Console.WriteLine("Invalid day!\n");
        continue;
    }
    Console.Clear();
    
    var timer = Stopwatch.StartNew();
    
    switch (day)
    {
        case 1:
            Day1.Run();
            break;
        case 2:
            Day2.Run();
            break;
        case 3:
            Day3.Run();
            break;
        case 4:
            Day4.Run();
            break;
        case 5:
            Day5.Run();
            break;
        case 6:
            Day6.Run();
            break;
        case 7:
            Day7.Run();
            break;
        case 8:
            break;
        case 9:
            break;
        case 10:
            break;
        case 11:
            break;
        case 12:
            break;
        case 13:
            break;
        case 14:
            break;
        case 15:
            break;
        case 16:
            break;
        case 17:
            break;
        case 18:
            break;
        case 19:
            break;
        case 20:
            break;
        case 21:
            break;
        case 22:
            break;
        case 23:
            break;
        case 24:
            break;
    }
    
    Console.WriteLine("\nElapsed Time: " + timer.Elapsed);
    Console.WriteLine();
}