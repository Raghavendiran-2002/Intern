using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingTest
{
    public class CustomerTest
    {
        IRepository<int, Customer> repository;
        ICustomerService customerService;
        [SetUp]
        public void Setup()
        {
            repository = new CustomerRepository();
            Customer customer1 = new Customer() { Name = "Raghav", Age = 22, Phone = "8852352352" };
            Customer customer2 = new Customer() { Name = "Tharun", Age = 34, Phone = "4368368644" };
            repository.Add(customer1);
            repository.Add(customer2);
            customerService = new CustomerBL(repository);
        }
        [Test]
        public void GetCustomerByIdSuccess()
        {
            var customer = customerService.GetCustomerById(0);
            Assert.AreEqual(0, customer.Id);
        }
        [Test]
        public void GetCustomerByIdFailed()
        {
            var customer = customerService.GetCustomerById(0);
            Assert.AreNotEqual(1, customer.Id);
        }
        [Test]
        public void GetCustomerByIdException()
        {
            var exception = Assert.Throws<UserDefinedException.NoCustomerWithGiveIdException>(() => customerService.GetCustomerById(2));
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }
        [Test]
        public void DeleteCustomerSuccessTest()
        {
            var customer = customerService.DeleteCustomer(0);
            Assert.AreEqual(0, customer.Id);
        }
        [Test]
        public void DeleteCustomerFailTest()
        {
            var customer = customerService.DeleteCustomer(0);
            Assert.AreNotEqual(1, customer.Id);
        }

        [Test]
        public void DeleteCustomerExceptionTest()
        {
            var exception = Assert.Throws<UserDefinedException.NoCustomerWithGiveIdException>(() => customerService.DeleteCustomer(2));
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }
        [Test]
        public void UpdateCustomerSuccessTest()
        {
            var customer = customerService.UpdateCustomerName(0, "Pranav");
            Assert.AreEqual("Pranav", customer.Name);
        }
        [Test]
        public void UpdateCustomerFailTest()
        {
            var customer = customerService.UpdateCustomerName(0,"Pradeesh");
            Assert.AreNotEqual("Raghav", customer.Name);
        }

        [Test]
        public void UpdateCustomerExceptionTest()
        {
            var exception = Assert.Throws<UserDefinedException.NoCustomerWithGiveIdException>(() => customerService.UpdateCustomerName(2, "$$$"));
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }
        [Test]
        public void AddCustomerSuccessTest()
        {
            var customer = customerService.AddCustomer(new Customer("Rithik", "342354235", 34));
            Assert.AreEqual("Rithik", customer.Name);
        }
    }
}