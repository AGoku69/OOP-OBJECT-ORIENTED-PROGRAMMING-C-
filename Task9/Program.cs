using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    internal class Program
    {
        static int menu ()
        {
            int option;
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. Sign Up");
            Console.WriteLine("Enter the Option : ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static string parseData(string record, int feild)
        {
            int comma = 1;
            string item = "";
            for(int x = 0; x < record.length; x++);
            {
                if(record[x == ","])
                {
                    comma++;
                }
                else if(comma == feild)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void readData(string path, string[] names, string[] password)
        {
            int x = 0;
            if(File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while((record = fileVariable.ReadLine()) != null)
                {
                    names[x] = parseData(record, 1);
                    password[x] = parseData(record, 2);
                    x++;
                    if( x>= 5)
                    {
                        break;
                    }

                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exist");
            }
        }
        static void signin(string n,string p, string[] names, string password)
        {
            bool flag = false;
            for(int x=0; x<5; x++)
            {
                if(n == names[x] && p == password[x])
                {
                    Console.WriteLine("Valid User!");
                    flag = true;
                }
            }
            if(flag == false)
            {
                Console.WriteLine("InValid User");
            }
            Console.ReadKey();
        }
        static void signup(string path, string p, string n)
        {
            StreamWriter file = new StreamWriter(path, ture);
            file.WriteLine(n + "," + p);
            file.Flush;
            file.Close;
        }
        static void Main(string args)
        {
            string path = "E:\\UET 2nd SEM\\OOP\\lab\\Task9\\Textfile.txt";
            string[] names = new string[5];
            String[] password = new string[5];
            int option;
            do
            {
                readData(path, names, password);
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter Name:  ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password:  ");
                    string p = Console.ReadLine();
                    signin(n, p, names, password);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter New Name:   ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter New Password:  ");
                    string p = Console.ReadLine();
                    signup(path, n, p);
                }
            }
            while (option < 3);
            consol.read();
        }
    }
}
