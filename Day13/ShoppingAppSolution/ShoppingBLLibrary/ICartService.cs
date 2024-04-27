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
        Task<Cart> AddCart(Cart cart);
        Task<Cart> GetCartById(int cartId);
        Task<Cart> ResetCart(int cartId);

        Task<Cart> AddNewProduct(int cartId, CartItem cartitem);
        Task< List<CartItem>> GetAllCartItems(int cartId);
    }
}
