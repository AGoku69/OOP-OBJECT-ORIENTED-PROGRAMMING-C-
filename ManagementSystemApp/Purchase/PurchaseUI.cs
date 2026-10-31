using System;
using ManagementSystemApp.Product;
using ManagementSystemApp.Customer;

namespace ManagementSystemApp.Purchase
{
    public class PurchaseUI
    {
        private readonly PurchaseService _purchaseService;
        private readonly ProductService _productService;
        private readonly CustomerService _customerService;

        public PurchaseUI(PurchaseService purchaseService, ProductService productService, CustomerService customerService)
        {
            _purchaseService = purchaseService;
            _productService = productService;
            _customerService = customerService;
        }

        public void PurchaseProductMenu()
        {
            Console.Clear();
            PrintSubHeader("Purchase Product");
            var products = _productService.GetAllProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("No products available for purchase.");
                Pause();
                return;
            }

            Console.Write("Enter your Customer Name to proceed with purchase: ");
            string customerNameInput = Console.ReadLine();

            var customer = _customerService.GetCustomerByName(customerNameInput);
            string buyerName = customer != null ? customer.Name : customerNameInput;

            Console.WriteLine();
            foreach (var p in products)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Name: {p.Name,-15} | Stock: {p.Stock,-5} | Price: ${p.ProductPrice}");
                Console.ResetColor();
            }

            Console.Write("\nEnter the name of the product you want to purchase: ");
            string productName = Console.ReadLine();

            var product = _productService.GetProductByName(productName);

            if (product != null)
            {
                if (product.Stock <= 0)
                {
                    PrintError($"Sorry, '{product.Name}' is currently out of stock.");
                    Pause();
                    return;
                }

                Console.Write($"Enter quantity to purchase (Available stock: {product.Stock}): ");
                if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                {
                    if (quantity <= product.Stock)
                    {
                        _productService.DeductStock(product.Name, quantity);
                        decimal totalPrice = quantity * product.ProductPrice;

                        _purchaseService.AddPurchase(buyerName, product.Name, quantity, totalPrice);

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
            Pause();
        }

        public void ViewMyPurchaseHistoryMenu()
        {
            Console.Clear();
            PrintSubHeader("My Purchase History");
            Console.Write("Enter your name to view your purchase history: ");
            string name = Console.ReadLine();

            var customerPurchases = _purchaseService.GetPurchasesByCustomer(name);

            if (customerPurchases.Count == 0)
            {
                Console.WriteLine($"No purchase history found for '{name}'.");
                Pause();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n--- Purchase History for {name} ---");
            Console.ResetColor();

            foreach (var pur in customerPurchases)
            {
                Console.WriteLine($"Product: {pur.ProductName} | Qty: {pur.Quantity} | Total: ${pur.TotalPrice} | Date: {pur.PurchaseDate}");
            }
            Pause();
        }

        public void ShowAllPurchasesMenu()
        {
            Console.Clear();
            PrintSubHeader("All Purchase History (Admin View)");
            var purchases = _purchaseService.GetAllPurchases();

            if (purchases.Count == 0)
            {
                Console.WriteLine("No purchases recorded yet.");
                Pause();
                return;
            }

            foreach (var pur in purchases)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Customer: {pur.CustomerName,-12} | Product: {pur.ProductName,-10} | Qty: {pur.Quantity,-3} | Total: ${pur.TotalPrice,-6} | Date: {pur.PurchaseDate}");
                Console.ResetColor();
            }
            Pause();
        }

        private void PrintSubHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n--- {title} ---");
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