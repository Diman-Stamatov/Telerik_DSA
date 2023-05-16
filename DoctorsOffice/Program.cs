using System.Text;
using System;
using System.Collections.Generic;

using System.Linq;


namespace DoctorsOffice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var queue = new List<string>();
            int startIndex = 0;
            var output = new StringBuilder();
            var peopleRegistry = new Dictionary<string, int>();
            while (true)
            {
                string[] command = Console.ReadLine().Split(' ');
                if (command[0] == "End")
                {
                    break;
                }
                if (command[0] == "Append")
                {
                    string name = command[1];
                    queue.Add(name);
                    if (!peopleRegistry.ContainsKey(name))
                    {
                        peopleRegistry.Add(name, 0);
                    }
                    peopleRegistry[name]++;
                    output.AppendLine("OK");
                }
                else if (command[0] == "Insert")
                {
                    int position = int.Parse(command[1]);
                    string person = command[2];
                    int peopleCount = queue.Count() - startIndex;
                    if (position == 0)
                    {
                        if (startIndex ==0)
                        {
                            queue.Insert(startIndex, person);
                            if (!peopleRegistry.ContainsKey(person))
                            {
                                peopleRegistry.Add(person, 0);
                            }
                            peopleRegistry[person]++;
                            output.AppendLine("OK");
                        }
                        else
                        {
                            queue[--startIndex] = person;
                            if (!peopleRegistry.ContainsKey(person))
                            {
                                peopleRegistry.Add(person, 0);
                            }
                            peopleRegistry[person]++;
                            output.AppendLine("OK");
                        }                        
                    }                    
                    else if (position == peopleCount)
                    {
                        queue.Add(person);
                        if (!peopleRegistry.ContainsKey(person))
                        {
                            peopleRegistry.Add(person, 0);
                        }
                        peopleRegistry[person]++;
                        output.AppendLine("OK");
                    }
                    else if (position > startIndex && position < peopleCount)
                    {
                        queue.Insert(position + startIndex, person);
                        if (!peopleRegistry.ContainsKey(person))
                        {
                            peopleRegistry.Add(person, 0);
                        }
                        peopleRegistry[person]++;
                        output.AppendLine("OK");
                    }
                    else
                    {
                        output.AppendLine("Error");
                    }
                }
                else if (command[0] == "Find")
                {
                    string name = command[1];

                    if (!peopleRegistry.ContainsKey(name))
                    {
                        output.AppendLine("0");
                    }
                    else
                    {
                        output.AppendLine(peopleRegistry[name].ToString());
                    }
                    
                }
                else 
                {
                    int count = int.Parse(command[1]);
                    int peopleCount = queue.Count() - startIndex;
                    if (count > peopleCount)
                    {
                        output.AppendLine("Error");
                        continue;
                    }
                    var peopleToPrint = queue.GetRange(startIndex, count);
                    foreach (var person in peopleToPrint)
                    {
                        peopleRegistry[person]--;
                    }
                    startIndex += count;
                    output.AppendLine(String.Join(" ", peopleToPrint));
                }
            }
            Console.WriteLine(output.ToString());
        }
    }
}