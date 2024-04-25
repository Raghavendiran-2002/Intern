using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartItemBL : ICartItemService
    {
        readonly IRepository<int, CartItem> _cartItemRepo;

        public CartItemBL(IRepository<int, CartItem> cartItemRepo)
        {
            _cartItemRepo = cartItemRepo;
        }
        public CartItem AddProductIntoCart(CartItem cartitem)
        {
            CartItem result = _cartItemRepo.Add(cartitem);
            if (result != null)
            {
                return result;
            }
            throw new UserDefinedException.NoCartItemWithGiveIdException();
        }

        public CartItem DeleteCartItem(int cartId)
        {
            CartItem cartitem = _cartItemRepo.GetByKey(cartId);
            if (cartitem != null)
            {
                _cartItemRepo.Delete(cartId);
                return cartitem;
            }
            throw new UserDefinedException.NoProductWithGiveIdException();
        }

        public CartItem GetCartById(int cartId)
        {

            CartItem cartitem = _cartItemRepo.GetByKey(cartId);
            if (cartitem != null)
            {
                return cartitem;
            }
            throw new UserDefinedException.NoCartItemWithGiveIdException();
        }

        public CartItem UpdateCartItem(int cartId, CartItem cartItem)
        {
            CartItem cartitem = _cartItemRepo.GetByKey(cartId);
            if (cartitem != null)
            {
                var updatedCartItem = _cartItemRepo.Update(cartItem);
                return updatedCartItem;
            }
            throw new UserDefinedException.NoCartItemWithGiveIdException(); 
        }
    }
}
