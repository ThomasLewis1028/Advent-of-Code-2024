using System.Text;

namespace Advent_of_Code_2024;

public static class Day7
{
    public static void Run()
    {
        Console.WriteLine("--- Day 7: Bridge Repair ---");

        List<string> input = File
            .ReadAllText("input/day7.txt")
            .Trim()
            .Split("\n")
            .ToList();

        List<(long answer, List<long> values)> equations = new List<(long, List<long>)>();

        foreach (var line in input)
        {
            var answer = long
                .Parse(line
                    .Split(":")[0]);

            var values = line
                .Split(": ")[1]
                .Split(" ")
                .Select(long
                    .Parse)
                .ToList();

            equations.Add((answer, values));
        }


        Console.WriteLine("\tPart 1: " + Part1(equations));
        Console.WriteLine("\tPart 2: " + Part2(equations));
    }

    private static long Part1(List<(long answer, List<long> values)> equations)
    {
        long sum = 0;

        foreach (var equation in equations)
        {
            List<long> eqAnswers = new List<long>();

            Calculate(eqAnswers, equation.values, "", 0);

            if (eqAnswers.Contains(equation.answer))
                sum += equation.answer;
        }

        return sum;
    }

    private static long Part2(List<(long answer, List<long> values)> equations)
    {
        long sum = 0;

        foreach (var equation in equations)
        {
            List<long> eqAnswers = new List<long>();

            Calculate(eqAnswers, equation.values, "", 0, true);

            if (eqAnswers.Contains(equation.answer))
                sum += equation.answer;
        }

        return sum;
    }

    private static List<long> Calculate(List<long> eqAnswers, List<long> values, string equation, int index,
        bool pt2 = false)
    {
        if (index <= values.Count - 1)
        {
            for (int i = index; i < values.Count; i++)
            {
                if (i != values.Count - 1)
                {
                    Calculate(eqAnswers, values, equation + values[i] + " + ", i + 1, pt2);
                    Calculate(eqAnswers, values, equation + values[i] + " * ", i + 1, pt2);
                    if (pt2)
                        Calculate(eqAnswers, values, equation + values[i] + " || ", i + 1, pt2);
                }
                else
                {
                    equation += values[i];
                }
            }
        }

        if (index == values.Count - 1)
        {
            var eq = equation.Split(' ');

            var answer = long.Parse(eq[0]);

            for (var i = 1; i < eq.Length; i++)
            {
                switch (eq[i])
                {
                    case "+":
                        answer += long.Parse(eq[i + 1]);
                        i++;
                        break;
                    case "*":
                        answer *= long.Parse(eq[i + 1]);
                        i++;
                        break;
                    case "||":
                        answer = Convert.ToInt64("" + answer + "" + long.Parse(eq[i + 1]));
                        i++;
                        break;
                }
            }

            eqAnswers.Add(answer);
        }

        return eqAnswers;
    }
}