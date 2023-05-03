using System.Text;

namespace InventoryManager
{
    internal class Program
    {
        public class Item
        {
            public string Name { get; }
            public float Price { get; }
            public string Type { get; }
            public Item(string name, float price, string type)
            {
                this.Name = name;
                this.Price = price;
                this.Type = type;
            }
        }
        static void Main(string[] args)
        {
            var database = new Dictionary<string, Item>();
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
                        AddCommand(input, database);
                        break;
                    case "filter by type":
                        FilterByTypeCommand(input, database);
                        break;
                    case "filter by price from":
                        float filterPrice = float.Parse(input[4]);

                        break;
                    case "filter by price to":
                        break;
                    case "filter by price from min to max":
                        break;
                }
              
            }
            Console.WriteLine(database.Count);
        }
        private static void AddCommand(string[] input, Dictionary<string, Item> database)
        {
            string name = input[1];
            float price = float.Parse(input[2]);
            string type = input[3];
            var newItem = new Item(name, price, type);
            if (database.TryAdd(name, newItem) == true)
            {
                Console.WriteLine($"Ok: Item {name} added successfully");
            }
            else
            {
                Console.WriteLine($"Error: Item {name} already exists");
            }
        }
        private static void FilterByTypeCommand(string[] input, Dictionary<string, Item> database)
        {
            string filterType = input[3];
            var databaseToList = new List<Item>();
            foreach (var item in database)
            {
                databaseToList.Add(item.Value);
            }
            var byTypeList = databaseToList.Where(item => item.Type == filterType)
                .OrderBy(item => item.Price).ThenBy(item => item.Name).ToList();

            int filteredCount = byTypeList.Count;
            if (filteredCount == 0)
            {
                Console.WriteLine($"Error: Type {filterType} does not exist");
                return;
            }
            if (filteredCount > 10)
            {
                filteredCount = 10;
            }
            var output = new StringBuilder();
            for (int index = 0; index < filteredCount; index++)
            {
                string itemName = byTypeList[index].Name;
                string itemPrice = byTypeList[index].Price.ToString();
                output.Append($"{itemName}({itemPrice})");
                if (index != filteredCount - 1)
                {
                    output.Append(", ");
                }
            }
            Console.WriteLine(output.ToString());
        }
    }
}