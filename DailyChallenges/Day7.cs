using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day7
    {
        private static string[] handleInput()
        {
            string[] inputs;

            string path = @"C:\Users\Kirtle\Documents\aoc\inputDay7.txt";
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                inputs = streamReader.ReadToEnd().Split("\r\n");
                return inputs;
            }
        }

        private static Dictionary<string, string[]> inputToRulesDictionary(string[] rules)
        {
            //shiny purple bags contain 2 posh silver bags, 3 striped silver bags, 5 shiny beige bags, 2 plaid chartreuse bags.
            Dictionary<string, string[]> bagRules = new Dictionary<string, string[]>();
            
            foreach (string rule in rules)
            {
                string[] bag = rule.Split(" contain ");
                //bag[1] holds info on what colors bag[0] can carry inside
                string[] bagsInside = regex.Replace(bag[1], "").Split(", ");
                string carryingBag = regex.Replace(bag[0], "");
                bagRules.Add(carryingBag, bagsInside);
            }

            return bagRules;
        }

        //excuse the terrible regex filter
        private static Regex regex = new Regex(@"\d.|[.]|.(bags)|.(bag)");
        
        public static void Part1()
        {
            Dictionary<string, string[]> bagRules = inputToRulesDictionary(handleInput());
            int bagContainingShinyGold = 0;
            foreach (KeyValuePair<string,string[]> rule in bagRules)
            {
                Queue<string> queue = new Queue<string>();
                queue.Enqueue(rule.Key);

                while (queue.Count != 0)
                {
                    string activeKey = queue.Dequeue();
                    if (bagRules[activeKey][0] == "no other") continue;
                    int shinyCount = bagRules[activeKey].Count(x => x == "shiny gold");

                    if (shinyCount == 0)
                        for (int i = 0; i < bagRules[activeKey].Length; i++)
                            queue.Enqueue(bagRules[activeKey][i]);
                    else if (shinyCount != 0)
                    { bagContainingShinyGold++; break; }
                }
            }

            Console.WriteLine($"The amount of bag colors than can contain at least one shiny gold bag are {bagContainingShinyGold}");
        }
    }
}