using System;

namespace AdventOfCode
{
    public class Day9
    {
        private static long FindInvalidNumber(string[] input)
        {
            int index = 25;

            for (int i = 0; i < input.Length; i++)
            {
                bool flag = false;
                for (int j = i; j < i + 25; j++)
                {
                    if (j >= input.Length || flag) break;
                    for (int k = i; k < i + 25; k++)
                    {
                        if (k >= input.Length || flag) break;
                        if (long.Parse(input[j]) + long.Parse(input[k]) == long.Parse(input[index]))
                            flag = true;
                    }
                }
                
                //Didn't find any matches
                if (!flag) break;
                index++;
            }

            return long.Parse(input[index]);
        }
        
        public static void Part1()
        {
            string[] input = Program.handleInput(9);
            long result = FindInvalidNumber(input);

            Console.WriteLine($"First number that is wrong is {result}");
        }

        public static void Part2()
        {
            string[] input = Program.handleInput(9);
            long invalidNumber = FindInvalidNumber(input);
            int[] indexes = new int[2];
            
            //Find sum of contiguous numbers that add up to the invalid number
            //Then sum smallest and biggest number in that contiguous set => answer

            for (int i = 0; i < input.Length; i++)
            {
                int index = i;
                long result = 0;
                while (true)
                {
                    result += long.Parse(input[index]);
                    if (result >= invalidNumber || ++index >= input.Length) break;
                }

                if (result == invalidNumber)
                {
                    indexes = new int[] {i, index};
                    break;
                }
            }

            long[] minMax = new long[] {long.Parse(input[indexes[0]]), long.Parse(input[indexes[0]])};
            for (int i = indexes[0]; i < indexes[1]; i++)
            {
                long curr = long.Parse(input[i]);
                if (curr < minMax[0])
                    minMax[0] = curr;

                if (curr > minMax[1])
                    minMax[1] = curr;
            }

            Console.WriteLine($"The encrytion weakness is {minMax[0] + minMax[1]}");
        }
    }
}