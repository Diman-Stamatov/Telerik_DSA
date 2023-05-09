using System;
using System.Collections.Generic;
using System.Linq;

namespace InHomeActivity.Set
{
    class Program
    {
        static void Main()
        {
            var collection1 = new int[] { 1, 3, 5, 7, 9 };
            var collection2 = new int[] { 2, 3, 4, 6 };
            var difference = Difference(collection1, collection2);
            Console.WriteLine(string.Join(',', difference)); // 1,5,7,9



        }

        static bool AreAllElementsUnique<T>(ICollection<T> collection)
        {
            var hashSet = new HashSet<T>();
            foreach (var item in collection)
            {
                if (!hashSet.Add(item))
                {
                    return false;
                }
            }
            return true;
        }
        static bool AreAllElementsUnique<T>(IEnumerable<T> collection)
        {
            var hashSet = new HashSet<T>(collection);
            if (hashSet.Count != collection.Count())
            {
                return false;
            }
            return true;
        }
        static IEnumerable<T> Distinct<T>(IEnumerable<T> collection)
        {
            var hashSet = new HashSet<T>(collection);
            return hashSet.ToList();
        }
        static IEnumerable<T> Union<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            var hashSet = new HashSet<T>(collection1);
            hashSet.UnionWith(collection2);
            return hashSet.ToList();
        }
        static IEnumerable<T> Intersect<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            var hashSet = new HashSet<T>(collection1);
            var hashSetTwo = new HashSet<T>(collection2);
            foreach (var item in hashSet)
            {
                if (!hashSetTwo.Contains(item))
                {
                    hashSet.Remove(item);
                }
            }
            return hashSet.ToList();
        }
        static IEnumerable<T> Difference<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            var hashOne = new HashSet<T>(collection1);
            var hashTwo = new HashSet<T>(collection2);
            foreach (var item in hashOne)
            {
                if (hashTwo.Contains(item))
                {
                    hashOne.Remove(item);
                }
            }
            return hashOne.ToList();
        }
    }
}
