using System.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static GottaCatchEmAll.Program;


namespace GottaCatchEmAll
{


    internal class Program
    {
        public class Pokemon
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public int Power { get; set; }
            public int Position { get; set; }


            public Pokemon(string name, string type, int power, int position)
            {
                this.Name = name;
                this.Type = type;
                this.Power = power;
                this.Position = position;
            }

            public override string ToString()
            {
                return $"{this.Name}({this.Power})";
            }
        }
        static Dictionary<string, List<Pokemon>> typeDictionary = new Dictionary<string, List<Pokemon>>();
        static List<Pokemon> pokemons = new List<Pokemon>();
        static Dictionary<int, Pokemon> rankDictionary = new Dictionary<int, Pokemon>();
        static StringBuilder output = new StringBuilder();
        static List<Pokemon> typeList = new List<Pokemon>();

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
            var newMon = new Pokemon(name, type, power, position);

            if (position != pokemons.Count + 1)
            {
                /*(BinarySearch(pokemons, p => p.Position, position), pokemon)*/
               /* pokemons.Insert(BinarySearch(pokemons, p => p.Position, position), newMon;*/
                foreach (var mon in pokemons)
                {
                    if (mon.Position >= position)
                    {
                        mon.Position++;
                    }
                }
            }
            pokemons.Add(newMon);

            if (!typeDictionary.ContainsKey(type))
            {
                typeDictionary.Add(type, new List<Pokemon>());
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
            typeList = typeDictionary[type].OrderBy(mon => mon.Position).Take(5)
                .OrderBy(mon => mon.Name).ThenByDescending(mon => mon.Power).ToList();

            output.Append(string.Join("; ", typeList));
            output.AppendLine();
            typeList.Clear();

        }
        public static void Ranklist(string[] input)
        {
            int startRank = int.Parse(input[1]);
            int endRank = int.Parse(input[2]);

            foreach (var mon in pokemons)
            {
                rankDictionary.Add(mon.Position, mon);
            }
            int counter = 1;
            for (int index = startRank; index <= endRank; index++)
            {
                output.Append($"{rankDictionary[index].Position}. {rankDictionary[index]}");
                if (index != endRank)
                {
                    output.Append("; ");
                }
                counter++;
            }
            output.AppendLine();
            rankDictionary.Clear();

        }
    }
}