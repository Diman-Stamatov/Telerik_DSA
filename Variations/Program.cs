using System;
using System.Text;

class Program
{
    static StringBuilder output = new StringBuilder();  
    static void Main(string[] args)
    {
        int stringLength = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        char charOne = '0';
        char charTwo = '1';
        if (input[0] < input[2])
        {
            charOne = input[0];
            charTwo = input[2];
        }
        else
        {
            charOne = input[2];
            charTwo = input[0];
        }
        Variations(charOne, charTwo, "", stringLength);
        Console.WriteLine(output.ToString());
    }

    
   
    static void Variations(char charOne, char charTwo, string printString, int stringLength)
    {
        if (stringLength == printString.Length)
        {
            output.AppendLine(printString);
            return;
        }
        Variations(charOne, charTwo, printString + charOne, stringLength);
        Variations(charOne, charTwo, printString + charTwo, stringLength);
    }

   
   
}



