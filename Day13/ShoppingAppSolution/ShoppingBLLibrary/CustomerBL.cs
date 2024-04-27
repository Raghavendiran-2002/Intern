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
        public async Task<Customer> AddCustomer(Customer customer)
        {
            var result =  await _customerRepo.Add(customer);
            if(result == null)
                throw new UserDefinedException.NoCustomerWithGiveIdException();
            return result;
        }

        public async Task<Customer> DeleteCustomer(int customerId)
        {
            Customer customer =  await _customerRepo.GetByKey(customerId);
            if(customer == null)
            {
                 throw new UserDefinedException.CustomerBL.NoCustomerIdFound();

            }
            _customerRepo.Delete(customerId);
            return customer;


        }

        public async Task< Customer> GetCustomerById(int customerId)
        {
            Customer customer = await  _customerRepo.GetByKey(customerId);
            if(customer != null) {
                return customer;
            }
            throw new UserDefinedException.CustomerBL.NoCustomerIdFound();
        }

        public  async Task<Customer> UpdateCustomerName(int customerId, string name)
        {
            var result = await _customerRepo.GetByKey(customerId);
            if(result != null)
            {
                result.Name = name;
                var res2 = await _customerRepo.Update(result);
                return result;
            }
            throw new UserDefinedException.NoCustomerWithGiveIdException();
        }
    }
    
}
