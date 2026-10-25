using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Array of integers
            int[] numbs = new int[] { 13, 14, 15, 16 };
            for (int i = 0; i < numbs.Length; i++)
            {
                Console.WriteLine(numbs[i]);
            }
            Console.ReadLine();

            // Array of floats
            float[] floats = new float[5] { 13.4F, 14.2F, 15.9F, 16.0F, 17.5F };
            for (int i = 0; i < floats.Length; i++)
            {
                Console.WriteLine(floats[i]);
            }
            Console.ReadLine();

            // Array of characters
            char[] consonents = new char[5];
            for (int i = 0; i < consonents.Length; i++)
            {
                Console.Write("Enter consonent for index " + i + ": ");
                consonents[i] = char.Parse(Console.ReadLine());
            }
            for (int i = 0; i < consonents.Length; i++)
            {
                Console.WriteLine("Consonent at index " + i + " is " + consonents[i]);
            }
            Console.ReadLine();

            // Array of strings
            string[] names = new string[2] { "Ali", "Sara" };
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine("String Array element: " + names[i]);
            }
            Console.ReadLine();

            // Array of booleans
            bool[] bools = new bool[3] { true, false, true };
            for (int i = 0; i < bools.Length; i++)
            {
                Console.WriteLine("Boolean Array element: " + bools[i]);
            }
            Console.ReadLine();

            // Array of objects
            object[] objects = new object[3] { 1, "Hello", 3.14 };
            for (int i = 0; i < objects.Length; i++)
            {
                Console.WriteLine("Object Array element: " + objects[i]);
            }
            Console.ReadLine();

            // Array of decimals
            decimal[] decimals = new decimal[3] { 1.1M, 2.2M, 3.3M };
            for (int i = 0; i < decimals.Length; i++)
            {
                Console.WriteLine("Decimal Array element: " + decimals[i]);
            }
            Console.ReadLine();

            // Array of bytes
            byte[] bytes = new byte[3] { 1, 2, 3 };
            for (int i = 0; i < bytes.Length; i++)
            {
                Console.WriteLine("Byte Array element: " + bytes[i]);
            }
            Console.ReadLine();

            // Array of shorts
            short[] shorts = new short[3] { 1, 2, 3 };
            for (int i = 0; i < shorts.Length; i++)
            {
                Console.WriteLine("Short Array element: " + shorts[i]);
            }
            Console.ReadLine();

            // Array of longs
            long[] longs = new long[3] { 1L, 2L, 3L };
            for (int i = 0; i < longs.Length; i++)
            {
                Console.WriteLine("Long Array element: " + longs[i]);
            }
            Console.ReadLine();

            // Array of unsigned integers
            uint[] uints = new uint[3] { 1U, 2U, 3U };
            for (int i = 0; i < uints.Length; i++)
            {
                Console.WriteLine("Unsigned Integer Array element: " + uints[i]);
            }
            Console.ReadLine();

            // Array of unsigned shorts
            ushort[] ushorts = new ushort[3] { 1, 2, 3 };
            for (int i = 0; i < ushorts.Length; i++)
            {
                Console.WriteLine("Unsigned Short Array element: " + ushorts[i]);
            }
            Console.ReadLine();

            // Array of unsigned longs
            ulong[] ulongs = new ulong[3] { 1UL, 2UL, 3UL };
            for (int i = 0; i < ulongs.Length; i++)
            {
                Console.WriteLine("Unsigned Long Array element: " + ulongs[i]);
            }
            Console.ReadLine();

            // Array of doubles
            double[] doubles = new double[3] { 1.1, 2.2, 3.3 };
            for (int i = 0; i < doubles.Length; i++)
            {
                Console.WriteLine("Double Array element: " + doubles[i]);
            }
            Console.ReadLine();

            // Array of strings with user input
            string[] userInputStrings = new string[3];
            for (int i = 0; i < userInputStrings.Length; i++)
            {
                Console.Write("Enter string for index " + i + ": ");
                userInputStrings[i] = Console.ReadLine();
            }
            for (int i = 0; i < userInputStrings.Length; i++)
            {
                Console.WriteLine("User Input String at index " + i + " is " + userInputStrings[i]);
            }
            Console.ReadLine();

            // Array of integers with user input
            int[] userInputIntegers = new int[3];
            for (int i = 0; i < userInputIntegers.Length; i++)
            {
                Console.Write("Enter integer for index " + i + ": ");
                userInputIntegers[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < userInputIntegers.Length; i++)
            {
                Console.WriteLine("User Input Integer at index " + i + " is " + userInputIntegers[i]);
            }
            Console.ReadLine();

            
        }
    }
}
