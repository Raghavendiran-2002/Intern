using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface ICartItemService
    {

        Task<CartItem> AddProductIntoCart(CartItem cartitem);
        Task<CartItem> GetCartById(int cartId);
        Task<CartItem> DeleteCartItem(int cartId);
        Task<CartItem> UpdateCartItem(int cartId, CartItem cartItem);
    }
}
