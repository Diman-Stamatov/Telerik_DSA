using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDNLToys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            string[] lines = new string[numberOfLines];
            for (int line = 0; line < numberOfLines; line++)
            {
                lines[line] = Console.ReadLine();
            }
            var stack = new Stack<string>();
            int indentation = 0;           
            foreach (var line in lines)
            {
                int lineLevel = int.Parse(line.Substring(1));
                if(stack.Count == 0)
                {
                    stack.Push(line);
                    string output = CreateIndentation(indentation) + OpenStatement(line);
                    Console.WriteLine(output);
                    
                    
                    continue;
                }
                int stackLevel = int.Parse(stack.Peek().Substring(1));
                if (stackLevel < lineLevel)
                {
                    indentation++;
                    stack.Push(line);
                    string output = CreateIndentation(indentation) + OpenStatement(line);
                    Console.WriteLine(output);
                }
                else
                {
                    int lastLevel = 0;
                    while (stackLevel >= lineLevel)
                    {
                        
                        string poppedLine = stack.Pop();
                        if (lastLevel > stackLevel)
                        {
                            indentation--;
                            
                        }
                        
                        string loopOutput = CreateIndentation(indentation) + CloseStatement(poppedLine);
                        Console.WriteLine(loopOutput);
                        if (stack.Count ==0)
                        {
                            indentation = 0;
                            break;
                        }
                        lastLevel = stackLevel;
                        stackLevel = int.Parse(stack.Peek().Substring(1));


                    }
                    stack.Push(line);
                    string output = CreateIndentation(indentation) + OpenStatement(line);
                    Console.WriteLine(output);
                    
                }

            }
            
            int previousLevel  = 0;
            foreach (var item in stack)
            {
                int currentLevel = int.Parse(item.Substring(1));
                if (previousLevel > currentLevel)
                {
                    indentation--;

                }
                previousLevel = currentLevel;  
                string loopOutput = CreateIndentation(indentation) + CloseStatement(item);
                Console.WriteLine(loopOutput);
            }
        }
        public static string CreateIndentation(int size)
        {
            string indentation = new string(' ', size);
            return indentation;
        }
        public static string OpenStatement(string statement)
        {
            return $"<{statement}>";
        }
        public static string CloseStatement(string statement)
        {
            return $"</{statement}>";
        }
    }
}
