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
        Task<double> GenerateBill(Purchase purchasedItem);
        Task<Purchase> AddnewCartItem(int purchaseId, int purchaseNoOfItem, CartItem cartitem);

        Task<Purchase> AddPurchase(Purchase purchase);
       Task< Purchase> GetPurchaseById(int purchaseId);
        Task<Purchase> DeletePurchase(int purchaseId);

        Task<Purchase> ResetCartItemIntoPurchased(int purchaseId);
    }
}