using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartBL : ICartService
    {
        readonly  IRepository<int, Cart> _cartRepo;

        public CartBL(IRepository<int, Cart> cartRepo)
        {
            _cartRepo = cartRepo;
        }
        public async Task<Cart> AddCart(Cart cart)
        {
            var result = await _cartRepo.Add(cart);
            if (result != null)
            {
                return result;
            }
            throw new UserDefinedException.NoCartWithGiveIdException();
        }

        public async Task<Cart> AddNewProduct(int cartId, CartItem cartitem)
        {
            Cart cart = await _cartRepo.GetByKey(cartId);
            CartItem existedCartItem = cart.CartItems.Find((i) => i.CartItemId == cartitem.CartItemId);
            if (existedCartItem == null)
                throw new UserDefinedException.NoCartItemWithGiveIdException();
            cart.CartItems.Add(cartitem);
            return cart;
        }

        public async Task<List<CartItem>> GetAllCartItems(int cartId)
        {
            List<CartItem> cartitem = new List<CartItem>();
            //_cartRepo.
            return cartitem;
        }

        public async Task<Cart> GetCartById(int cartId)
        {
            Cart cart = await _cartRepo.GetByKey(cartId);
            if (cart != null)
            {
                return cart;
            }
            throw new UserDefinedException.NoCartWithGiveIdException();
        }

        public async Task<Cart> ResetCart(int cartId)
        {
            Cart cart = await _cartRepo.GetByKey(cartId);
            if (cart != null)
            {
                cart.CartItems = new List<CartItem>();
                _cartRepo.Update(cart);
                return cart;
            }
            throw new UserDefinedException.NoCartWithGiveIdException();
        }
    }
}
