using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Student_Management_System
{
     class Record
     {
        public string Name;
        public string Roll_no;
        public string Department;
        public int Marks;
        public void add_student()
        {
            Console.Write("Enter name: ");
            Name = Console.ReadLine();
            Console.Write("Enter roll number: ");
            Roll_no = Console.ReadLine();
            Console.Write("Enter department name: ");
            Department = Console.ReadLine();
            Console.Write("Enter marks: ");
            Marks=int.Parse(Console.ReadLine());
            Console.WriteLine();
        }
        public void output()
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Roll Number: " + Roll_no);
            Console.WriteLine("Department name: " + Department);
            Console.WriteLine("Marks: " + Marks);
            Console.WriteLine();
        }
        
       
        static void Main(string[] args)
        {
            List<Record> record=new List<Record>();
            string choice;
            do
            {
                Console.WriteLine("College Student Management Systems");
                Console.WriteLine();
                Console.WriteLine("1.Add Student Record");
                Console.WriteLine("2.View Student Record");
                Console.WriteLine("3.Find Top Student");
                Console.WriteLine("4.Search Student");
                Console.WriteLine("5.Students Who Need Improvement");
                Console.WriteLine("6.Exit");
                Console.WriteLine();
                Console.Write("Enter option: ");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    Record R1 = new Record();
                    R1.add_student();
                    record.Add(R1);
                }
                else if (choice == "2")
                {
                    foreach (Record R in record)
                    {
                        R.output();
                    }
                }
                else if(choice=="3")
                {
                    Record top = record[0];
                    foreach (Record R in record)
                    {
                        if(R.Marks>top.Marks)
                        {
                            top = R;
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Top Student");
                    top.output();
                }
                else if(choice=="4")
                {
                    Console.Write("Enter search student by roll_no: ");
                    string search=Console.ReadLine();
                    Console.WriteLine();
                    bool found=false;
                    foreach (Record R in record)
                    {
                        if(R.Roll_no==search)
                        {
                            Console.WriteLine("Search Student Record ");
                            R.output();
                            found=true;
                        }
                    }
                    if (found == false)
                    {
                        Console.WriteLine("NOT FOUND");
                    }
                }
                else if(choice=="5")
                {
                    bool found=false;
                    foreach(Record R in record)
                    {
                        if(R.Marks<50)
                        {
                            Console.WriteLine("Studend Need Improvement");
                            R.output();
                            found = true;
                        }
                    }
                    if (found == false)
                    {
                        Console.WriteLine("NO! Student Need Improvement");
                    }
                }
                else
                {
                    Console.WriteLine("BYE BYE");
                }
            } while (choice != "6");
        }
     }
}
