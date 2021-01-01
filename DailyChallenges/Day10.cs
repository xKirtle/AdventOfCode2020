using System;
using System.Linq;

namespace AdventOfCode
{
    public class Day10
    {
        public static void Part1()
        {
            int[] input = Program.handleInput(10).Select(int.Parse).ToArray();
            Array.Sort(input);

            //difference of 3 starts with 1 since device has a joltage adapater +3 of max adapter
            int[] difference = new int[] {0, 1};
            //difference between power outlet (0) and first adapter
            difference[input[0] == 1 ? 0 : 1]++;
            for (int i = 0; i < input.Length - 1; i++)
            {
                int diff = input[i + 1] - input[i];
                if (diff == 1)
                    difference[0]++;
                else if (diff == 3)
                    difference[1]++;
            }

            Console.WriteLine($"The answer is {difference[0] * difference[1]}");
        }

        public static void Part2()
        {
            //Lookup dynamic programming?
            //https://www.reddit.com/r/adventofcode/comments/ka8z8x/2020_day_10_solutions/gfzp6rt?utm_source=share&utm_medium=web2x&context=3
            //https://pastebin.com/CnVj575V
        }
    }
}