using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    internal class Program
    {
        // Program to calculate if Lilly can buy a washing machine with her birthday money and toy sales
        public static void Main()
        {
            // Read the inputs from the console
            Console.WriteLine("Enter Lilly's age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the price of the washing machine:");
            double washingMachinePrice = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the price of each toy:");
            int toyPrice = int.Parse(Console.ReadLine());

            // Call the calculation function
            CalculateMachinePurchase(age, washingMachinePrice, toyPrice);
        }

        public static void CalculateMachinePurchase(int age, double washingMachinePrice, int toyPrice)
        {
            double totalSavedMoney = 0;
            int toysReceived = 0;
            double currentMoneyGift = 10.00; // Starts at 10 on the 2nd birthday

            // Loop through each of Lilly's birthdays
            for (int currentBirthday = 1; currentBirthday <= age; currentBirthday++)
            {
                if (currentBirthday % 2 == 0)
                {
                    // Even birthday: gets money, but brother takes $1
                    totalSavedMoney += (currentMoneyGift - 1.00);

                    // The money gift increases by $10 for the next even birthday
                    currentMoneyGift += 10.00;
                }
                else
                {
                    // Odd birthday: gets a toy
                    toysReceived++;
                }
            }

            // Sell all the toys and add the cash to the savings
            totalSavedMoney += (toysReceived * toyPrice);

            // Check if she has enough money and print the result
            if (totalSavedMoney >= washingMachinePrice)
            {
                double remainingMoney = totalSavedMoney - washingMachinePrice;
                Console.WriteLine($"Yes! " + remainingMoney);
            }
            else
            {
                double missingMoney = washingMachinePrice - totalSavedMoney;
                Console.WriteLine($"No! " + missingMoney);
            }
        }
    }
}
