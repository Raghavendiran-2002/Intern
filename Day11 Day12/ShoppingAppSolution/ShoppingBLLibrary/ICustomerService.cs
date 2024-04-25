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
        Customer AddCustomer(Customer customer);
        Customer GetCustomerById(int customerId);

        Customer UpdateCustomerName(int customerId, string name);
        Customer DeleteCustomer(int customerId);
    }
}
