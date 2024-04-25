using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class PurchaseRepository : AbstractRepository<int, Purchase>
    {
        readonly Dictionary<int, Purchase> _purchase;

        public PurchaseRepository()
        {
            _purchase = new Dictionary<int, Purchase>();
        }
        public override Purchase Delete(int key)
        {
            Purchase purchase = GetByKey(key);
            if (purchase != null)
            {
                items.Remove(purchase);
            }
            return purchase;
        }

        public override Purchase GetByKey(int key)
        {
            Purchase purchase = items.FirstOrDefault(p => p.Id == key);
            if (purchase == null)
                throw new UserDefinedException.PurchaseException("Already Exist");
            return purchase;
        }

        public override Purchase Update(Purchase item)
        {
            Purchase purchase = GetByKey(item.Id);
            if (purchase != null)
            {
                purchase = item;
            }
            return purchase;
        }
        public Purchase ResetById(int purchaseId, Purchase item)
        {
            Purchase purchase = GetByKey(item.Id);

            if (purchase == null)
                throw new UserDefinedException.NoProductWithGiveIdException();
            purchase.Id = purchaseId;
            purchase.CartItemToPurchase = new Dictionary<string, CartItem>();
            purchase.TotalCost = 0;
            purchase.NoOfItem = 0;            
            return purchase;
        }
    }
}
