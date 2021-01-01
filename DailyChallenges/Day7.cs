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
        private static Dictionary<string, Tuple<string[], int[]>> inputToRulesDictionary(string[] rules)
        {
            //shiny purple bags contain 2 posh silver bags, 3 striped silver bags, 5 shiny beige bags, 2 plaid chartreuse bags.
            Dictionary<string, Tuple<string[], int[]>> bagRules = new Dictionary<string, Tuple<string[], int[]>>();
            //excuse the terrible regex filter
            Regex regex = new Regex(@"\d.|[.]|.(bags)|.(bag)");
            Regex regex2 = new Regex(@"[^0-9]");

            foreach (string rule in rules)
            {
                string[] bag = rule.Split(" contain ");
                //Getting which colored bags are held inside the bag
                string[] bagsInside = regex.Replace(bag[1], "").Split(", ");

                //Getting the amount held by each bag
                string numberBags = regex2.Replace(bag[1], "");
                int[] amountOfBagsInside = new int[numberBags.Length];
                for (int i = 0; i < numberBags.Length; i++)
                    amountOfBagsInside[i] = int.Parse(numberBags[i].ToString());

                //Getting the name of the bag
                string carryingBag = regex.Replace(bag[0], "");

                Tuple<string[], int[]> bagRule = new Tuple<string[], int[]>(bagsInside, amountOfBagsInside);
                bagRules.Add(carryingBag, bagRule);
            }

            return bagRules;
        }

        public static void Part1()
        {
            Dictionary<string, Tuple<string[], int[]>> bagRules = inputToRulesDictionary(Program.handleInput(7));
            int bagContainingShinyGold = 0;
            foreach (KeyValuePair<string, Tuple<string[], int[]>> rule in bagRules)
            {
                Queue<string> queue = new Queue<string>();
                queue.Enqueue(rule.Key);

                while (queue.Count != 0)
                {
                    string activeKey = queue.Dequeue();
                    if (bagRules[activeKey].Item1[0] == "no other") continue;
                    int shinyCount = bagRules[activeKey].Item1.Count(x => x == "shiny gold");

                    if (shinyCount == 0)
                        for (int i = 0; i < bagRules[activeKey].Item1.Length; i++)
                            queue.Enqueue(bagRules[activeKey].Item1[i]);
                    else if (shinyCount != 0)
                    {
                        bagContainingShinyGold++;
                        break;
                    }
                }
            }

            Console.WriteLine($"The amount of bag colors than can contain at least one shiny gold bag are {bagContainingShinyGold}");
        }

        public static void Part2()
        {
            Dictionary<string, Tuple<string[], int[]>> bagRules = inputToRulesDictionary(Program.handleInput(7));
            int bagContainingShinyGold = 0;
            Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();
            Tuple<string, int> startingTuple = new Tuple<string, int>("shiny gold", 1);
            queue.Enqueue(startingTuple);

            int result = 0;
            while (queue.Count != 0)
            {
                var element = queue.Dequeue();
                string key = element.Item1;
                int valueMultiplier = element.Item2;
                for (int i = 0; i < bagRules[key].Item2.Length; i++)
                {
                    result += bagRules[key].Item2[i] * valueMultiplier;

                    var newQueueTuple = new Tuple<string, int>(bagRules[key].Item1[i], bagRules[key].Item2[i] * valueMultiplier);
                    queue.Enqueue(newQueueTuple);
                }
            }

            Console.WriteLine($"The shiny gold bag will carry exactly {result} bags inside it");
        }
    }
}