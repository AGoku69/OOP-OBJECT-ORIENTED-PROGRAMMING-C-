using System;
using System.IO;

namespace task10
{
    internal class Program
    {
        static int Menu()
        {
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. Sign Up");
            Console.Write("Enter the Option : ");
            if (int.TryParse(Console.ReadLine(), out int option))
                return option;
            return 0;
        }

        static string ParseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item += record[x];
                }
            }
            return item;
        }

        static void ReadData(string path, string[] names, string[] password)
        {
            int x = 0;
            if (File.Exists(path))
            {
                using (var fileVariable = new StreamReader(path))
                {
                    string record;
                    while ((record = fileVariable.ReadLine()) != null)
                    {
                        names[x] = ParseData(record, 1);
                        password[x] = ParseData(record, 2);
                        x++;
                        if (x >= names.Length)
                        {
                            break;
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Not Exist: " + path);
            }
        }

        static void Signin(string n, string p, string[] names, string[] password)
        {
            bool flag = false;
            for (int x = 0; x < names.Length; x++)
            {
                if (names[x] == null) continue;
                if (n == names[x] && p == password[x])
                {
                    Console.WriteLine("Valid User!");
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void Signup(string path, string n, string p)
        {
            using (var file = new StreamWriter(path, true))
            {
                file.WriteLine(n + "," + p);
            }
        }

        static void Main(string[] args)
        {
            string path = "E:\\UET 2nd SEM\\OOP\\lab\\Task9\\Textfile.txt";
            string[] names = new string[5];
            string[] password = new string[5];
            int option;
            do
            {
                ReadData(path, names, password);
                Console.Clear();
                option = Menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.Write("Enter Name:  ");
                    string n = Console.ReadLine();
                    Console.Write("Enter Password:  ");
                    string p = Console.ReadLine();
                    Signin(n, p, names, password);
                }
                else if (option == 2)
                {
                    Console.Write("Enter New Name:   ");
                    string n = Console.ReadLine();
                    Console.Write("Enter New Password:  ");
                    string p = Console.ReadLine();
                    Signup(path, n, p);
                }
            }
            while (option < 3);
            Console.WriteLine("Exiting. Press any key...");
            Console.ReadKey();
        }
    }
}
