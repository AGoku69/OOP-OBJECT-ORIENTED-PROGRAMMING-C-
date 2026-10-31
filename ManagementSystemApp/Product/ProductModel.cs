namespace ManagementSystemApp.Product
{
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
}