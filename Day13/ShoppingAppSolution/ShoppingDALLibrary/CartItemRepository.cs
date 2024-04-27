using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartItemRepository : AbstractRepository<int, CartItem>
    {
        readonly Dictionary<int, CartItem> _cartItem;

        public CartItemRepository()
        {
            _cartItem = new Dictionary<int, CartItem>();
        }
        public override async Task<CartItem> Delete(int key)
        {
            CartItem cartitem = await GetByKey(key);
            if(cartitem != null)
            {
                items.Remove(cartitem);
            }
            return cartitem;
        }

        public override async Task<CartItem> GetByKey(int key)
        {
            CartItem cartitem = items.FirstOrDefault(p => p.CartItemId == key);
            if(cartitem == null ) 
                throw new UserDefinedException.NoCartItemWithGiveIdException(); 
            return cartitem;
        }

        public override async Task<CartItem> Update(CartItem item)
        {
            CartItem cartitem = await GetByKey(item.CartItemId);
            if(cartitem !=null) {
                cartitem = item;
            }
            return cartitem;
        }
    }
}
