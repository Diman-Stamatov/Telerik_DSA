namespace InventoryManager
{
    internal class Program
    {
        public class Item
        {
            private string Name { get; }
            private float Price { get; }   
            private string Type { get; }
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
                        break;
                    case "filter by type":
                        break;
                    case "filter by price from":
                        break;
                    case "filter by price to":
                        break;
                    case "filter by price from min to max":
                        break;
                }
              
            }
            Console.WriteLine(database.Count);
        }
    }
}