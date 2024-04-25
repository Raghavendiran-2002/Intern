using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Cart : IEquatable<Cart>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public List<CartItem> CartItems { get; set; } =new  List<CartItem>();//Navigation property

        public Cart(int customerId, CartItem cart) {
            Id = customerId;
            CartItems.Add(cart);
        }
        public Cart() { }
        public bool Equals(Cart? other)
        {
            return this.Id == other.Id;
        }
    }
}
