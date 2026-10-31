using System;
using System.Collections.Generic;
using System.IO;

namespace ManagementSystemApp.Product
{
    public class ProductRepository
    {
        private readonly string filePath = "products.txt";

        public List<Product> LoadProducts()
        {
            var products = new List<Product>();
            if (!File.Exists(filePath)) return products;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 3 && int.TryParse(parts[1], out int stock) && decimal.TryParse(parts[2], out decimal price))
                {
                    products.Add(new Product(parts[0], stock, price));
                }
            }
            return products;
        }

        public void SaveProducts(List<Product> products)
        {
            var lines = new List<string>();
            foreach (var p in products)
            {
                lines.Add($"{p.Name},{p.Stock},{p.ProductPrice}");
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}