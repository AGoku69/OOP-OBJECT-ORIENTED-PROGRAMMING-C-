using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS
{
    class StudentResult
        {
            // Data members
            private int studentId;
            private string name;
            private string department;
            private int semester;
            private double marksOfSubject1;
            private double marksOfSubject2;
            private double marksOfSubject3;
            private double marksOfSubject4;
            private double marksOfSubject5;

            // Parameterized constructor
            public StudentResult(int studentId, string name, string department, int semester,
                                 double m1, double m2, double m3, double m4, double m5)
            {
                this.studentId = studentId;
                this.name = name;
                this.department = department;
                this.semester = semester;
                this.marksOfSubject1 = m1;
                this.marksOfSubject2 = m2;
                this.marksOfSubject3 = m3;
                this.marksOfSubject4 = m4;
                this.marksOfSubject5 = m5;
            }

            // Calculate the total marks
            public double CalculateTotal()
            {
                return marksOfSubject1 + marksOfSubject2 + marksOfSubject3 +
                       marksOfSubject4 + marksOfSubject5;
            }

            // Calculate the average marks
            public double CalculateAverage()
            {
                return CalculateTotal() / 5;
            }

            // Determine the grade of the student (each subject out of 100)
            public string DetermineGrade()
            {
                double avg = CalculateAverage();

                if (avg >= 90) return "A+";
                else if (avg >= 80) return "A";
                else if (avg >= 70) return "B";
                else if (avg >= 60) return "C";
                else if (avg >= 50) return "D";
                else return "F";
            }

            // Return the complete student result with all details
            public string GetCompleteResult()
            {
                return "========== STUDENT RESULT ==========\n" +
                       "Student ID   : " + studentId + "\n" +
                       "Name         : " + name + "\n" +
                       "Department   : " + department + "\n" +
                       "Semester     : " + semester + "\n" +
                       "------------------------------------\n" +
                       "Subject 1    : " + marksOfSubject1 + "\n" +
                       "Subject 2    : " + marksOfSubject2 + "\n" +
                       "Subject 3    : " + marksOfSubject3 + "\n" +
                       "Subject 4    : " + marksOfSubject4 + "\n" +
                       "Subject 5    : " + marksOfSubject5 + "\n" +
                       "------------------------------------\n" +
                       "Total Marks  : " + CalculateTotal() + " / 500\n" +
                       "Average      : " + CalculateAverage().ToString("F2") + "\n" +
                       "Grade        : " + DetermineGrade() + "\n" +
                       "====================================";
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                StudentResult student1 = new StudentResult(
                    15, "Abdullah Huda", "Gaming and Animation", 3,
                    85, 78, 92, 88, 76);

                Console.WriteLine(student1.GetCompleteResult());

                Console.WriteLine();

                StudentResult student2 = new StudentResult(
                    25, "Iraj Akhtar", "Gaming and Animation", 3,
                    65, 58, 72, 60, 55);

                Console.WriteLine(student2.GetCompleteResult());

                Console.ReadKey();
            }
        }
}
