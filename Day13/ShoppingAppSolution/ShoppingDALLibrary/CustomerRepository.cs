using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        readonly Dictionary<int, Customer> _customers;

        public CustomerRepository()
        {
            _customers = new Dictionary<int, Customer>();
        }
        public override async Task<Customer> Delete(int key)
        {
            Customer customer = await GetByKey(key);
            if (customer != null)
            {
                items.Remove(customer);
                return customer;
            }
            throw new UserDefinedException.CustomerBL.NoCustomerIdFound();
        }

        public override async Task< Customer> GetByKey(int key)
        {
            Customer customer =  items.FirstOrDefault(p => p.Id == key);
            if(customer== null)
                throw new UserDefinedException.CustomerBL.NoCustomerIdFound();
            return customer;
        }

        public override async Task<Customer> Update(Customer item)
        {
            Customer customer = await GetByKey(item.Id);
            if (customer != null)
            {
                customer = item;
            }
            return customer;
        }
    }


}