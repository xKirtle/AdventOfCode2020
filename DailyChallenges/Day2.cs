using System;

namespace AdventOfCode
{
    public static class Day2
    {
        public static void Part1()
        {
            string[] input = Program.handleInput(2);
            int validCount = 0;
            foreach (string str in input)
            {
                string[] strSplit = str.Split(' ');

                string[] rangeValues = strSplit[0].Replace('-', ' ').Split(' ');
                int[] minMax = new int[] {int.Parse(rangeValues[0]), int.Parse(rangeValues[1])};
                char minMaxChar = strSplit[1][0]; //.Replace(':', ' ')[0];
                string password = strSplit[2];

                int charInPasswordCount = 0;
                for (int i = 0; i < password.Length; i++)
                    if (password[i] == minMaxChar)
                        charInPasswordCount++;

                if (charInPasswordCount >= minMax[0] && charInPasswordCount <= minMax[1])
                    validCount++;
            }

            Console.WriteLine($"Number of valid passwords are {validCount}");
        }

        public static void Part2()
        {
            string[] input = Program.handleInput(2);
            int validCount = 0;
            foreach (string str in input)
            {
                string[] strSplit = str.Split(' ');

                string[] rangeValues = strSplit[0].Replace('-', ' ').Split(' ');
                int[] minMax = new int[] {int.Parse(rangeValues[0]), int.Parse(rangeValues[1])};
                char minMaxChar = strSplit[1][0]; //.Replace(':', ' ')[0];
                string password = strSplit[2];

                if (password[minMax[0] - 1] == minMaxChar && password[minMax[1] - 1] != minMaxChar ||
                    password[minMax[0] - 1] != minMaxChar && password[minMax[1] - 1] == minMaxChar)
                    validCount++;
            }

            Console.WriteLine($"Number of valid passwords are {validCount}");
        }
    }
}