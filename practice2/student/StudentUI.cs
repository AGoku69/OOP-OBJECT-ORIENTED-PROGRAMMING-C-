using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice2
{
    public class StudentUI
    {
        private readonly StudentService _studentService;
        public StudentUI()
        {
            _studentService = new StudentService();
        }
        public void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("Student Management System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Find Student by ID");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    consol.writeline
                    AddStudentUI();
                }
                else if (choice == "2")
                {
                    FindStudentById();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
    }
}
