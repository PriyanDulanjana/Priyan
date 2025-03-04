using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity_Demand_Management_Sys
{
    class DoublyLinkedList
    {
        public PowerPlant? Head { get; set; }
        public PowerPlant? Tail { get; set; }

        public void AddPlant(string name, double capacity, double unitCost, bool isBaseload)
        {
            PowerPlant newPlant = new PowerPlant(name, capacity, unitCost, isBaseload);

            if (Head == null)
            {
                Head = Tail = newPlant;
            }
            else
            {
                Tail.Next = newPlant;
                newPlant.Prev = Tail;
                Tail = newPlant;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Power plant '{name}' added successfully.");
            Console.WriteLine("--------------------------------------------");
        }

        public void RemovePlant(string name)
        {
            PowerPlant current = Head;

            while (current != null)
            {
                if (current.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    if (current.Prev != null)
                        current.Prev.Next = current.Next;
                    else
                        Head = current.Next;

                    if (current.Next != null)
                        current.Next.Prev = current.Prev;
                    else
                        Tail = current.Prev;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine($"Power plant '{name}' removed successfully.");
                    Console.WriteLine("--------------------------------------------");
                    return;
                }
                current = current.Next;
            }

            Console.WriteLine($"Power plant '{name}' not found.");
        }

        public void DisplayPlants()
        {
            PowerPlant current = Head;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("\nPower Plants List:");
            while (current != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Name: {current.Name}, Capacity: {current.Capacity}MW, Unit Cost: {current.UnitCost}$, Baseload: {current.IsBaseload}");
                current = current.Next;
            }
            Console.WriteLine("--------------------------------------------");
        }
    }


}
