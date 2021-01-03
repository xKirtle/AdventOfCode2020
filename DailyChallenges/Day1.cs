using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace AdventOfCode
{
    public static class Day1
    {
        public static void Part1()
        {
            int[] entries = Program.handleInput(1).Select(int.Parse).ToArray();
            
            int[] indices = new int[2];
            for (int i = 0; i < entries.Length; i++)
            for (int j = 0; j < entries.Length; j++)
                if (entries[i] + entries[j] == 2020)
                    indices = new int[] {i, j};

            Console.WriteLine($"Numbers are {entries[indices[0]]} and {entries[indices[1]]}");
            Console.WriteLine($"Product of both numbers is {entries[indices[0]] * entries[indices[1]]}");
        }

        public static void Part2()
        {
            int[] entries = Program.handleInput(1).Select(int.Parse).ToArray();
            int[] entriesClone = (int[]) entries.Clone();
            Array.Sort(entriesClone);
            find3Numbers(entriesClone, 2020);
            
            //Loop over sorted array and fix 2 points (i+1 and n-1) on top of arr[i]
            //If sum of 3 > target, reduce index of the right most fixed point (n-1)
            //If sum of 3 < target, increase index of the left most fixed point (i+1)
            //If sum of 3 = target, triplet found
            
            bool find3Numbers(int[] arr, int expectedResult)
            {
                int leftPoint, rightPoint;
                for (int i = 0; i < arr.Length - 2; i++)
                {
                    leftPoint = i + 1; // index of the first element, excluding i 
                    rightPoint = arr.Length - 1; // index of the last element , excluding i
                    while (leftPoint < rightPoint)
                    {
                        int sumOfIndices = arr[i] + arr[leftPoint] + arr[rightPoint];
                        if (sumOfIndices == expectedResult)
                        {
                            Console.WriteLine($"Numbers are {arr[i]}, {arr[leftPoint]} and {arr[rightPoint]}");
                            Console.WriteLine($"Product of 3 numbers is {arr[i] * arr[leftPoint] * arr[rightPoint]}");
                            return true;
                        }
                        else if (sumOfIndices < expectedResult)
                            leftPoint++;
                        else // sumOfIndices > sum 
                            rightPoint--;
                    }
                }

                return false;
            }
        }
    }
}