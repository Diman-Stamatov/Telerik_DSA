using System;

class Program
{
    static void Main(string[] args)
    {
        int stringLength = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        char[] symbols = new char[] { input[0], input[2] };
        int numberOfSymbols = 2;
        printAllKLengthRec(symbols, "", numberOfSymbols, stringLength);
    }

    
    // The main recursive method
    // to print all possible
    // strings of length k
    static void printAllKLengthRec(char[] symbols, string prefix, int numberOfSymbols, int stringLength)
    {

        // Base case: k is 0,
        // print prefix
        if (stringLength == 0)
        {
            Console.WriteLine(prefix);
            return;
        }

        // One by one add all characters
        // from set and recursively
        // call for k equals to k-1
        for (int i = 0; i < numberOfSymbols; ++i)
        {

            // Next character of input added
            string newPrefix = prefix + symbols[i];

            // k is decreased, because
            // we have added a new character
            printAllKLengthRec(symbols, newPrefix, numberOfSymbols, stringLength - 1);
        }
    }

    // Driver Code
   
}

// This code is contributed by Ajit.


