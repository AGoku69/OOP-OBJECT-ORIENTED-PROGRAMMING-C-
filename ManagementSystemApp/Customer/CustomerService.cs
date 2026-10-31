using System;
using System.Collections.Generic;

namespace ManagementSystemApp.Customer
{
    public class CustomerService
    {
        private readonly CustomerRepository _repository;
        private List<Customer> _customers;

        public CustomerService()
        {
            _repository = new CustomerRepository();
            _customers = _repository.LoadCustomers();
        }

        public void AddCustomer(string name, string contact)
        {
            _customers.Add(new Customer(name, contact));
            _repository.SaveCustomers(_customers);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public Customer GetCustomerByName(string name)
        {
            return _customers.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
