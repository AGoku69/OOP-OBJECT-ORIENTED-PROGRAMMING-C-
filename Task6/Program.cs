using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Largest number in an array
            Console.WriteLine("Enter the size of the array: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[choice];
            Console.WriteLine("Enter the elements of the array: ");
            for (int i = 0; i < choice; i++)
            {
                Console.Write("Element " + (i + 1) + ": ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            int largest = numbers[0];
            for (int i = 1; i < choice; i++)
            {
                if (numbers[i] > largest)
                {
                    largest = numbers[i];
                }
            }
            Console.WriteLine("The largest number in the array is: " + largest);

            // Smallest number in an array
            int smallest = numbers[0];
            for (int i = 1; i < choice; i++)
            {
                if (numbers[i] < smallest)
                {
                    smallest = numbers[i];
                }
            }
            Console.WriteLine("The smallest number in the array is: " + smallest);

            // Sum of all numbers in an array
            int sum = 0;
            for (int i = 0; i < choice; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine("The sum of all numbers in the array is: " + sum);

            // Average of all numbers in an array
            double average = 0;
            for (int i = 0; i < choice; i++)
            {
                sum += numbers[i];
            }
            average = sum / choice;
            Console.WriteLine("The average of all numbers in the array is: " + average);

            Console.ReadLine();
        }
    }
}
