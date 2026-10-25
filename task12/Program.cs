using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task12
{
    class BankAccount
    {
        public int accountNo;
        public string name;
        public double balance;

        public void Deposit(double amount)
        {
            if (amount > 0)
                balance += amount;
        }
    }
    class Student
    {
        public string name;
        public int rollNo;
        public double m1, m2, m3;

        public double CalculateAverage()
        {
            return (m1 + m2 + m3) / 3;
        }

        public string GetGrade()
        {
            double avg = CalculateAverage();
            if (avg >= 80) return "A";
            else if (avg >= 60) return "B";
            else if (avg >= 40) return "C";
            else return "F";
        }
    }
    class Product
    {
        public string name;
        public double price;
        public int quantity;

        public void ApplyDiscount(double percent)
        {
            price = price - (price * percent / 100);
        }

        public double GetTotal()
        {
            return price * quantity;
        }
    }

    class Program
    {
        static void Main()
        {
            // BankAccount example
            Console.WriteLine("\n Bank Account Part \n");
            BankAccount acc = new BankAccount();

            Console.Write("Enter account number: ");
            acc.accountNo = int.Parse(Console.ReadLine());

            Console.Write("Enter name: ");
            acc.name = Console.ReadLine();

            Console.Write("Enter starting balance: ");
            acc.balance = double.Parse(Console.ReadLine());

            Console.Write("Enter amount to deposit: ");
            double amount = double.Parse(Console.ReadLine());

            acc.Deposit(amount);
            Console.WriteLine("Account Number: " + acc.accountNo);
            Console.WriteLine("Name: " + acc.name);
            Console.WriteLine("Balance: " + acc.balance);

            // Student example
            Console.WriteLine("\n Student Part \n");
            Student s = new Student();

            Console.Write("Enter name: ");
            s.name = Console.ReadLine();

            Console.Write("Enter roll number: ");
            s.rollNo = int.Parse(Console.ReadLine());

            Console.Write("Enter marks in subject 1: ");
            s.m1 = double.Parse(Console.ReadLine());
            Console.Write("Enter marks in subject 2: ");
            s.m2 = double.Parse(Console.ReadLine());
            Console.Write("Enter marks in subject 3: ");
            s.m3 = double.Parse(Console.ReadLine());

            Console.WriteLine("Average: " + s.CalculateAverage());
            Console.WriteLine("Grade: " + s.GetGrade());

            // Product example
            Console.WriteLine("\n Product Part \n");
            Console.Write("How many products? ");
            int n = int.Parse(Console.ReadLine());

            Product[] products = new Product[n];
            double grandTotal = 0;

            for (int i = 0; i < n; i++)
            {
                products[i] = new Product();

                Console.Write("Enter product name: ");
                products[i].name = Console.ReadLine();

                Console.Write("Enter price: ");
                products[i].price = double.Parse(Console.ReadLine());

                Console.Write("Enter quantity: ");
                products[i].quantity = int.Parse(Console.ReadLine());

                Console.Write("Enter discount %: ");
                products[i].ApplyDiscount(double.Parse(Console.ReadLine()));

                grandTotal += products[i].GetTotal();
            }
            Console.WriteLine("Grand Total: " + grandTotal);
        }
    }
}
