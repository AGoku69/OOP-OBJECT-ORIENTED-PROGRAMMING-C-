using System;
using System.Collections.Generic;

namespace ManagementSystemApp.Purchase
{
    public class PurchaseService
    {
        private readonly PurchaseRepository _repository;
        private List<Purchase> _purchases;

        public PurchaseService()
        {
            _repository = new PurchaseRepository();
            _purchases = _repository.LoadPurchases();
        }

        public void AddPurchase(string customerName, string productName, int quantity, decimal totalPrice)
        {
            var purchase = new Purchase(customerName, productName, quantity, totalPrice, DateTime.Now);
            _purchases.Add(purchase);
            _repository.SavePurchases(_purchases);
        }

        public List<Purchase> GetAllPurchases()
        {
            return _purchases;
        }

        public List<Purchase> GetPurchasesByCustomer(string customerName)
        {
            return _purchases.FindAll(p => p.CustomerName.Equals(customerName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
