using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day4
    {
        private static string[] handleInput()
        {
            string[] passports;

            string path = @"C:\Users\Kirtle\Documents\aoc\input.txt";
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                passports = streamReader.ReadToEnd().Split("\r\n\r\n");
                return passports;
            }
        }

        public static void Part1()
        {
            string[] passports = handleInput();
            string[] requiredFields = {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

            int validPassports = 0;
            foreach (string passport in passports)
            {
                for (int i = 0; i < requiredFields.Length; i++)
                {
                    if (!passport.Contains(requiredFields[i])) break;

                    if (i == requiredFields.Length - 1)
                        validPassports++;
                }
            }

            Console.WriteLine($"The number of valid passports is {validPassports}");
        }

        public static void Part2()
        {
            string[] passports = handleInput();
            string[] requiredFields = {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

            int validPassports = 0;
            foreach (string passport in passports)
            {
                for (int i = 0; i < requiredFields.Length; i++)
                    if (!passport.Contains(requiredFields[i]))
                        break;

                string[] passportFields = passport.Split(new string[] {" ", "\r\n"}, StringSplitOptions.None);

                bool validPassport = true;
                for (int i = 0; i < passportFields.Length; i++)
                {
                    if (!validPassport) break;
                    string[] fieldInfo = passportFields[i].Split(":");
                    switch (fieldInfo[0])
                    {
                        case "byr":
                            int byr = int.Parse(fieldInfo[1]);
                            if (byr < 1920 || byr > 2002) validPassport = false;
                            break;
                        case "iyr":
                            int iyr = int.Parse(fieldInfo[1]);
                            if (iyr < 2010 || iyr > 2020) validPassport = false;
                            break;
                        case "eyr":
                            int eyr = int.Parse(fieldInfo[1]);
                            if (eyr < 2020 || eyr > 2030) validPassport = false;
                            break;
                        case "hgt":
                            string height = fieldInfo[1];
                            int hgt = int.Parse(height.Replace("cm", "").Replace("in", ""));
                            if (height.Contains("cm") && (hgt < 150 || hgt > 193)) validPassport = false;
                            else if (height.Contains("in") && (hgt < 59 || hgt > 76)) validPassport = false;
                            break;
                        case "hcl":
                            string hcl = fieldInfo[1].ToLower();
                            if (hcl[0] != '#' || hcl.Length != 7)
                            { validPassport = false; break; }

                            bool hclValid = true;
                            for (int j = 1; j < hcl.Length; j++)
                                if (Char.IsDigit(hcl[j]) && hcl[j] > 'f')
                                    hclValid = false;
                            if (!hclValid) validPassport = false;
                            break;
                        case "ecl":
                            string[] possibleEcl = new string[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
                            string ecl = fieldInfo[1].ToLower();
                            bool eclValid = false;
                            for (int j = 0; j < possibleEcl.Length; j++)
                                if (ecl == possibleEcl[j])
                                    eclValid = true;

                            if (!eclValid) validPassport = false;
                            break;
                        case "pid":
                            string pid = fieldInfo[1];
                            if (pid.Length != 9) validPassport = false;
                            break;
                        default:
                            break;
                    }
                }

                if (validPassport)
                    validPassports++;
            }

            Console.WriteLine($"The number of valid passports is {validPassports}");
        }
    }
}