using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the calculator program!");
                char choice;
                int sum = 0;
                int a = 0;
                int b = 0;
                Console.Write("Enter the operation (+, -, *, /): ");
                choice = char.Parse(Console.ReadLine());
                if (choice == '+')
                {
                    Console.Write("Enter the first value: ");
                    a = int.Parse(Console.ReadLine());
                    Console.Write("Enter the second value: ");
                    b = int.Parse(Console.ReadLine());
                    for (int i = 0; i < a; i++)
                    {
                        sum = a + b;
                        Console.Write("The result is: ");
                        Console.WriteLine(sum);
                        if (i < a)
                        {
                            b = sum;
                        }
                    }
                }
                else if (choice == '-')
                {
                    Console.Write("Enter the first value: ");
                    a = int.Parse(Console.ReadLine());
                    Console.Write("Enter the second value: ");
                    b = int.Parse(Console.ReadLine());
                    for (int i = 0; i < a; i++)
                    {
                        sum = a - b;
                        Console.Write("The result is: ");
                        Console.WriteLine(sum);
                        if (i < a)
                        {
                            b = sum;
                        }
                    }
                }
                else if (choice == '*')
                {
                    Console.Write("Enter the first value: ");
                    a = int.Parse(Console.ReadLine());
                    Console.Write("Enter the second value: ");
                    b = int.Parse(Console.ReadLine());
                    for (int i = 0; i < a; i++)
                    {
                        sum = a * b;
                        Console.Write("The result is: ");
                        Console.WriteLine(sum);
                        if (i < a)
                        {
                            b = sum;
                        }
                    }
                }
                else if (choice == '/')
                {
                    Console.Write("Enter the first value: ");
                    a = int.Parse(Console.ReadLine());
                    Console.Write("Enter the second value: ");
                    b = int.Parse(Console.ReadLine());
                    for (int i = 0; i < a; i++)
                    {
                        sum = a / b;
                        Console.Write("The result is: ");
                        Console.WriteLine(sum);
                        if (i < a)
                        {
                            b = sum;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid operation");
                }
                Console.WriteLine("Press any key to exit...");
                Console.WriteLine("Thank you! For using our program.");
                Console.Write("programmed by: Abdullah Huda \n");
                Console.Write("Email: abdullahua2006@gmail.com \n");
                Console.Write("GitHub: DONT FUCKING ASK ME \t");
                Console.Write("LinkedIn: DONT FUCKING ASK ME \n");
                Console.Write("Instagram: okay i'll tell you \t");
                Console.Write("Instagram: @m_abdullah_huda06 \n");
                Console.Write("Facebook: DONT FUCKING ASK ME \t");
                Console.Write("Twitter: DONT FUCKING ASK ME \n");
                Console.Write("TikTok: okay i'll tell you \t");
                Console.Write("TikTok: KHUSRA HO KYA !!! \n");
                Console.WriteLine("Do you want to continue? (yes/no)");
                string response = Console.ReadLine()?.Trim().ToLower();
                if (response == "no")
                {
                    isRunning = false;
                }
                else if (response == "yes")
                {
                    isRunning = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Exiting the program.");
                    isRunning = false;
                }
            }
        }
    }
}
