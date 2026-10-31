namespace ManagementSystemApp.Customer
{
    public class Customer
    {
        public string Name { get; set; }
        public string Contact { get; set; }

        public Customer(string name, string contact)
        {
            Name = name;
            Contact = contact;
        }
    }
}
