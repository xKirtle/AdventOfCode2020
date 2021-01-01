using System;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day5
    {
        private static int getSeatID(string seat)
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
            return seatID;
        }

        public static void Part1()
        {
            string[] seats = Program.handleInput(5);
            int highestSeatID = 0;
            
            foreach (string seat in seats)
            {
                int seatID = getSeatID(seat);
                
                if (highestSeatID < seatID)
                    highestSeatID = seatID;
            }

            Console.WriteLine($"The highest seat ID is {highestSeatID}");
        }

        public static void Part2()
        {
            bool[] seatExists = new bool[128 * 8];

            string[] seats = Program.handleInput(5);
            foreach (string seat in seats)
            {
                int seatID = getSeatID(seat);
                seatExists[seatID] = true;
            }

            int emptySeatID = 0;
            bool foundTrue = false;
            for (int i = 0; i < seatExists.Length; i++)
            {
                if (seatExists[i]) foundTrue = true;

                if (!seatExists[i] && foundTrue)
                { emptySeatID = i; break; }
            }

            Console.WriteLine($"The empty seat is {emptySeatID}");
        }
    }
}