using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class PurchaseBL : IPurchaseService
    {
         static IRepository<int, Purchase> _purchaseRepo;

        public PurchaseBL(IRepository<int, Purchase> purchaseRepo)
        {
            _purchaseRepo = purchaseRepo;
        }

        [ExcludeFromCodeCoverage]
        public async Task<Purchase> AddPurchase(Purchase purchase)
        {
            Purchase purchasevalid = await _purchaseRepo.GetByKey(purchase.Id);
            if(purchasevalid != null )
            {
                throw new UserDefinedException.PurchaseException("Duplicate purchase");
            }
            _purchaseRepo.Add(purchase);
            return purchase;
        }
        public async Task<Purchase> AddnewCartItem(int purchaseId,int purchaseNoOfItem, CartItem cartitem)
        {
            Purchase purchase =await _purchaseRepo.GetByKey(purchaseId);
            double totalCost = 0;
            // If the purchase  has only 3 itemsand has other value of 1500 provide 5 % discount
            if(purchase.CartItemToPurchase.Count() == 3)
            {
                double discountCost = 0;
                foreach (var item in purchase.CartItemToPurchase)
                {
                    discountCost += item.Value.Price;
                }
                if(discountCost == 1500)
                {
                    totalCost =  discountCost - (1500 * 0.05);
                }
                purchase.TotalCost = totalCost;
                _purchaseRepo.Update(purchase);
                return purchase;
            }
            totalCost = 0;
            // The Maximum quantity of a product in cart cannot be more than 5.
            if(cartitem.Quantity > 5)
            {
                Console.WriteLine($"Product Quanatity cannot by more than five");
                // Throw Exception;
            }
            totalCost = 0;
            // All the Product below 100 will be charged a shipping charge of Rs.100
            double shippingCost = 0;
            foreach(var item in purchase.CartItemToPurchase)
            {
                shippingCost += item.Value.Price;
            }
            if (shippingCost < 100)
            {
                totalCost = 100 + shippingCost;
                purchase.TotalCost = totalCost;
                _purchaseRepo.Update(purchase);
                return purchase;
            }
            totalCost = 0;
            // Default 
            foreach (var item in purchase.CartItemToPurchase)
            {
                totalCost += item.Value.Price;
            }
            purchase.TotalCost = totalCost;
            _purchaseRepo.Update(purchase);
            return purchase;
        }

        public async Task<Purchase> DeletePurchase(int purchaseId)
        {
            Purchase purchase =await _purchaseRepo.GetByKey(purchaseId);
            if (purchase != null)
            {
                _purchaseRepo.Delete(purchaseId);
                return purchase;
            }
            throw new UserDefinedException.PurchaseException("Item not found");
        }

        public async Task<double> GenerateBill(Purchase purchasedItem)
        {
            Purchase purchase = await _purchaseRepo.GetByKey(purchasedItem.Id);
            if (purchase == null)
                // purchase unavailable
                throw new UserDefinedException.PurchaseException("purchase unavailable");
            if(purchasedItem.CartItemToPurchase.Count < 1)
            {
                // No Item found to Generate Bill
                throw new UserDefinedException.PurchaseException("no item found to generate bill");
            }
            double totalCost = 0;
            // Default 
            foreach (var item in purchase.CartItemToPurchase)
            {
                totalCost += item.Value.Price;
            }   
            return purchasedItem.TotalCost;
        }

        public async Task<Purchase> GetPurchaseById(int purchaseId)
        {
            Purchase purchase =await _purchaseRepo.GetByKey(purchaseId);
            if (purchase != null)
            {
                return purchase;
            }
            throw new UserDefinedException.PurchaseException("Already Exist");
        }

        public async  Task<Purchase> ResetCartItemIntoPurchased(int purchaseId)
        {
            Purchase purchase = await _purchaseRepo.GetByKey(purchaseId);
            if (purchase != null)
            {
                return await _purchaseRepo.Update(new Purchase());
            }
            throw new UserDefinedException.PurchaseException("Purchase Id Not Found");
        }
    }
}
