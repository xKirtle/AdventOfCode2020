using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day11
    {
        public static void Part1()
        {
            string[] input = Program.handleInput(11, false);

            char getSitState(int i, int j, string[] input)
            {
                if (i < 0 || i >= input.Length || j < 0 || j >= input[i].Length)
                    return 'X';

                return input[i][j];
            }
            
            string occupiedAdjacentSits(int i, int j, string[] input)
            {
                char[] sits = new char[]
                {
                    //TopLeft, TopMid, TopRight, MidLeft, MidRight, BottomLeft, BottomMid, BottomRight
                    getSitState(i - 1, j - 1, input), getSitState(i + 0, j - 1, input), getSitState(i + 1, j - 1, input),
                    getSitState(i - 1, j + 0, input), getSitState(i + 1, j + 0, input),
                    getSitState(i - 1, j + 1, input), getSitState(i + 0, j + 1, input), getSitState(i + 1, j + 1, input)
                };
                
                return new string(sits);
            }

            int countOccupiedAdjacentSits(int i, int j, string[] input)
            {
                string sits = occupiedAdjacentSits(i, j, input);

                int count = 0;
                foreach (char c in sits)
                    if (c == '#') count++;

                return count;
            }

            string replaceCharAtIndex(string input, int index, char c)
            {
                char[] chars = input.ToCharArray();
                chars[index] = c;
                return new string(chars);
            }
            
            string[] newLayout = (string[])input.Clone();

            while (true)
            {
                for (int i = 0; i < input.Length; i++)
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == 'L' && countOccupiedAdjacentSits(i, j, input) == 0)
                        newLayout[i] = replaceCharAtIndex(newLayout[i], j, '#');
                    else if (input[i][j] == '#' && countOccupiedAdjacentSits(i, j, input) >= 4)
                        newLayout[i] = replaceCharAtIndex(newLayout[i], j, 'L');
                }
                
                if (!Enumerable.SequenceEqual(input, newLayout))
                    input = (string[]) newLayout.Clone();
                else break;
            }

            int count = 0;
            for (int i = 0; i < input.Length; i++)
            for (int j = 0; j < input[i].Length; j++)
                if (input[i][j] == '#') count++;

            Console.WriteLine($"After the seating rules, there are {count} seats filled");
        }
    }
}