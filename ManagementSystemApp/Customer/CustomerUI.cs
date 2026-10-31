using System;

namespace ManagementSystemApp.Customer
{
    public class CustomerUI
    {
        private readonly CustomerService _customerService;

        public CustomerUI(CustomerService customerService)
        {
            _customerService = customerService;
        }

        public void AddCustomerMenu()
        {
            Console.Clear();
            PrintSubHeader("Add New Customer");
            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Customer Contact: ");
            string contact = Console.ReadLine();

            _customerService.AddCustomer(name, contact);
            PrintSuccess("Customer added successfully!");
            Pause();
        }

        public void ShowCustomersMenu()
        {
            Console.Clear();
            PrintSubHeader("All Registered Customers");
            var customers = _customerService.GetAllCustomers();

            if (customers.Count == 0)
            {
                Console.WriteLine("No customers available.");
                Pause();
                return;
            }

            foreach (var c in customers)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Name: {c.Name,-15} | Contact: {c.Contact}");
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

        private void Pause()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
