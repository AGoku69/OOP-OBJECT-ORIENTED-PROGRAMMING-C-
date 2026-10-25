using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task11
{
     class student
    {
        public string name;
        public int id;
        public int classroom;
        static void Main(string[] args)
        {
            student s1 = new student();
            s1.name = "John";
            s1.id = 123;
            Console.WriteLine("Student Name: " + s1.name);
            Console.WriteLine("Student ID: " + s1.id);
            Console.WriteLine("Student Classroom: " + s1.classroom);
            import secondclass();
        }
    }
}
