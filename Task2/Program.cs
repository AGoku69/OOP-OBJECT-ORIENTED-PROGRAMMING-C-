using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 2: If-Else Statements
            // Write a C# program that uses if-else statements to evaluate different conditions and print appropriate messages based on the evaluation.
            // Example conditions to evaluate:

            // 1. Check if a number is positive, negative, or zero.
            int salary = 67000;
            if (salary > 50000)
            {
                Console.WriteLine("Handsome Income");
            }
            else if (salary < 50000 && salary > 30000)
            {
                Console.WriteLine("Average Income");
            }
            else
            {
                Console.WriteLine("Hatt Ghareeb");
            }

            // 2. Check if a person is tall, average height, or short based on their height in feet.
            float height = 6.2F;
            if (height > 6.0F)
            {
                Console.WriteLine("Tall Person");
            }
            else if (height < 6.0F && height > 5.8F)
            {
                Console.WriteLine("Average height ");
            }
            else
            {
                Console.WriteLine("Hatt bauna");
            }

            // 3. Check if a character is a vowel or consonant.
            char grade = 'C';
            if (grade == 'A')
            {
                Console.WriteLine("Congrats! You secured an " + grade);
            }
            else
            {
                Console.WriteLine("Not A");
            }

            // 4. Check if a person is eligible to vote based on their age.
            int age = 25;
            if (age >= 18)
            {
                Console.WriteLine("You are eligible to vote.");
            }
            else
            {
                Console.WriteLine("You are not eligible to vote.");
            }

            // 5. Check if a person can access a restricted area based on their classcode.
            string classcode;
            Console.WriteLine("Enter a classcode for your online class: ");
            classcode = Console.ReadLine();
            if (classcode == "pdiddy77")
            {
                Console.WriteLine("Access granted.");
            }
            else
            {
                Console.WriteLine("Access denied.");
            }

            // 6. Check if a person is eligible for a discount based on their membership status.
            bool isMember;
            Console.Write("Are you a member? (true/false): ");
            isMember = Convert.ToBoolean(Console.ReadLine());
            if (isMember)
            {
                Console.WriteLine("You are eligible for a discount.");
            }
            else
            {
                Console.WriteLine("You are not eligible for a discount.");
            }

            // 7. Check if a person is eligible for a senior citizen discount based on their age.
            int seniorAge = 65;
            if (age >= seniorAge)
            {
                Console.WriteLine("You are eligible for a senior citizen discount.");
            }
            else
            {
                Console.WriteLine("You are not eligible for a senior citizen discount.");
            }

        }
    }
}
