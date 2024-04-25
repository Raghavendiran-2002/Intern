using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface ICartService
    {
        Cart AddCart(Cart cart);
        Cart GetCartById(int cartId);
        Cart ResetCart(int cartId);

        Cart AddNewProduct(int cartId, CartItem cartitem);
        List<CartItem> GetAllCartItems(int cartId);
    }
}
