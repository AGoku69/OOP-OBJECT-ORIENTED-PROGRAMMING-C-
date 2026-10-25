using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task13
{
    class BOOK
    {
        public string title;
        public string Author;
        public int Pages;
        public int price;
        public bool available;
        public int bookmark;
        public List<string> chapters;
        public BOOK(string title, string author, int pages, int price, bool available, int bookmark, List<string> chapters)
        {
            this.title = title;
            this.Author = author;
            this.Pages = pages;
            this.price = price;
            this.available = available;
            this.bookmark = bookmark;
            this.chapters = chapters;

        }
        public BOOK(BOOK b)
        {
            this.title = b.title;
            this.Author = b.Author;
            this.Pages = b.Pages;
            this.price = b.price;
            this.available = b.available;
            this.bookmark = b.bookmark;
            this.chapters = new List<string>(b.chapters);
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Title: {title}\n Author: {Author}\n Pages: {Pages}\n Price: {price}\n Available: {available}\n Bookmark: {bookmark}\n Chapters: {string.Join(", ", chapters)}\n");
        }
        public bool IsAvailable(bool b_available)
        {
            if (b_available)
            {
                available = b_available;
                Console.WriteLine($"The book is available. {b_available}");
            }
            else
            {
                available = b_available;
                Console.WriteLine($"The book is not available. {b_available}");
            }
            return b_available;
        }
        public void getchapters()
        {
            Console.WriteLine($"Chapters: {string.Join(", ", chapters)}");
        }
        public void setbookmark(int bm_page)
        {
            if (bm_page <= Pages)
            {
                bookmark = bm_page;
                Console.WriteLine($"Bookmark set to page {bookmark}.");
            }
            else
            {
                Console.WriteLine("Invalid page number.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BOOK b1 = new BOOK("Book1", "Author1", 100, 10, false, 0, new List<string> { "Chapter1", "Chapter2" });
            BOOK b2 = new BOOK("Book2", "Author2", 200, 20, false, 0, new List<string> { "Chapter1", "Chapter2", "Chapter3" });
            BOOK b3 = new BOOK("Book3", "Author3", 300, 30, false, 0, new List<string> { "Chapter1", "Chapter2", "Chapter3", "Chapter4" });
            BOOK b4 = new BOOK(b1);

            // Set bookmarks for each book
            int[] bookmark_page = new int[3];
            Console.WriteLine("Enter the page number to set the bookmark:");
            for (int i = 0; i < bookmark_page.Length; i++)
            {
                Console.WriteLine($"Book {i + 1}: ");
                bookmark_page[i] = int.Parse(Console.ReadLine());
            }
            b1.setbookmark(bookmark_page[0]);
            b2.setbookmark(bookmark_page[1]);
            b3.setbookmark(bookmark_page[2]);

            // Set availability for each book
            bool[] availibility = new bool[3];
            Console.WriteLine("Enter the availability of the books (true/false):");
            for(int i = 0; i < availibility.Length; i++)
            {
                Console.WriteLine($"Book {i + 1}: ");
                availibility[i] = bool.Parse(Console.ReadLine());
            }

            // Check availability for each book
            b1.IsAvailable(availibility[0]);
            b2.IsAvailable(availibility[1]);
            b3.IsAvailable(availibility[2]);
            // Display chapters for each book
            b1.getchapters();
            b2.getchapters();
            b3.getchapters();
            // Display information for each book
            b1.ShowInfo();
            b2.ShowInfo();
            b3.ShowInfo();
            b4.ShowInfo();

        }
    }
}
