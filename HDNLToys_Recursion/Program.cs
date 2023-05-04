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

        public class MyComparer : IComparer<Pokemon>
        {
            public int Compare(Pokemon x, Pokemon y)
            {
                if (x.Position < y.Position)
                {
                    return 1;
                }
                else if (x.Position == y.Position)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
        }
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
        static Dictionary<string, SortedSet<Pokemon>> typeDictionary2 = new Dictionary<string, SortedSet<Pokemon>>();
        static StringBuilder output = new StringBuilder();
        static List<Pokemon> leaderBoard = new List<Pokemon>();

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

            leaderBoard.Insert(position - 1, newMon);

            if (!typeDictionary2.ContainsKey(type))
            {
                typeDictionary2.Add(type, new SortedSet<Pokemon>(new MyComparer()));
            }
            typeDictionary2[type].Add(newMon);

            output.Append($"Added pokemon {name} to position {position}");
            output.AppendLine();
        }
        public static void Find(string[] input)
        {
            string type = input[1];
            output.Append($"Type {type}: ");
            if (typeDictionary2.ContainsKey(type))
            {
                output.Append(string.Join("; ", typeDictionary2[type]                    
                    .OrderBy(mon => mon.Name).ThenByDescending(mon => mon.Power).Take(5)));

            }
            output.AppendLine();

        }
        public static void Ranklist(string[] input)
        {
            int startRank = int.Parse(input[1]);
            int endRank = int.Parse(input[2]);

            for (int index = startRank - 1; index <= endRank - 1; index++)
            {
                output.Append($"{index + 1}. {leaderBoard[index].ToString()}; ");
            }
            output.Remove(output.Length - 2, 2);
            output.AppendLine();

        }
    }
}