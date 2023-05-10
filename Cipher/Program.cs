using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cipher
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string originalMessage = Console.ReadLine();
            string code = Console.ReadLine();
            int index = 1;
            var codeToLetter = new Dictionary<string, string>();
            string letter = code[0].ToString();
            var letterCode = new List<int>();

            while (true)
            {
                
                if (index == code.Length)
                {
                    codeToLetter.Add((string.Join("", letterCode)), letter);
                    break;
                }
                if (code[index] > 46 && code[index] < 58)
                {
                    letterCode.Add(code[index] - '0');
                }
                else
                {
                    codeToLetter.Add((string.Join("", letterCode)), letter);
                    letter = code[index].ToString();
                    letterCode.Clear();
                }
                index++;            
            }

            var output = new HashSet<string>();
            Decode(originalMessage, codeToLetter, "", output);

            Console.WriteLine(output.Count);

            foreach (var element in output.OrderBy(m => m))
            {
                Console.WriteLine(element);
            }


        }
        static void Decode(string originalMessage, Dictionary<string, string> codeToLetter,string currentMessage, HashSet<string> output)
        {
            if (originalMessage.Length == 0)
            {            
                output.Add(currentMessage);
            }
            else
            {           
                foreach (var code in codeToLetter)
                {
                    if (originalMessage.StartsWith(code.Key))
                    {
                    Decode(originalMessage.Substring(code.Key.Length), codeToLetter,
                        currentMessage + code.Value, output);
                    }
                }
            }
        }
    }
}
