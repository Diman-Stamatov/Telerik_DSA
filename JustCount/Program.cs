
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace JustCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lowerDictionary = new Dictionary<char, int>();
            var upperDictionary = new Dictionary<char, int>();
            var symbolDictionary = new Dictionary<char, int>();

            char[] input = Console.ReadLine().ToCharArray();
            foreach (var character in input)
            {
                if ((int)character > 96 && (int)character < 123)
                {
                    if (!lowerDictionary.ContainsKey(character)) 
                    {
                        lowerDictionary.Add(character, 0);
                    }
                    lowerDictionary[character]++;
                }
                else if ((int)character > 64 && (int)character < 91)
                {
                    if (!upperDictionary.ContainsKey(character))
                    {
                        upperDictionary.Add(character, 0);
                    }
                    upperDictionary[character]++;
                }
                else
                {
                    if (!symbolDictionary.ContainsKey(character))
                    {
                        symbolDictionary.Add(character, 0);
                    }
                    symbolDictionary[character]++;
                }
            }
            var sortList = new List<KeyValuePair<char, int>>();
            var printList = new List<KeyValuePair<char, int>>();
            int maxCount = 0;
            if (symbolDictionary.Count ==0)
            {
                Console.WriteLine("-");
            }
            else
            {
                sortList = symbolDictionary.OrderByDescending(pair => pair.Value).ToList();
                maxCount = sortList[0].Value;
                if (sortList.Count == 1)
                {
                    Console.WriteLine($"{sortList[0].Key} {sortList[0].Value}");
                }
                else
                {
                    foreach (var pair in sortList)
                    {
                        if (pair.Value < maxCount)
                        {
                            break;
                        }
                        printList.Add(pair);
                    }
                    printList = printList.OrderBy(pair => pair.Key).ToList();
                    Console.WriteLine($"{printList[0].Key} {printList[0].Value}");
                }
                
            }
            sortList.Clear();
            printList.Clear();
            maxCount = 0;

            if (lowerDictionary.Count == 0)
            {
                Console.WriteLine("-");
            }
            else
            {
                sortList = lowerDictionary.OrderByDescending(pair => pair.Value).ToList();
                maxCount = sortList[0].Value;
                if (sortList.Count == 1)
                {
                    Console.WriteLine($"{sortList[0].Key} {sortList[0].Value}");
                }
                else
                {
                    foreach (var pair in sortList)
                    {
                        if (pair.Value < maxCount)
                        {
                            break;
                        }
                        printList.Add(pair);
                    }
                    printList = printList.OrderBy(pair => pair.Key).ToList();
                    Console.WriteLine($"{printList[0].Key} {printList[0].Value}");
                }

            }
            sortList.Clear();
            printList.Clear();
            maxCount = 0;

            if (upperDictionary.Count == 0)
            {
                Console.WriteLine("-");
            }
            else
            {
                sortList = upperDictionary.OrderByDescending(pair => pair.Value).ToList();
                maxCount = sortList[0].Value;
                if (sortList.Count == 1)
                {
                    Console.WriteLine($"{sortList[0].Key} {sortList[0].Value}");
                }
                else
                {
                    foreach (var pair in sortList)
                    {
                        if (pair.Value < maxCount)
                        {
                            break;
                        }
                        printList.Add(pair);
                    }
                    printList = printList.OrderBy(pair => pair.Key).ToList();
                    Console.WriteLine($"{printList[0].Key} {printList[0].Value}");
                }

            }
            sortList.Clear();
            printList.Clear();
            maxCount = 0;

        }
    }
}