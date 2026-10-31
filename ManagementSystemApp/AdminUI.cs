using System;
using ManagementSystemApp.Product;
using ManagementSystemApp.Customer;
using ManagementSystemApp.Purchase;

namespace ManagementSystemApp
{
    public class AdminUI
    {
        private const string AdminPassword = "admin123";
        private readonly ProductUI _productUI;
        private readonly CustomerUI _customerUI;
        private readonly PurchaseUI _purchaseUI;

        public AdminUI(ProductUI productUI, CustomerUI customerUI, PurchaseUI purchaseUI)
        {
            _productUI = productUI;
            _customerUI = customerUI;
            _purchaseUI = purchaseUI;
        }

        public void AdminLogin()
        {
            Console.Clear();
            PrintHeader("ADMIN AUTHENTICATION");

            Console.Write("Enter Admin Password: ");
            string password = Console.ReadLine();

            if (password == AdminPassword)
            {
                PrintSuccess("\nAccess Granted! Welcome, Admin.");
                Pause();
                OpenAdminMenu();
            }
            else
            {
                PrintError("\nIncorrect password! Access denied.");
                Pause();
            }
        }

        private void OpenAdminMenu()
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

                switch (choice)
                {
                    case "1":
                        _productUI.AddProductMenu();
                        break;
                    case "2":
                        _productUI.ShowProductsMenu();
                        break;
                    case "3":
                        _productUI.UpdateProductStockMenu();
                        break;
                    case "4":
                        _customerUI.ShowCustomersMenu();
                        break;
                    case "5":
                        _purchaseUI.ShowAllPurchasesMenu();
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

        private void PrintHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("========================================");
            Console.WriteLine($"        {title}         ");
            Console.WriteLine("========================================");
            Console.ResetColor();
        }

        private void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private void Pause()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
