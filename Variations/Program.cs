using System;

class Program
{
    static void Main(string[] args)
    {
        int stringLength = int.Parse(Console.ReadLine());
        List<char> input = Console.ReadLine().Split().ToList();

        string[] variations = GenerateVariations(symbols, stringLength);

        foreach (string variation in variations)
        {
            Console.WriteLine(variation);
        }
    }

    static string[] GenerateVariations(string[] symbols, int length)
    {
        string[] variations = new string[(int)Math.Pow(symbols.Length, length)];

        for (int i = 0; i < variations.Length; i++)
        {
            string variation = "";
            int remainder = i;

            for (int j = 0; j < length; j++)
            {
                int index = remainder % symbols.Length;
                variation = symbols[index] + variation;
                remainder /= symbols.Length;
            }

            variations[i] = variation;
        }

        var output = variations.OrderByDescending(x=>x).ToArray();
        return output;
    }
}
