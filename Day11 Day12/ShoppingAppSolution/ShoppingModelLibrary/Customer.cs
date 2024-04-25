using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Customer: IEquatable<Customer>
    {
        public int Id { get; set; }
        public string Phone { get; set; } = String.Empty;
        public string Name { get; set; }
        public int Age { get; set; }
        public Customer() { }
        public Customer(string name, string phone, int age)
        {
            Name = name;
            Phone = phone;
            Age = age;
        }

        public bool Equals(Customer? other)
        {
            return this.Id.Equals(other.Id);
        }
    }
}
