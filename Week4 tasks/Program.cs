using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
    class Student
    {
        public int RollNumber { get; private set; }
        public string Name { get; private set; }
        public double GPA { get; private set; }
        public Department Department { get; set; }          // null until enrolled
        public List<Student> Friends { get; private set; }

        public Student(int rollNumber, string name, double gpa)
        {
            RollNumber = rollNumber;
            Name = name;
            GPA = gpa;
            Department = null;
            Friends = new List<Student>();
        }

        // Copy constructor: new student built from an existing one.
        // The friend list is a NEW list (same friends, separate collection),
        // so changes to either list never affect the other.
        public Student(Student other, int newRollNumber)
        {
            RollNumber = newRollNumber;
            Name = other.Name;
            GPA = other.GPA;
            Department = null;                       // enroll separately
            Friends = new List<Student>(other.Friends);
        }

        public bool AddFriend(Student friend)
        {
            if (friend == null || friend == this || Friends.Contains(friend))
                return false;
            Friends.Add(friend);
            return true;
        }

        public void DisplayDetails()
        {
            string dept = Department == null ? "Not enrolled" : Department.Name;
            Console.WriteLine($"Roll No: {RollNumber} | Name: {Name} | GPA: {GPA:F2} | Department: {dept}");
        }

        public void DisplayFriends()
        {
            if (Friends.Count == 0)
            {
                Console.WriteLine($"{Name} has no friends yet.");
                return;
            }
            Console.WriteLine($"Friends of {Name}:");
            foreach (Student f in Friends)
                f.DisplayDetails();
        }
    }

    class Department
    {
        public string Name { get; private set; }
        public List<Student> Students { get; private set; }

        public Department(string name)
        {
            Name = name;
            Students = new List<Student>();
        }

        public bool Enroll(Student student)
        {
            if (student == null || Students.Contains(student))
                return false;

            // A student belongs to one department: remove from the old one first.
            if (student.Department != null && student.Department != this)
                student.Department.Students.Remove(student);

            Students.Add(student);
            student.Department = this;
            return true;
        }

        public void DisplayStudents()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine($"No students enrolled in {Name}.");
                return;
            }
            Console.WriteLine($"Students in {Name}:");
            foreach (Student s in Students)
                s.DisplayDetails();
        }
    }

    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Department> departments = new List<Department>();

        static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("\n===== University Student Management System =====");
                Console.WriteLine("1. Add a new student");
                Console.WriteLine("2. Create a department");
                Console.WriteLine("3. Enroll a student in a department");
                Console.WriteLine("4. Add a friend to a student");
                Console.WriteLine("5. Display all students");
                Console.WriteLine("6. Display students of a department");
                Console.WriteLine("7. Display the friends of a student");
                Console.WriteLine("8. Create a student using an existing student's details");
                Console.WriteLine("9. Exit");
                choice = ReadInt("Enter your choice: ");

                switch (choice)
                {
                    case 1: AddStudent(); break;
                    case 2: CreateDepartment(); break;
                    case 3: EnrollStudent(); break;
                    case 4: AddFriend(); break;
                    case 5: DisplayAllStudents(); break;
                    case 6: DisplayDepartmentStudents(); break;
                    case 7: DisplayFriends(); break;
                    case 8: CopyStudent(); break;
                    case 9: Console.WriteLine("Goodbye!"); break;
                    default: Console.WriteLine("Invalid choice. Please enter 1-9."); break;
                }
            } while (choice != 9);
        }

        // ---------- Menu actions ----------

        static void AddStudent()
        {
            int roll = ReadInt("Roll number: ");
            if (FindStudent(roll) != null)
            {
                Console.WriteLine("A student with this roll number already exists.");
                return;
            }
            string name = ReadString("Name: ");
            double gpa = ReadGpa("GPA (0.0 - 4.0): ");

            students.Add(new Student(roll, name, gpa));
            Console.WriteLine("Student added successfully.");
        }

        static void CreateDepartment()
        {
            string name = ReadString("Department name: ");
            if (FindDepartment(name) != null)
            {
                Console.WriteLine("This department already exists.");
                return;
            }
            departments.Add(new Department(name));
            Console.WriteLine("Department created successfully.");
        }

        static void EnrollStudent()
        {
            Student s = PromptStudent("Roll number of student to enroll: ");
            if (s == null) return;
            Department d = PromptDepartment("Department name: ");
            if (d == null) return;

            if (d.Enroll(s))
                Console.WriteLine($"{s.Name} enrolled in {d.Name}.");
            else
                Console.WriteLine($"{s.Name} is already enrolled in {d.Name}.");
        }

        static void AddFriend()
        {
            Student s = PromptStudent("Roll number of the student: ");
            if (s == null) return;
            Student f = PromptStudent("Roll number of the friend to add: ");
            if (f == null) return;

            if (s.AddFriend(f))
                Console.WriteLine($"{f.Name} added as a friend of {s.Name}.");
            else
                Console.WriteLine("Could not add friend (a student cannot befriend themselves or add the same friend twice).");
        }

        static void DisplayAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }
            Console.WriteLine("All students:");
            foreach (Student s in students)
                s.DisplayDetails();
        }

        static void DisplayDepartmentStudents()
        {
            Department d = PromptDepartment("Department name: ");
            if (d == null) return;
            d.DisplayStudents();
        }

        static void DisplayFriends()
        {
            Student s = PromptStudent("Roll number of the student: ");
            if (s == null) return;
            s.DisplayFriends();
        }

        static void CopyStudent()
        {
            Student original = PromptStudent("Roll number of the existing student to copy: ");
            if (original == null) return;

            int newRoll = ReadInt("Roll number for the new student: ");
            if (FindStudent(newRoll) != null)
            {
                Console.WriteLine("A student with this roll number already exists.");
                return;
            }

            Student copy = new Student(original, newRoll);
            students.Add(copy);
            Console.WriteLine($"New student created from {original.Name}'s details (name, GPA, friends copied).");
            Console.WriteLine("Use option 3 to enroll the new student in a department.");
        }

        // ---------- Lookup helpers ----------

        static Student FindStudent(int roll)
        {
            foreach (Student s in students)
                if (s.RollNumber == roll) return s;
            return null;
        }

        static Department FindDepartment(string name)
        {
            foreach (Department d in departments)
                if (string.Equals(d.Name, name, StringComparison.OrdinalIgnoreCase)) return d;
            return null;
        }

        static Student PromptStudent(string prompt)
        {
            int roll = ReadInt(prompt);
            Student s = FindStudent(roll);
            if (s == null) Console.WriteLine("Student not found.");
            return s;
        }

        static Department PromptDepartment(string prompt)
        {
            string name = ReadString(prompt);
            Department d = FindDepartment(name);
            if (d == null) Console.WriteLine("Department not found.");
            return d;
        }

        // ---------- Input helpers ----------

        static int ReadInt(string prompt)
        {
            int value;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out value))
                Console.Write("Invalid number. " + prompt);
            return value;
        }

        static string ReadString(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Input cannot be empty. " + prompt);
                input = Console.ReadLine();
            }
            return input.Trim();
        }

        static double ReadGpa(string prompt)
        {
            double value;
            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out value) || value < 0.0 || value > 4.0)
                Console.Write("Invalid GPA. " + prompt);
            return value;
        }
    }
}
