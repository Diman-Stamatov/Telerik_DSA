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
                       
            var head = new Node("head");
            var tail = new Node("head");
            int patientsCount = 0;
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
                    if (head.value == "head" && head.value == tail.value)
                    {
                        head.value = name;
                        tail.value = name;

                    }
                    else
                    {
                        var newNode = new Node(name);
                        tail.next = newNode;
                        newNode.prev = tail;
                        tail = newNode;
                    }
                    if (!peopleRegistry.ContainsKey(name))
                    {
                        peopleRegistry.Add(name, 0);
                    }
                    peopleRegistry[name]++;
                    output.AppendLine("OK");
                    patientsCount++;
                }
                else if (command[0] == "Insert")
                {
                    int position = int.Parse(command[1]);
                    string person = command[2];
                    
                    if (position == 0)
                    {
                        var newNode = new Node(person);
                        head.prev = newNode;
                        newNode.next = head;
                        head = newNode;
                        
                        if (!peopleRegistry.ContainsKey(person))
                        {
                            peopleRegistry.Add(person, 0);
                        }
                        peopleRegistry[person]++;
                        output.AppendLine("OK");
                        patientsCount++;
                    }
                    else if (position == patientsCount)
                    {
                        var newNode = new Node(person);
                        tail.next = newNode;
                        newNode.prev = tail;
                        tail = newNode;    
                        if (!peopleRegistry.ContainsKey(person))
                        {
                            peopleRegistry.Add(person, 0);
                        }
                        peopleRegistry[person]++;
                        output.AppendLine("OK");
                        patientsCount++;
                    }
                    else if (position > 0 && position < patientsCount)
                    {
                        var current = head;
                        for (int index = 0; index < position; index++)
                        {
                            if (index != 0 && index != position -1)
                            {
                                current = current.next;
                            }
                        }
                        var newNode = new Node(person);
                        if (current.prev != null)
                        {
                            current.prev.next = newNode;
                        }
                        
                        newNode.prev = current.prev;
                        newNode.next = current;
                        current.prev = newNode;
                        
                        if (!peopleRegistry.ContainsKey(person))
                        {
                            peopleRegistry.Add(person, 0);
                        }
                        peopleRegistry[person]++;
                        output.AppendLine("OK");
                        patientsCount++;
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
                    
                    if (count > patientsCount)
                    {
                        output.AppendLine("Error");
                        continue;
                    }
                    var current = head;
                    var peopleToPrint = new string[count];
                    for (int index = 0; index < count; index++)
                    {
                        if (index !=0)
                        {
                            current = current.next;
                        }
                        
                        peopleToPrint[index] = current.value;
                        
                    }
                    head = current;
                    head.prev = null;
                    
                    foreach (var person in peopleToPrint)
                    {
                        peopleRegistry[person]--;
                    }

                    output.AppendLine(string.Join(" ", peopleToPrint));
                    patientsCount -= count;
                }
            }
            Console.WriteLine(output.ToString());
        }
        public class Node
        {
            public string value;
            public Node next;
            public Node prev;
            public Node(string value)
            {
                this.value = value;
                this.next = null;
                this.prev = null;
            }
        }
    }
}