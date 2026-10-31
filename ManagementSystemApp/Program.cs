using System;
using ManagementSystemApp.Product;
using ManagementSystemApp.Customer;
using ManagementSystemApp.Purchase;

namespace ManagementSystemApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize Services
            var productService = new ProductService();
            var customerService = new CustomerService();
            var purchaseService = new PurchaseService();

            // Initialize UIs
            var productUI = new ProductUI(productService);
            var customerUI = new CustomerUI(customerService);
            var purchaseUI = new PurchaseUI(purchaseService, productService, customerService);
            var adminUI = new AdminUI(productUI, customerUI, purchaseUI);

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
                        adminUI.AdminLogin();
                        break;
                    case "2":
                        CustomerPortal(customerUI, productUI, purchaseUI);
                        break;
                    case "3":
                        running = false;
                        PrintSuccess("Exiting program!");
                        break;
                    default:
                        PrintError("Invalid choice! Please enter 1, 2, or 3.");
                        Pause();
                        break;
                }
            }
        }

        static void CustomerPortal(CustomerUI customerUI, ProductUI productUI, PurchaseUI purchaseUI)
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

                switch (choice)
                {
                    case "1":
                        customerUI.AddCustomerMenu();
                        break;
                    case "2":
                        productUI.ShowProductsMenu();
                        break;
                    case "3":
                        purchaseUI.PurchaseProductMenu();
                        break;
                    case "4":
                        purchaseUI.ViewMyPurchaseHistoryMenu();
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

        static void PrintHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("========================================");
            Console.WriteLine($"          {title}                      ");
            Console.WriteLine("========================================");
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
