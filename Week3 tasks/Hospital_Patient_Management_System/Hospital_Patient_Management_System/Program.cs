using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Patient_Management_System
{
    class Record
    {
        public string Name;
        public int Age;
        public string Patient_Id;
        public int Consultation_Fee;
        public void Add_record()
        {
            Console.Write("Enter Patient ID: ");
            Patient_Id = Console.ReadLine();
            Console.Write("Enter name: ");
            Name = Console.ReadLine();
            Console.Write("Enter age: ");
            Age=int.Parse(Console.ReadLine());
            Console.Write("Enter Consultation Fee: ");
            Consultation_Fee = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }
        public void output()
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine("Patient ID: " + Patient_Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Consultation Fee: " + Consultation_Fee);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            List<Record> record = new List<Record>();
            string option;
            do
            {
                Console.WriteLine("Hospital Patient Management System");
                Console.WriteLine();
                Console.WriteLine("1.Add Patient");
                Console.WriteLine("2.View Patient");
                Console.WriteLine("3.Oldest Patient");
                Console.WriteLine("4.Search Patient");
                Console.WriteLine("5.High Consultation Fees");
                Console.WriteLine("6.Exit");
                Console.WriteLine();
                Console.Write("Enter option: ");
                option = Console.ReadLine();

                if (option == "1")
                {
                    Record R1 = new Record();
                    R1.Add_record();
                    record.Add(R1);
                }
                else if (option == "2")
                {
                    foreach(Record R in record)
                    {
                        R.output();
                    }
                }
                else if(option=="3")
                {
                    Record oldest = record[0];
                    foreach(Record R in record)
                    {
                        if(R.Age>oldest.Age)
                        {
                            oldest = R;
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Oldest Record");
                    oldest.output();
                }
                else if(option=="4")
                {
                    Console.Write("Enter Search Patient by Patient Id: ");
                    string search= Console.ReadLine();
                    Console.WriteLine();
                    bool found = false;
                    foreach(Record R in record)
                    {
                        if(R.Patient_Id==search)
                        {
                            Console.WriteLine("Search Patient");
                            R.output();
                            found = true;
                        }
                    }
                    if (found == false)
                    {
                        Console.WriteLine("NOT FOUND");
                    }
                }
                else if(option=="5")
                {
                    bool found= false;
                    foreach (Record R in record)
                    {
                        if(R.Consultation_Fee>5000)
                        {
                            Console.WriteLine("Highest Consultaton Fee");
                            R.output();
                            found= true;
                        }
                    }
                    if(found == false)
                    {
                        Console.WriteLine("Not Highest Consultation Fee");
                    }
                }
                else
                {
                    Console.WriteLine("BYE BYE");
                }
            } while (option != "6");
        }
    }
}
