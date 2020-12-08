using System;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public class Day5
    {
        private static string[] handleInput()
        {
            string[] seats;

            string path = @"C:\Users\Kirtle\Documents\aoc\inputDay5.txt";
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                seats = streamReader.ReadToEnd().Split("\r\n");
                return seats;
            }
        }

        public static void Part1()
        {
            string[] seats = handleInput();
            int highestSeatID = 0;
            
            foreach (string seat in seats)
            {
                int row;
                int column;
                int seatID;
                
                int[] rowRange = new int[] {0, 127};
                for (int i = 0; i < 7; i++)
                {
                    int difference = ((rowRange[1] - rowRange[0]) + 1) / 2;
                    int index = seat[i] == 'F' ? 1 : 0;
                    rowRange[index] += index == 1 ? -difference : difference;
                }

                row = rowRange[0];
                
                int[] columnRange = new int[] {0, 7};
                for (int i = 7; i < 10; i++)
                {
                    int difference = ((columnRange[1] - columnRange[0]) + 1) / 2;
                    int index = seat[i] == 'L' ? 1 : 0;
                    columnRange[index] += index == 1 ? -difference : difference;
                }

                column = columnRange[0];

                seatID = row * 8 + column;
                
                if (highestSeatID < seatID)
                    highestSeatID = seatID;
            }

            Console.WriteLine($"The highest seat ID is {highestSeatID}");
        }
    }
}