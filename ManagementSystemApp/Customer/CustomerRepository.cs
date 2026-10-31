using System.Collections.Generic;
using System.IO;

namespace ManagementSystemApp.Customer
{
    public class CustomerRepository
    {
        private readonly string filePath = "customers.txt";

        public List<Customer> LoadCustomers()
        {
            var customers = new List<Customer>();
            if (!File.Exists(filePath)) return customers;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 2)
                {
                    customers.Add(new Customer(parts[0], parts[1]));
                }
            }
            return customers;
        }

        public void SaveCustomers(List<Customer> customers)
        {
            var lines = new List<string>();
            foreach (var c in customers)
            {
                lines.Add($"{c.Name},{c.Contact}");
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}
