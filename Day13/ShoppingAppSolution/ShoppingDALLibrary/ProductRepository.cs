using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        readonly Dictionary<int, Product> _product;

        public ProductRepository()
        {
            _product = new Dictionary<int, Product>();
        }
        public override async Task<Product> Delete(int key)
        {
            Product product =await GetByKey(key);
            if (product != null)
            {
                items.Remove(product);
            }
            return product;
        }

        public override async Task<Product> GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new UserDefinedException.NoProductWithGiveIdException();
        }

        public override async Task<Product> Update(Product item)
        {
            Product product =await  GetByKey(item.Id);
            if (product != null)
            {
                product = item;
            }
            return product;
        }
        
        public override async Task<ICollection<Product>> GetAll()
        {
            ICollection<Product> prodlist = new List<Product>();
            if(items.Count == 0)
            {
                // No Items found
                throw new UserDefinedException.NoCartItemWithGiveIdException();
            }
            for (int i = 0; i < items.Count; i++)
            {
                prodlist.Add(items[i]);
            }
            return prodlist;
        }
    }
}
