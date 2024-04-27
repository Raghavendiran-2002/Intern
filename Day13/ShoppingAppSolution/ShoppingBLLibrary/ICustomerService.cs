using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface ICustomerService
    {
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> GetCustomerById(int customerId);

        Task<Customer> UpdateCustomerName(int customerId, string name);
        Task<Customer> DeleteCustomer(int customerId);
    }
}
