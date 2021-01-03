using System;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Day7.Part1();
        }
        
        public static string[] handleInput(int day, bool linux = true)
        {
            string[] inputs;

            string path = "";
            if (linux)
                path = $"/home/kirtle/Documents/GitHub/AdventOfCode/Input/InputDay{day}.txt";
            else
                path = $"C:/Users/Kirtle/Documents/GitHub/AdventOfCode/AdventOfCode/Input/InputDay{day}.txt";
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                inputs = streamReader.ReadToEnd().Split("\n");
                return inputs;
            }
        }
    }
}