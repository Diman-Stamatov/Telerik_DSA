﻿using System.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;


namespace GottaCatchEmAll
{


    internal class Program
    {
        public class Pokemon:IComparable<Pokemon>


        {
            public string Name { get; set; }
            public string Type { get; set; }
            public int Power { get; set; }



            public Pokemon(string name, string type, int power)
            {
                this.Name = name;
                this.Type = type;
                this.Power = power;

            }

            public override string ToString()
            {
                return $"{this.Name}({this.Power})";
            }

            int IComparable<Pokemon>.CompareTo(Pokemon other)
            {
               var result = this.Name.CompareTo(other.Name);
                if (result==0)
                {
                    result = other.Power.CompareTo(this.Power);
                }
                return result;
            }
        }
        static Dictionary<string, SortedSet<Pokemon>> typeDictionary = new Dictionary<string, SortedSet<Pokemon>>();
        static List<Pokemon> pokemons = new List<Pokemon>();

        static StringBuilder output = new StringBuilder();
        

        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine().Split(' ');
                string command = input[0];
                if (command == "end")
                {
                    break;
                }
                switch (command)
                {
                    case "add":
                        Add(input);
                        break;
                    case "find":
                        Find(input);
                        break;
                    case "ranklist":
                        Ranklist(input);
                        break;
                }
            }
            Console.WriteLine(output.ToString());

        }
        public static void Add(string[] input)
        {
            string name = input[1];
            string type = input[2];
            int power = int.Parse(input[3]);
            int position = int.Parse(input[4]);
            var newMon = new Pokemon(name, type, power);
            if (position != pokemons.Count + 1)
            {
                pokemons.Insert(position - 1, newMon);
            }
            else
            {
                pokemons.Add(newMon);
            }


            if (!typeDictionary.ContainsKey(type))
            {
                typeDictionary.Add(type, new SortedSet<Pokemon>());
            }
            typeDictionary[type].Add(newMon);

            output.Append($"Added pokemon {name} to position {position}");
            output.AppendLine();
        }
        public static void Find(string[] input)
        {
            string type = input[1];
            output.Append($"Type {type}: ");
            if (!typeDictionary.ContainsKey(type))
            {
                
                output.AppendLine();
                return;
            }
            


            output.Append(string.Join("; ", typeDictionary[type].Take(5)));
            output.AppendLine();
            

        }
        public static void Ranklist(string[] input)
        {
            int startRank = int.Parse(input[1]);
            int endRank = int.Parse(input[2]);



            for (int index = startRank - 1; index < endRank; index++)
            {
                output.Append($"{index + 1}. {pokemons[index]}");
                if (index != endRank - 1)
                {
                    output.Append("; ");
                }
            }
            output.AppendLine();

        }
    }
}