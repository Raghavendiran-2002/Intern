using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Purchase : IEquatable<Purchase>
    {
        public int Id { get; set; }
        public double TotalCost { get; set; }

        public int NoOfItem { get{ return NoOfItem; } set{ NoOfItem =  CartItemToPurchase.Count(); } }

        public Dictionary<string, CartItem> CartItemToPurchase { get; set; } = new Dictionary<string, CartItem>();

        public Purchase( double totalcost,CartItem cartItem) { 
            TotalCost = totalcost;
            
            CartItemToPurchase.Add(cartItem.Product.Name,cartItem);
            
        }
        public Purchase()
        {

        }
        public bool Equals(Purchase? other)
        {
            return this.Id == other.Id;
        }
    }
}
