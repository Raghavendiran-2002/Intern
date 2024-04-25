using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace ShoppingBLLibrary
{
    public class CustomerBL : ICustomerService
    {
        readonly IRepository<int, Customer> _customerRepo;
        public CustomerBL(IRepository<int , Customer> customerRepo) {
            _customerRepo = customerRepo;
        }
        [ExcludeFromCodeCoverage]
        public Customer AddCustomer(Customer customer)
        {
            var result = _customerRepo.Add(customer);
            if(result == null)
                throw new UserDefinedException.NoCustomerWithGiveIdException();
            return result;
        }

        public Customer DeleteCustomer(int customerId)
        {
            Customer customer = _customerRepo.GetByKey(customerId);
            if(customer == null)
            {
                 throw new UserDefinedException.NoCustomerWithGiveIdException();

            }
            _customerRepo.Delete(customerId);
            return customer;


        }

        public Customer GetCustomerById(int customerId)
        {
            Customer customer = _customerRepo.GetByKey(customerId);
            if(customer != null) {
                return customer;
            }
            throw new UserDefinedException.NoCustomerWithGiveIdException();
        }

        public Customer UpdateCustomerName(int customerId, string name)
        {
            var result = _customerRepo.GetByKey(customerId);
            if(result != null)
            {
                result.Name = name;
                var res2 = _customerRepo.Update(result);
                return result;
            }
            throw new UserDefinedException.NoCustomerWithGiveIdException();
        }
    }
    
}
