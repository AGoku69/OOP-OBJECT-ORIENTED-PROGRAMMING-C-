using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace task11
{
     class laptop
    {
        public string name;
        public int id;
        public laptop(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        {
            laptop l1 = new laptop("Dell", 100);
            Console.WriteLine("Laptop Name: " + l1.name);
            Console.WriteLine("Laptop ID: " + l1.id);
        }
    }
}
