using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmyLunch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSoldiers = int.Parse(Console.ReadLine());
            var soldiers = Console.ReadLine().Split(' ');
            var chowOrder = new Dictionary<string, List<string>>();
            foreach (var soldier in soldiers)
            {
                char soldierRank = soldier[0];
                if (soldierRank == 'S')
                {
                    if (!chowOrder.ContainsKey("Sergeant"))
                    {
                        chowOrder.Add("Sergeant", new List<string>());
                    }
                    chowOrder["Sergeant"].Add(soldier);
                }
                else if (soldierRank == 'C')
                {
                    if (!chowOrder.ContainsKey("Corporal"))
                    {
                        chowOrder.Add("Corporal", new List<string>());
                    }
                    chowOrder["Corporal"].Add(soldier);
                }
                else
                {
                    if (!chowOrder.ContainsKey("Private"))
                    {
                        chowOrder.Add("Private", new List<string>());
                    }
                    chowOrder["Private"].Add(soldier);
                }
            }
            var output = new StringBuilder();
            output.Append(string.Join(" ", chowOrder["Sergeant"]));
            output.Append(" ");
            output.Append(string.Join(" ", chowOrder["Corporal"]));
            output.Append(" ");
            output.Append(string.Join(" ", chowOrder["Private"]));
            Console.WriteLine(output.ToString());
        }
    }
}