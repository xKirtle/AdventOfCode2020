using System;

namespace AdventOfCode
{
    public static class Day3
    {
        static int findTreesInPath(int rightMove, int downMove)
        {
            string[] input = Program.handleInput(3);
            int maxRightMoves = input[0].Length;
            int currRightMove = 0;
            int treesEncountered = 0;
            for (int i = 0; i < input.Length; i += downMove)
            {
                if (input[i][currRightMove] == '#')
                    treesEncountered++;

                currRightMove = (currRightMove + rightMove) % maxRightMoves;
            }

            return treesEncountered;
        }

        public static void Part1()
        {
            int treesEncountered = findTreesInPath(3, 1);
            Console.WriteLine($"Number of trees encountered is {treesEncountered}");
        }

        public static void Part2()
        {
            int[][] movements = new int[][]
            {
                new int[] {1, 1}, new int[] {3, 1}, new int[] {5, 1}, new int[] {7, 1}, new int[] {1, 2}
            };

            int treesEncountered = 1;
            for (int i = 0; i < movements.Length; i++)
                treesEncountered *= findTreesInPath(movements[i][0], movements[i][1]);

             Console.WriteLine($"Number of trees encountered is {treesEncountered}");
        }
    }
}