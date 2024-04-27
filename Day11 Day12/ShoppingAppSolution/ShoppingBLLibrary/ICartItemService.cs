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

        CartItem AddProductIntoCart(CartItem cartitem);
        CartItem GetCartById(int cartId);
        CartItem DeleteCartItem(int cartId);
        CartItem UpdateCartItem(int cartId, CartItem cartItem);
    }
}
