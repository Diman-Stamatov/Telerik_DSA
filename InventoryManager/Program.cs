using System.Text;
using System;
using System.Collections.Generic;

using System.Linq;



namespace InventoryManager
{
    internal class Program
    {
        public class Item
        {
            public string Name { get; }
            public double Price { get; }
            public string Type { get; }
            public Item(string name, double price, string type)
            {
                this.Name = name;
                this.Price = price;
                this.Type = type;
            }
        }
        public static bool ordered = false;
        public static StringBuilder output = new StringBuilder();
        static void Main(string[] args)
        {
            var database = new Dictionary<string, Item>();

            var typeDictionary = new Dictionary<string, List<Item>>();
            /*var typeDictionary = new Dictionary<string, List(Item>();*/
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');
                int commandLength = input.Length;
                if (commandLength == 1)
                {
                    break;
                }
                string command = "";
                if (commandLength == 4)
                {
                    string commandType = input[0];
                    if (commandType == "add")
                    {
                        command = "add";
                    }
                    else
                    {
                        command = "filter by type";
                    }
                }
                if (commandLength == 5)
                {
                    string commandType = input[3];
                    if (commandType == "from")
                    {
                        command = "filter by price from";
                    }
                    else
                    {
                        command = "filter by price to";
                    }
                }
                if (commandLength == 7)
                {
                    command = "filter by price from min to max";
                }

                switch (command)
                {
                    case "add":
                        AddCommand(input, database, typeDictionary);
                        break;
                    case "filter by type":
                        FilterByTypeCommand(input, database, typeDictionary);
                        break;
                    case "filter by price from":
                        FilterByPriceFromCommand(input, database);
                        break;
                    case "filter by price to":
                        FilterByPriceToCommand(input, database);
                        break;
                    case "filter by price from min to max":
                        FilterByPriceFromToCommand(input, database);
                        break;
                }

            }
            Console.WriteLine(output.ToString());

        }
        private static void AddCommand(string[] input, Dictionary<string, Item> database, Dictionary<string, List<Item>> typeDictionary)
        {
            string name = input[1];

            double price = double.Parse(input[2]);
            string type = input[3];
            var newItem = new Item(name, price, type);
            if (!database.ContainsKey(name))
            {
                if (!typeDictionary.ContainsKey(type))
                {
                    typeDictionary.Add(type, new List<Item>());
                    typeDictionary[type].Add(newItem);
                }
                else
                {
                    typeDictionary[type].Add(newItem);
                }

                database.Add(name, newItem);
                output.AppendLine($"Ok: Item {name} added successfully");
            }
            else
            {
                output.AppendLine($"Error: Item {name} already exists");
            }
        }
        private static void FilterByTypeCommand(string[] input, Dictionary<string, Item> database, Dictionary<string, List<Item>> typeDictionary)
        {
            string filterType = input[3];
            if (!typeDictionary.ContainsKey(filterType))
            {
                output.AppendLine($"Error: Type {filterType} does not exist");
                return;
            }
            var databaseToList = typeDictionary[filterType];

            var byTypeList = databaseToList.OrderBy(item => item.Price).ThenBy(item => item.Name).Take(10).ToList();

            int filteredCount = byTypeList.Count;
            output.Append("Ok: ");
            for (int index = 0; index < filteredCount; index++)
            {
                string itemName = byTypeList[index].Name;
                double itemPrice = byTypeList[index].Price;
                output.Append($"{itemName}({itemPrice:F2})");
                if (index != filteredCount - 1)
                {
                    output.Append(", ");
                }
            }
            output.AppendLine();

        }
        private static void FilterByPriceFromCommand(string[] input, Dictionary<string, Item> database)
        {

            double filterPrice = double.Parse(input[4]);
            var databaseToList = new List<Item>();
            foreach (var item in database)
            {
                databaseToList.Add(item.Value);
            }
            var byPriceList = databaseToList.Where(item => item.Price >= filterPrice)
                .OrderBy(item => item.Price).ThenBy(item => item.Name).ThenBy(item => item.Type).Take(10).ToList();

            int filteredCount = byPriceList.Count;
            if (filteredCount == 0)
            {
                output.AppendLine("Ok:");
                return;
            }

            output.Append("Ok: ");
            for (int index = 0; index < filteredCount; index++)
            {
                string itemName = byPriceList[index].Name;
                double itemPrice = byPriceList[index].Price;
                output.Append($"{itemName}({itemPrice:F2})");
                if (index != filteredCount - 1)
                {
                    output.Append(", ");
                }
            }
            output.AppendLine();

        }
        private static void FilterByPriceToCommand(string[] input, Dictionary<string, Item> database)
        {
            double filterPrice = double.Parse(input[4]);
            var databaseToList = new List<Item>();
            foreach (var item in database)
            {
                databaseToList.Add(item.Value);
            }
            var byPriceList = databaseToList.Where(item => item.Price <= filterPrice)
                .OrderBy(item => item.Price).ThenBy(item => item.Name).ThenBy(item => item.Type).Take(10).ToList();

            int filteredCount = byPriceList.Count;
            if (filteredCount == 0)
            {
                output.AppendLine("Ok:");
                return;
            }


            output.Append("Ok: ");
            for (int index = 0; index < filteredCount; index++)
            {
                string itemName = byPriceList[index].Name;
                double itemPrice = byPriceList[index].Price;
                output.Append($"{itemName}({itemPrice:F2})");
                if (index != filteredCount - 1)
                {
                    output.Append(", ");
                }
            }
            output.AppendLine();

        }
        private static void FilterByPriceFromToCommand(string[] input, Dictionary<string, Item> database)
        {
            double filterFromPrice = double.Parse(input[4]);
            double filterToPrice = double.Parse(input[6]);
            var databaseToList = new List<Item>();
            foreach (var item in database)
            {
                databaseToList.Add(item.Value);
            }
            var byPriceList = databaseToList.Where(item => item.Price >= filterFromPrice && item.Price <= filterToPrice)
                .OrderBy(item => item.Price).ThenBy(item => item.Name).ThenBy(item => item.Type).Take(10).ToList();

            int filteredCount = byPriceList.Count;
            if (filteredCount == 0)
            {
                output.AppendLine("Ok:");
                return;
            }


            output.Append("Ok: ");
            for (int index = 0; index < filteredCount; index++)
            {
                string itemName = byPriceList[index].Name;
                double itemPrice = byPriceList[index].Price;
                output.Append($"{itemName}({itemPrice:F2})");
                if (index != filteredCount - 1)
                {
                    output.Append(", ");
                }
            }
            output.AppendLine();

        }
    }
}