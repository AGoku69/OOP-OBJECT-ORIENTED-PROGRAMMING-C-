using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS
{
    class Book
        {
            // Data members
            private int bookID;
            private string title;
            private double price;

            // Default constructor
            public Book()
            {
                bookID = 0;
                title = "Unknown Title";
                price = 0.0;
            }

            // Parameterized constructor
            public Book(int bookID, string title, double price)
            {
                this.bookID = bookID;
                this.title = title;
                this.price = price;
            }

            // Member function to display book information
            public void DisplayInfo()
            {
                Console.WriteLine("Book ID : " + bookID);
                Console.WriteLine("Title   : " + title);
                Console.WriteLine("Price   : Rs. " + price.ToString("F2"));
                Console.WriteLine("-----------------------------");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                // Object using default constructor
                Book book1 = new Book();

                // Object using parameterized constructor
                Book book2 = new Book(101, "Programming in C#", 1500.50);

                Console.WriteLine("===== Book 1 (Default Constructor) =====");
                book1.DisplayInfo();

                Console.WriteLine("===== Book 2 (Parameterized Constructor) =====");
                book2.DisplayInfo();

                Console.ReadKey();
            }
        }
}
