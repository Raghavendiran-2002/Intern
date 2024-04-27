using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface IPurchaseService
    {
        double GenerateBill(Purchase purchasedItem);
        Purchase AddnewCartItem(int purchaseId, int purchaseNoOfItem, CartItem cartitem);

        Purchase AddPurchase(Purchase purchase);
        Purchase GetPurchaseById(int purchaseId);
        Purchase DeletePurchase(int purchaseId);

        Purchase ResetCartItemIntoPurchased(int purchaseId);
    }
}