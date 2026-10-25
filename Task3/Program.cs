using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // loop examples

            // Task 3.1: Print "Hello!" 68 times using a for loop
            for (int idx = 0; idx <= 67; idx++)
            {
                Console.WriteLine("Hello!");
            }

            // Task 3.2: Print numbers from 0.9 to 6.7 with a step of 0.7 using a while loop
            float numb = 0.9F;
            while (numb <= 6.7F)
            {
                Console.WriteLine(numb);
                numb += 0.7F;
            }

            // Task 3.3: Print all uppercase letters from A to Z using a for loop
            for (char ch = 'A'; ch <= 'Z'; ch++)
            {
                Console.WriteLine(ch);
            }

            // Task 3.4: Print each character of the string "Hello!" using a for loop
            string word = "Hello!";
            for (int i = 0; i < word.Length; i++)
            {
                Console.Write(word[i]);
            }
            Console.WriteLine(); // Print a new line after the characters

        }
    }
}
