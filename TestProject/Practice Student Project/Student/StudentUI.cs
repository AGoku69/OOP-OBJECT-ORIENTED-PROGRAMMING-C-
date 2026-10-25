using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
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

            while(true)
            {
                Console.WriteLine("Student Management System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Find Student by ID");
                Console.WriteLine("3. Find Student by Name");
                Console.WriteLine("4. Update Student Details");
                Console.WriteLine("5. Delete Student by ID");
                Console.WriteLine("6. Delete Student by Name");
                Console.WriteLine("7. View All Students");
                Console.WriteLine("8. View Students by ID");
                Console.WriteLine("9. View Students by Name");
                Console.WriteLine("10. Clear All Students");
                Console.WriteLine("11. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddStudentUI();
                }
                else if (choice == "2")
                {
                    FindStudentById();
                }
                else if (choice == "3")
                {
                    FindStudentByName();
                }
                else if (choice == "4")
                {
                    UpdateStudentDetails();
                }
                else if (choice == "5")
                {
                    DeleteStudentById();
                }
                else if (choice == "6")
                {
                    DeleteStudentByName();
                }
                else if (choice == "7")
                {
                    ViewAllStudents();
                }
                else if (choice == "8")
                {
                    ViewStudentsById();
                }
                else if (choice == "9")
                {
                    ViewStudentsByName();
                }
                else if (choice == "10")
                {
                    ClearAllStudents();
                }
                else if (choice == "11")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
            }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        }
        private void AddStudentUI()
        {
            consol.clear();
            consol.writeline("Add Student");
            consol.writeline("Enter Student ID: ");
            int id = int.parse(consol.readline());
            consol.writeline("Enter Student Name: ");
            string name = consol.readline();
            consol.writeline("Enter Student Age: ");
            int age = int.parse(consol.readline());
            consol.writeline("Enter Student Contact Number: ");
            string contactNumber = consol.readline();
            consol.writeline("Enter Student Address: ");
            string address = consol.readline();
            consol.writeline("Enter Student Email: ");
            string email = consol.readline();
            consol.writeline("Enter Student Gender: ");
            string gender = consol.readline();
            consol.writeline("Enter Student Program: ");
            string program = consol.readline();
            consol.writeline("Enter Student Department: ");
            string department = consol.readline();
            consol.writeline("Enter Student Year/Semester: ");
            string year_semester = consol.readline();
            consol.writeline("Enter Student Courses (comma-separated): ");
            List<string> courses = consol.readline().split(',').select(c => c.trim()).tolist();

            consol.writeline("Student added successfully.");
        }
        Console.WriteLine("Exiting... The Application...");
    }

}
