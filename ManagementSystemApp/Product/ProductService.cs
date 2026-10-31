using System;
using System.Collections.Generic;

namespace ManagementSystemApp.Product
{
    public class ProductService
    {
        private readonly ProductRepository _repository;
        private List<Product> _products;

        public ProductService()
        {
            _repository = new ProductRepository();
            _products = _repository.LoadProducts();
        }

        public void AddProduct(string name, int stock, decimal price)
        {
            _products.Add(new Product(name, stock, price));
            _repository.SaveProducts(_products);
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductByName(string name)
        {
            return _products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void UpdateStock(string name, int newStock)
        {
            var product = GetProductByName(name);
            if (product != null)
            {
                product.Stock = newStock;
                _repository.SaveProducts(_products);
            }
        }

        public void DeductStock(string name, int quantity)
        {
            var product = GetProductByName(name);
            if (product != null)
            {
                product.Stock -= quantity;
                _repository.SaveProducts(_products);
            }
        }
    }
}