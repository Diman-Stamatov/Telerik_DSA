using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string code = Console.ReadLine();
            int index = 1;
            var dictionary = new Dictionary<int, char>();
            char letter = code[0];
            var letterCode = new List<int>();
            while (true)
            {
                if (index == code.Length)
                {
                    dictionary.Add(int.Parse(string.Join("", letterCode)), letter);
                    break;
                }
                if (code[index] > 46 && code[index] < 58)
                {
                    letterCode.Add(code[index] - '0');
                }
                else
                {
                    dictionary.Add(int.Parse(string.Join("", letterCode)), letter);
                    letter = code[index];
                    letterCode.Clear();
                }
                index++;            
            }
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Value  + " " + item.Key  );
            }


        }
    }
}
