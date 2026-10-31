using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystemApp
{
    // Product Class
    public class Product
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal ProductPrice { get; set; }

        public Product(string name, int stock, decimal productPrice)
        {
            Name = name;
            Stock = stock;
            ProductPrice = productPrice;
        }
    }

    // Customer Class
    public class Customer
    {
        public string Name { get; set; }
        public string Contact { get; set; }

        public Customer(string name, string contact)
        {
            Name = name;
            Contact = contact;
        }
    }

    // Purchase Class to track transaction history
    public class Purchase
    {
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        public Purchase(string customerName, string productName, int quantity, decimal totalPrice)
        {
            CustomerName = customerName;
            ProductName = productName;
            Quantity = quantity;
            TotalPrice = totalPrice;
            PurchaseDate = DateTime.Now;
        }
    }

    class Program
    {
        // Lists to store products, customers, and purchases in memory
        static List<Product> products = new List<Product>();
        static List<Customer> customers = new List<Customer>();
        static List<Purchase> purchases = new List<Purchase>();

        // Default admin password
        const string AdminPassword = "admin123";

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                PrintHeader("MANAGEMENT SYSTEM APP");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Admin Login");
                Console.WriteLine("2. Customer Portal");
                Console.WriteLine("3. Exit Program");
                Console.ResetColor();

                Console.Write("\nChoose your role (1-3): ");
                string roleChoice = Console.ReadLine();

                switch (roleChoice)
                {
                    case "1":
                        AdminLogin();
                        break;
                    case "2":
                        CustomerPortal();
                        break;
                    case "3":
                        running = false;
                        PrintSuccess("Exiting program. Good luck with your quiz!");
                        break;
                    default:
                        PrintError("Invalid choice! Please enter 1, 2, or 3.");
                        Pause();
                        break;
                }
            }
        }

        // --- Authentication & Role Menus ---

        static void AdminLogin()
        {
            Console.Clear();
            PrintHeader("ADMIN AUTHENTICATION");

            Console.Write("Enter Admin Password: ");
            string password = Console.ReadLine();

            if (password == AdminPassword)
            {
                PrintSuccess("\nAccess Granted! Welcome, Admin.");
                Pause();
                AdminMenu();
            }
            else
            {
                PrintError("\nIncorrect password! Access denied.");
                Pause();
            }
        }

        static void AdminMenu()
        {
            bool adminRunning = true;

            while (adminRunning)
            {
                Console.Clear();
                PrintHeader("ADMIN MENU");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Add New Product");
                Console.WriteLine("2. Show All Products");
                Console.WriteLine("3. Update Product Stock");
                Console.WriteLine("4. Show All Customers");
                Console.WriteLine("5. Show Purchase History (All)");
                Console.WriteLine("6. Logout / Back to Main Menu");
                Console.ResetColor();

                Console.Write("\nChoose an option (1-6): ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        Pause();
                        break;
                    case "2":
                        ShowProducts();
                        Pause();
                        break;
                    case "3":
                        UpdateProductStock();
                        Pause();
                        break;
                    case "4":
                        ShowCustomers();
                        Pause();
                        break;
                    case "5":
                        ShowPurchases();
                        Pause();
                        break;
                    case "6":
                        adminRunning = false;
                        PrintSuccess("Logging out...");
                        Pause();
                        break;
                    default:
                        PrintError("Invalid choice! Please enter a number between 1 and 6.");
                        Pause();
                        break;
                }
            }
        }

        static void CustomerPortal()
        {
            bool customerRunning = true;

            while (customerRunning)
            {
                Console.Clear();
                PrintHeader("CUSTOMER PORTAL");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Register / Add New Customer Profile");
                Console.WriteLine("2. View Available Products");
                Console.WriteLine("3. Purchase Product");
                Console.WriteLine("4. View My Purchase History");
                Console.WriteLine("5. Back to Main Menu");
                Console.ResetColor();

                Console.Write("\nChoose an option (1-5): ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddCustomer();
                        Pause();
                        break;
                    case "2":
                        ShowProducts();
                        Pause();
                        break;
                    case "3":
                        PurchaseProduct();
                        Pause();
                        break;
                    case "4":
                        ViewMyPurchaseHistory();
                        Pause();
                        break;
                    case "5":
                        customerRunning = false;
                        PrintSuccess("Returning to Main Menu...");
                        Pause();
                        break;
                    default:
                        PrintError("Invalid choice! Please enter a number between 1 and 5.");
                        Pause();
                        break;
                }
            }
        }

        // --- Product Management Methods ---

        static void AddProduct()
        {
            PrintSubHeader("Add New Product");
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Stock Quantity: ");
            if (int.TryParse(Console.ReadLine(), out int stock))
            {
                Console.Write("Enter Product Price: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    products.Add(new Product(name, stock, price));
                    PrintSuccess("Product added successfully!");
                }
                else
                {
                    PrintError("Invalid price format. Product not added.");
                }
            }
            else
            {
                PrintError("Invalid stock format. Product not added.");
            }
        }

        static void ShowProducts()
        {
            PrintSubHeader("All Available Products");
            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }

            foreach (var p in products)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Name: {p.Name,-15} | Stock: {p.Stock,-5} | Price: ${p.ProductPrice}");
                Console.ResetColor();
            }
        }

        static void UpdateProductStock()
        {
            PrintSubHeader("Update Product Stock");
            if (products.Count == 0)
            {
                Console.WriteLine("No products available to update.");
                return;
            }

            ShowProducts();
            Console.Write("\nEnter the name of the product you want to update: ");
            string name = Console.ReadLine();

            Product product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                Console.Write($"Current Stock for '{product.Name}' is {product.Stock}. Enter new stock value: ");
                if (int.TryParse(Console.ReadLine(), out int newStock))
                {
                    product.Stock = newStock;
                    PrintSuccess("Product stock updated successfully!");
                }
                else
                {
                    PrintError("Invalid stock format.");
                }
            }
            else
            {
                PrintError("Product not found.");
            }
        }

        // --- Customer Purchase Methods ---

        static void PurchaseProduct()
        {
            PrintSubHeader("Purchase Product");
            if (products.Count == 0)
            {
                Console.WriteLine("No products available for purchase.");
                return;
            }

            Console.Write("Enter your Customer Name to proceed with purchase: ");
            string customerNameInput = Console.ReadLine();

            Customer customer = customers.Find(c => c.Name.Equals(customerNameInput, StringComparison.OrdinalIgnoreCase));
            string buyerName = customer != null ? customer.Name : customerNameInput;

            Console.WriteLine();
            ShowProducts();

            Console.Write("\nEnter the name of the product you want to purchase: ");
            string productName = Console.ReadLine();

            Product product = products.Find(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                if (product.Stock <= 0)
                {
                    PrintError($"Sorry, '{product.Name}' is currently out of stock.");
                    return;
                }

                Console.Write($"Enter quantity to purchase (Available stock: {product.Stock}): ");
                if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                {
                    if (quantity <= product.Stock)
                    {
                        // Deduct stock
                        product.Stock -= quantity;
                        decimal totalPrice = quantity * product.ProductPrice;

                        // Save the purchase record into the list
                        purchases.Add(new Purchase(buyerName, product.Name, quantity, totalPrice));

                        PrintSuccess("\nPurchase successful!");
                        Console.WriteLine($"-> Buyer: {buyerName}");
                        Console.WriteLine($"-> Product: {product.Name}");
                        Console.WriteLine($"-> Quantity Purchased: {quantity}");
                        Console.WriteLine($"-> Total Price: ${totalPrice}");
                        Console.WriteLine($"-> Remaining Stock: {product.Stock}");
                    }
                    else
                    {
                        PrintError($"Error: Not enough stock available. Only {product.Stock} units left.");
                    }
                }
                else
                {
                    PrintError("Invalid quantity entered. Purchase cancelled.");
                }
            }
            else
            {
                PrintError("Product not found.");
            }
        }

        static void ViewMyPurchaseHistory()
        {
            PrintSubHeader("My Purchase History");
            Console.Write("Enter your name to view your purchase history: ");
            string name = Console.ReadLine();

            var customerPurchases = purchases.FindAll(p => p.CustomerName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (customerPurchases.Count == 0)
            {
                Console.WriteLine($"No purchase history found for '{name}'.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n--- Purchase History for {name} ---");
            Console.ResetColor();

            foreach (var pur in customerPurchases)
            {
                Console.WriteLine($"Product: {pur.ProductName} | Qty: {pur.Quantity} | Total: ${pur.TotalPrice} | Date: {pur.PurchaseDate}");
            }
        }

        static void ShowPurchases()
        {
            PrintSubHeader("All Purchase History (Admin View)");
            if (purchases.Count == 0)
            {
                Console.WriteLine("No purchases recorded yet.");
                return;
            }

            foreach (var pur in purchases)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Customer: {pur.CustomerName,-12} | Product: {pur.ProductName,-10} | Qty: {pur.Quantity,-3} | Total: ${pur.TotalPrice,-6} | Date: {pur.PurchaseDate}");
                Console.ResetColor();
            }
        }

        // --- Customer Management Methods ---

        static void AddCustomer()
        {
            PrintSubHeader("Add New Customer");
            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Customer Contact: ");
            string contact = Console.ReadLine();

            customers.Add(new Customer(name, contact));
            PrintSuccess("Customer added successfully!");
        }

        static void ShowCustomers()
        {
            PrintSubHeader("All Registered Customers");
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers available.");
                return;
            }

            foreach (var c in customers)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Name: {c.Name,-15} | Contact: {c.Contact}");
                Console.ResetColor();
            }
        }

        // --- UI Helper Methods for Styling ---

        static void PrintHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("========================================");
            Console.WriteLine($"        {title}         ");
            Console.WriteLine("========================================");
            Console.ResetColor();
        }

        static void PrintSubHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n--- {title} ---");
            Console.ResetColor();
        }

        static void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
