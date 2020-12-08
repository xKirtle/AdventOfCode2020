using System;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day6
    {
        private static string[] handleInput()
        {
            string[] inputs;

            string path = @"C:\Users\Kirtle\Documents\aoc\inputDay6.txt";
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                inputs = streamReader.ReadToEnd().Split("\r\n\r\n");
                return inputs;
            }
        }
        
        public static void Part1()
        {
            string[] inputs = handleInput();
            int sumOfTrueQuestions = 0;
            
            foreach (string input in inputs)
            {
                string[] groupInputs = input.Split(new string[] {" ", "\r\n"}, StringSplitOptions.None);
                
                //a 97 - z 122
                bool[] questionsSelected = new bool[26];
                
                for (int i = 0; i < groupInputs.Length; i++)
                for (int j = 0; j < groupInputs[i].Length; j++)
                        questionsSelected[groupInputs[i][j] % 123 - 97] = true;

                sumOfTrueQuestions += questionsSelected.Count(x => x == true);
            }

            Console.WriteLine($"The sum of questions everyone answered yes is {sumOfTrueQuestions}");
        }

        public static void Part2()
        {
            string[] inputs = handleInput();
            int sumOfTrueQuestions = 0;
            
            foreach (string input in inputs)
            {
                string[] groupInputs = input.Split(new string[] {" ", "\r\n"}, StringSplitOptions.None);
                
                //a 97 - z 122
                bool[] questionsSelected = new bool[26];
                
                for (int i = 0; i < groupInputs.Length; i++)
                for (int j = 0; j < groupInputs[i].Length; j++)
                    questionsSelected[groupInputs[i][j] % 123 - 97] = true;
                
                for (int i = 0; i < questionsSelected.Length; i++)
                {
                    char arrChar = (char) (i + 97);
                    if (groupInputs.Count(x => x.Contains(arrChar.ToString())) == groupInputs.Length)
                        sumOfTrueQuestions++;
                }
            }
            
            Console.WriteLine($"The sum of questions everyone in the same group answered yes is {sumOfTrueQuestions}");
        }
    }
}