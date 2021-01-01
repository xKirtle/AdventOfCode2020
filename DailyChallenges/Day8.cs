using System;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public class Day8
    {
        private static string[] handleInput()
        {
            string[] inputs;

            string path = "/home/kirtle/Documents/GitHub/AdventOfCode/Input/InputDay8.txt";
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                inputs = streamReader.ReadToEnd().Split("\n");
                return inputs;
            }
        }

        public static void Part1()
        {
            string[] input = handleInput();
            bool[] executed = new bool[input.Length];
            int accumulator = 0;
            int index = 0;

            while (true)
            {
                int newIndex = ExecuteInstruction(index);
                if (newIndex == -1)
                    break;
                else
                    index = newIndex;

                if (index >= input.Length)
                    break;
            }

            Console.WriteLine($"The accumulator value is {accumulator}");
            

            int ExecuteInstruction(int index)
            {
                string[] command = input[index].Split(" ");
                string type = command[0];
                int value = int.Parse(command[1]);

                if (executed[index])
                    return -1;
                executed[index] = true;

                if (type == "acc")
                    accumulator += value;
                else if (type == "jmp")
                    return index + value;

                return index + 1;
            }
        }

        public static void Part2()
        {
            string[] input = handleInput();
            bool[] executed = new bool[input.Length];
            int accumulator = 0;
            int index = 0;
            Tuple<string[], int> lastCommand = new Tuple<string[], int>(null, 0);
            
            while (true)
            {
                int newIndex = ExecuteInstruction(index);
                if (newIndex == -1)
                    break;
                else
                    index = newIndex;

                if (index >= input.Length)
                    break;
            }

            Console.WriteLine($"{lastCommand.Item1[0]}, {lastCommand.Item1[1]}, {lastCommand.Item2}");

            if (lastCommand.Item1[0] == "jmp")
                index = lastCommand.Item2 + 1;
            //swap nop to jmp?

            while (true)
            {
                int newIndex = ExecuteInstruction(index);
                if (newIndex == -1)
                    break;
                else
                    index = newIndex;

                if (index >= input.Length)
                    break;
            }

            Console.WriteLine(accumulator);
            
            int ExecuteInstruction(int index)
            {
                string[] command = input[index].Split(" ");
                string type = command[0];
                int value = int.Parse(command[1]);

                if (executed[index])
                    return -1;
                executed[index] = true;
                lastCommand = new Tuple<string[], int>(command, index);
                
                if (type == "acc")
                    accumulator += value;
                else if (type == "jmp")
                    return index + value;

                return index + 1;
            }
        }
    }
}