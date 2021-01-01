using System;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Day9.Part2();
        }
        
        public static string[] handleInput(int day)
        {
            string[] inputs;

            string path = $"/home/kirtle/Documents/GitHub/AdventOfCode/Input/InputDay{day}.txt";
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                inputs = streamReader.ReadToEnd().Split("\n");
                return inputs;
            }
        }
    }
}