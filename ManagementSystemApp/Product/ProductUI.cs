using System;

namespace ManagementSystemApp.Product
{
    public class ProductUI
    {
        private readonly ProductService _productService;

        public ProductUI(ProductService productService)
        {
            _productService = productService;
        }

        public void AddProductMenu()
        {
            Console.Clear();
            PrintSubHeader("Add New Product");
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Stock Quantity: ");
            if (int.TryParse(Console.ReadLine(), out int stock))
            {
                Console.Write("Enter Product Price: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    _productService.AddProduct(name, stock, price);
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
            Pause();
        }

        public void ShowProductsMenu()
        {
            Console.Clear();
            PrintSubHeader("All Available Products");
            var products = _productService.GetAllProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
                Pause();
                return;
            }

            foreach (var p in products)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Name: {p.Name,-15} | Stock: {p.Stock,-5} | Price: ${p.ProductPrice}");
                Console.ResetColor();
            }
            Pause();
        }

        public void UpdateProductStockMenu()
        {
            Console.Clear();
            PrintSubHeader("Update Product Stock");
            var products = _productService.GetAllProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("No products available to update.");
                Pause();
                return;
            }

            foreach (var p in products)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Name: {p.Name,-15} | Stock: {p.Stock,-5}");
                Console.ResetColor();
            }

            Console.Write("\nEnter the name of the product you want to update: ");
            string name = Console.ReadLine();

            var product = _productService.GetProductByName(name);

            if (product != null)
            {
                Console.Write($"Current Stock for '{product.Name}' is {product.Stock}. Enter new stock value: ");
                if (int.TryParse(Console.ReadLine(), out int newStock))
                {
                    _productService.UpdateStock(name, newStock);
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