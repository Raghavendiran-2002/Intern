using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        readonly Dictionary<int, Cart> _cart;

        public CartRepository()
        {
            _cart = new Dictionary<int, Cart>();
        }
        public override Cart Delete(int key)
        {
            Cart cart =GetByKey(key);
            if(cart != null)
            {
                items.Remove(cart);
            }
            return cart;
        }

        public override Cart GetByKey(int key)
        {
            Cart cart = items.FirstOrDefault(p => p.Id == key);
            if (cart == null)
                throw new UserDefinedException.NoCartWithGiveIdException();
            return cart;
        }   

        public override Cart Update(Cart item)
        {
            Cart cart = GetByKey(item.Id);
            if(cart != null)
            {
                cart = item;
            }
            return cart;
        }
    }
}
