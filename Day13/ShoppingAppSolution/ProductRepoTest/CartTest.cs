using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTest
{
    public class CartTest
    {

        IRepository<int, Cart> repository;
        ICartService cartService;
        [SetUp]
        public void Setup()
        {
            repository = new CartRepository();
            Cart cart1 = new Cart(1, new CartItem(1, new Product(40, "mouse", 5), 4, 40, 0));
            Cart cart2 = new Cart(1, new CartItem(2, new Product(500, "monitor", 7), 2, 500, 0));

            repository.Add(cart1);
            repository.Add(cart2);
            cartService = new CartBL(repository);
        }
        [Test]
        public void GetByIdSuccess()
        {
            var cart = cartService.GetCartById(1);
            Assert.AreEqual(1, cart.Id);
        }
        [Test]
        public void GetByIdFailed()
        {
            var cart = cartService.GetCartById(1);
            Assert.AreNotEqual(2, cart.Id);
        }
        [Test]
        public void GetByIdException()
        {
            var exception = Assert.Throws<UserDefinedException.NoCustomerWithGiveIdException>(() => cartService.GetCartById(2));
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }
        [Test]
        public void ResetCartSuccessTest()
        {
            var cart = cartService.ResetCart(1);
            Assert.AreEqual(1, cart.Id);
        }
        [Test]
        public void ResetCartFailTest()
        {
            var cart = cartService.ResetCart(0);
            Assert.AreNotEqual(1, cart.Id);
        }

        [Test]
        public void ResetCartExceptionTest()
        {
            var exception = Assert.Throws<UserDefinedException.NoCustomerWithGiveIdException>(() => cartService.ResetCart(2));
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }
        [Test]
        public void AddNewProductSuccessTest()
        {
            var cart = cartService.AddNewProduct(0, new CartItem(1, new Product(400, "keyboard", 5), 4, 40, 0));
            Assert.AreEqual("keyboard", cart.CartItems.Find(k => k.Product.Id == 1).Product.Name);
        }
        [Test]
        public void AddNewProductFailTest()
        {
            var cart = cartService.AddNewProduct(1, new CartItem(4, new Product(400, "keyboard", 5), 4, 40, 0));
            Assert.AreNotEqual("keyboard", cart.CartItems.Find(k => k.Product.Id == 0).Product.Name);
        }

        [Test]
        public void AddNewProductExceptionTest()
        {
            var exception = Assert.Throws<UserDefinedException.PurchaseException>(() => cartService.AddNewProduct(2, new CartItem(1, new Product(400, "keyboard", 5), 4, 40, 0)));
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }
        [Test]
        public void GetAllCartItemsSuccessTest()
        {
            var cart = cartService.GetAllCartItems(cartService.GetCartById(1).Id);
            Assert.AreEqual(2, cart.Count);
        }
        [Test]
        public void GetAllCartItemsFailTest()
        {
            var cart = cartService.AddNewProduct(0, new CartItem(1, new Product(400, "keyboard", 5), 4, 40, 0));
            Assert.AreNotEqual("keyboard", cart.CartItems.Find(k => k.Product.Id == 1).Product.Name);
        }

        [Test]
        public void GetAllCartItemsExceptionTest()
        {
            var exception = Assert.Throws<UserDefinedException.NoCustomerWithGiveIdException>(() => cartService.AddNewProduct(2, new CartItem(1, new Product(400, "keyboard", 5), 4, 40, 0)));
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }


    }
}
