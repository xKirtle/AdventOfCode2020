using System;
using System.IO;
using System.Text;
using AdventOfCode.DailyChallenges;

namespace AdventOfCode {
    class Program {
        static void Main (string[] args) {

        }

        public static string[] handleInput (int day, bool linux = false) {
            string[] inputs;

            string path = "";
            if (linux)
                path = $"/home/kirtle/Documents/GitHub/AdventOfCode/Input/InputDay{day}.txt";
            else
                path = $"C:/Users/PC/Documents/GitHub/AdventOfCode/Input/InputDay{day}.txt";
            using (StreamReader streamReader = new StreamReader (path, Encoding.UTF8)) {
                inputs = streamReader.ReadToEnd ().Split ("\n");
                return inputs;
            }
        }
    }
}