using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class CartItem: IEquatable<CartItem>
    {
        public int CartItemId { get; set; }//Navigation property
        public int ProductId { get; set; }
        public Product Product { get; set; } = null;//Navigation property
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
       // public DateTime PriceExpiryDate { get; set; }
        public CartItem() { 
        }
        public CartItem(int productId, Product product, int quantity, double price, double discount) { 
            ProductId = productId;
            Product = product;
            Quantity = quantity;
            Price = price;
            Discount = discount;
        }

        public bool Equals(CartItem? other)
        {
            return this.CartItemId == other.CartItemId;
        }
    }
}
