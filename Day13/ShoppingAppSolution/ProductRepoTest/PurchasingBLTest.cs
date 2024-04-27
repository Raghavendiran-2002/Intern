using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTest
{
    public class PurchasingBLTest
    {
        IRepository<int, Purchase> repository;
        IPurchaseService purchaseService;      

        [SetUp]
        public void Setup()
        {
            repository = new PurchaseRepository();
            Dictionary<string, CartItem> cartItems = new Dictionary<string, CartItem>();
            Product product1 = new Product(35, "soap", 5);
            Product product2 = new Product(20, "brush", 10);
            cartItems.Add("soap", new CartItem(1, product1, 2, 35, 0));
            Purchase purchase1 = new Purchase() { Id = 1, CartItemToPurchase = cartItems };
            cartItems.Add("brush", new CartItem(1, product2, 6, 20, 0));
            Purchase purchase2 = new Purchase() { Id = 2, CartItemToPurchase = cartItems };
            repository.Add(purchase1);
            repository.Add(purchase2);
            purchaseService = new PurchaseBL(repository);
        }
        [Test]
        public void GetPurchaseByIdSuccess()
        {
            var purchase = purchaseService.GetPurchaseById(1);
            Assert.AreEqual(1, purchase.Id);
        }
        [Test]
        public void GetPurchaseByIdFailed()
        {
            var cnt = purchaseService.GetPurchaseById(1).CartItemToPurchase.Count;
            var purchase = purchaseService.GetPurchaseById(1);
            Assert.AreNotEqual(0, purchase.Id);
        }
        [Test]
        public void GetPurchaseByIdException()
        {
            var exception = Assert.Throws<UserDefinedException.PurchaseException>(() => purchaseService.GetPurchaseById(2));
            Assert.AreNotEqual("Already Exist", exception.Message);
        }
        [Test]
        public void GenerateBillSuccessTest()
        {
            var purchase = purchaseService.GenerateBill(purchaseService.GetPurchaseById(1));

            Assert.AreNotEqual(1, purchase);
        }
        [Test]
        public void GenerateBillFailTest()
        {
            var purchase = purchaseService.GenerateBill(purchaseService.GetPurchaseById(1));

            Assert.AreNotEqual(1, purchase);
        }

        [Test]
        public void GenerateBillExceptionTest()
        {
            var exception = Assert.Throws<UserDefinedException.PurchaseException>(() => purchaseService.GenerateBill(purchaseService.GetPurchaseById(1)));
            Assert.AreEqual("Purchase with the given Id is not present", exception.Message);
        }
        [Test]
        public void DeletePurchaseSuccessTest()
        {
            var purchase = purchaseService.DeletePurchase(1);
            Assert.AreEqual(1, purchase.Id);
        }
        [Test]
        public void DeletePurchaseFailTest()
        {
            var purchase = purchaseService.DeletePurchase(1);
            Assert.AreNotEqual(2, purchase.Id);
        }

        [Test]
        public void DeletePurchaseExceptionTest()
        {
            var exception = Assert.Throws<UserDefinedException.PurchaseException>(() => purchaseService.DeletePurchase(2));
            Assert.AreEqual("Item not found", exception.Message);
        }
        [Test]
        public void ResetCartItemIntoPurchasedSuccessTest()
        {
            Purchase purchase = purchaseService.ResetCartItemIntoPurchased(1);
            Assert.AreEqual(0, purchase.CartItemToPurchase.Count);
        }
        [Test]
        public void ResetCartItemIntoPurchasedFailTest()
        {
            var purchase = purchaseService.ResetCartItemIntoPurchased(1);
            Assert.That(purchase == null);
        }

        [Test]
        public void ResetCartItemIntoPurchasedExceptionTest()
        {
            var exception = Assert.Throws<UserDefinedException.PurchaseException>(() => purchaseService.ResetCartItemIntoPurchased(2));
            Assert.AreEqual("Purchase Id Not Found", exception.Message);
        }
        [Test]
        public void AddnewCartItemSuccessTest()
        {
            CartItem cart =  new CartItem(2, new Product(40, "soap", 5), 3, 40, 0);
            Purchase purchase = purchaseService.AddnewCartItem(1, 3,  cart);
            Assert.AreEqual(0, purchase.TotalCost);
        }
        [Test]
        public void AddnewCartItemFailTest()
        {
            var purchase = purchaseService.ResetCartItemIntoPurchased(1);
            Assert.That(purchase == null);
        }

        [Test]
        public void AddnewCartItemExceptionTest()
        {
            var exception = Assert.Throws<UserDefinedException.PurchaseException>(() => purchaseService.ResetCartItemIntoPurchased(2));
            Assert.AreEqual("Purchase Id Not Found", exception.Message);
        }
    }
}
