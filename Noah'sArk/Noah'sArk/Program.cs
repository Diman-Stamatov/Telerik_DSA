
 using System;
 using System.Collections.Generic;


namespace Noah_sArk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());
            var animals = new Dictionary<string, int>();
            for (int input = 0; input < inputs; input++)
            {
                string animal = Console.ReadLine();
                if (animals.ContainsKey(animal) == false)
                {
                    animals.Add(animal, 1);
                }
                else
                {
                    animals[animal]++;
                }
            }
            var list = new SortedList<string, int>(animals);
            foreach (var animal in list)
            {
                string species = animal.Key;
                int number = animal.Value;
                string even;
                    if (number % 2 == 0)
                {
                    even = "Yes";
                }
                else
                {
                    even = "No";
                }
                Console.WriteLine(species + " " + number + " " + even);
            }
        }
    }
}