using System;
using System.Collections.Generic;
using System.IO;

namespace ManagementSystemApp.Purchase
{
    public class PurchaseRepository
    {
        private readonly string filePath = "purchases.txt";

        public List<Purchase> LoadPurchases()
        {
            var purchases = new List<Purchase>();
            if (!File.Exists(filePath)) return purchases;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 5 &&
                    int.TryParse(parts[2], out int quantity) &&
                    decimal.TryParse(parts[3], out decimal price) &&
                    DateTime.TryParse(parts[4], out DateTime date))
                {
                    purchases.Add(new Purchase(parts[0], parts[1], quantity, price, date));
                }
            }
            return purchases;
        }

        public void SavePurchases(List<Purchase> purchases)
        {
            var lines = new List<string>();
            foreach (var p in purchases)
            {
                lines.Add($"{p.CustomerName},{p.ProductName},{p.Quantity},{p.TotalPrice},{p.PurchaseDate}");
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}