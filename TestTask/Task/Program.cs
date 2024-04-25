using System;

class MainClass
{
    public static void Main(string[] args)
    {
        // Arrays List
        int[] table1 = {1, 5, 9, 10, 5};
        int[] table2 = {1, 2, 3};
        int[] table3 = {0, 1, 1, 1, 1, 1, 1, 1, 1, 2};

        // Result
        Console.WriteLine($"Table 1: {ChipsMoves(table1)}");
        Console.WriteLine($"Table 2: {ChipsMoves(table2)}");
        Console.WriteLine($"Table 3: {ChipsMoves(table3)}");
    }

    public static int ChipsMoves(int[] chips)
    {
        int n = chips.Length;
        int moves = 0;

        // Get Chips Amount
        int sum = 0;
        foreach (int chip in chips)
            sum += chip;
        int target = sum / n;

        // Chips Move
        for (int i = 0; i < n; i++)
        {
            int diff = chips[i] - target;
            if (diff > 0)
            {
                // If Chips > Average -> Chips Move TO Next Place
                if (i < n - 1)
                {
                    int toNext = Math.Min(diff, chips[i + 1]);
                    chips[i] -= toNext;
                    chips[i + 1] += toNext;
                    moves += toNext;
                    Console.WriteLine($"Move: {toNext} Chips In {i} To {i + 1}");
                }
                else
                {
                    int toNext = Math.Min(diff, chips[0]);
                    chips[i] -= toNext;
                    chips[0] += toNext;
                    moves += toNext;
                    Console.WriteLine($"Move: {toNext} Chips In {i} To 0");
                }
            }
            else if (diff < 0)
            {
                // Chips In To Current Place < Average
                // Get Chips In To Previous Place
                if (i > 0)
                {
                    int fromPrev = Math.Min(-diff, chips[i - 1]);
                    chips[i] += fromPrev;
                    chips[i - 1] -= fromPrev;
                    moves += fromPrev;
                    Console.WriteLine($"Move: {fromPrev} Chips In {i - 1} To {i}");
                }
                else
                {
                    int fromPrev = Math.Min(-diff, chips[n - 1]);
                    chips[i] += fromPrev;
                    chips[n - 1] -= fromPrev;
                    moves += fromPrev;
                    Console.WriteLine($"Move: {fromPrev} Chips In {n - 1} To {i}");
                }
            }
        }

        // Correction Amount
        for (int i = 0; i < n; i++)
        {
            int diff = chips[i] - target;
            if (diff > 0)
            {
                // Chips In To Current Place > Average
                int toPrev = Math.Min(diff, chips[n - 1]);
                chips[i] -= toPrev;
                chips[n - 1] += toPrev;
                moves += toPrev;
                Console.WriteLine($"Correction: {toPrev} Chips In {i} To {n - 1}");
            }
            else if (diff < 0)
            {
                // Chips In To Current Place < Average
                int fromNext = Math.Min(-diff, chips[(i + 1) % n]);
                chips[i] += fromNext;
                chips[(i + 1) % n] -= fromNext;
                moves += fromNext;
                Console.WriteLine($"Correction: {fromNext} Chips In {(i + 1) % n} To {i}");
            }
        }

        // Finish
        Console.WriteLine("Result:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Possition {i}: {chips[i]} Chips");
        }

        return moves;
    }
}
