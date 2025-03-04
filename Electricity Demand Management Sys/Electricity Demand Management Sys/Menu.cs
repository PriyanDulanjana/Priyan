using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity_Demand_Management_Sys
{
    class Menu
    {
        public void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("                  Energy Demand Management System");
            Console.WriteLine("             Data Structures and Algorithms-EE/EC3305");
            Console.WriteLine("            Faculty Of Engineering,University Of Ruhuna");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("                     1. Add New Data");
            Console.WriteLine("                     2. Remove Exist Data");
            Console.WriteLine("                     3. View Data");
            Console.WriteLine("                     4. Demand Management");
            Console.WriteLine("                     5. Exit");
            Console.WriteLine("========================================================================");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                 Copyright © 2025.All Rights Reserved");
            Console.ResetColor();
            Console.WriteLine("========================================================================");
        }

        public int GetUserChoice()
        {
            int choice;
            bool isValidChoice;

            do
            {
                Console.Write("Enter your choice: ");
                isValidChoice = int.TryParse(Console.ReadLine(), out choice);

                if (!isValidChoice || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid choice. Please Check and select a valid option.");
                    isValidChoice = false;
                }
            } while (!isValidChoice);

            return choice;
        }
    }

}
