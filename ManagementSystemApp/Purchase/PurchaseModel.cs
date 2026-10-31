using System;

namespace ManagementSystemApp.Purchase
{
    public class Purchase
    {
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        public Purchase(string customerName, string productName, int quantity, decimal totalPrice, DateTime purchaseDate)
        {
            CustomerName = customerName;
            ProductName = productName;
            Quantity = quantity;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
        }
    }
}
