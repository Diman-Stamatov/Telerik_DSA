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
        }
        static Dictionary<string, List<Pokemon>> typeDictionary = new Dictionary<string, List<Pokemon>>();
        static HashSet<Pokemon> pokemons = new HashSet<Pokemon>();
        static Dictionary<int, Pokemon> rankDictionary = new Dictionary<int, Pokemon>();

        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine().Split(" ");
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
                        Find();
                        break;
                    case "ranklist":
                        Ranklist();
                        break;
                }
            }
            
        }
        public static void Add(string[] input)
        {
            string name = input[1];
            string type = input[2];
            int power = int.Parse(input[3]);
            int position = int.Parse(input[4]);
            var newMon = new Pokemon(name, type, power, position);            
            if (position != pokemons.Count +1)
            {
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
        }
        public static void Find(string[] input)
        {

        }
        public static void Ranklist(string[] input)
        {

        }
    }
}