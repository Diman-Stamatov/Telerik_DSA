using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTables.InClassActivity
{
    public class HashTableTasks
    {
        /// <summary>
        /// Counts the number of occurrences of a each word in a collection.
        /// </summary>
        /// <param name="words">A collection of words.</param>
        /// <returns>A dictionary of occurrences by word.</returns>
        public static Dictionary<string, int> CountOccurences(string[] words)
        {
            var dictionary = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, 0);
                }
                dictionary[word]++;
            }
            return dictionary;
        }

        /// <summary>
        /// Return the indices of the first two numbers that sum to a given number.
        /// </summary>
        /// <param name="numbers">Collection of numbers</param>
        /// <param name="sum">Target sum</param>
        /// <returns>An array containing the indices of the first two numbers that produce the target sum.</returns>
        public static int[] TwoSum(int[] numbers, int sum)
        {
            var dictionary = new Dictionary<int, int>();
            for (int index = 0; index < numbers.Length; index++)
            {
                int remainder = sum - numbers[index];
                if (!dictionary.ContainsKey(remainder))
                {
                    dictionary.Add(numbers[index], index);
                }
                else
                {
                    return new int[] { dictionary[remainder], index };
                }
                
            }
            
            
            return new int[] {-1,-1};
        }

        /// <summary>
        /// Counts how many coins are special.
        /// </summary>
        /// <param name="coins">Coins to check.</param>
        /// <param name="catalogue">The catalogue of special coins.</param>
        /// <returns>The count of special coins</returns>
        public static int SpecialCoins(string coins, string catalogue)
        {
            var set = new HashSet<char>(catalogue.ToCharArray());
            int count = 0;
            foreach (var character in coins)
            {
                if (set.Contains(character))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Determines whether two strings are isomorphic. 
        /// Two strings are considered isomorphic if each character from the first string can map to a character in the seconds string.
        /// </summary>
        /// <param name="s1">The first string.</param>
        /// <param name="s2">The second string.</param>
        /// <returns>True if the two strings are isomorphic; otherwise, false.</returns>
        public static bool AreIsomorphic(string s1, string s2)
        {
            if (s1.Length !=s2.Length)
            {
                return false;
            }
            var dictionary = new Dictionary<char, char>();
            var dictioanryTwo = new Dictionary<char, char>();
            for (int index = 0; index < s1.Length; index++)
            {
                if (!dictionary.TryAdd(s1[index], s2[index]))
                {
                    if (dictionary[s1[index]] != s2[index])
                    {
                        return false;
                    }
                }
                if (!dictioanryTwo.TryAdd(s2[index], s1[index]))
                {
                    if (dictioanryTwo[s2[index]] != s1[index])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
