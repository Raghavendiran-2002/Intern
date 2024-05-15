using Microsoft.EntityFrameworkCore;
using PizzaTrackerApi.Context;
using PizzaTrackerApi.Models;
using PizzaTrackerApplication.Interfaces;

namespace PizzaTrackerApplication.Models.Repositories
{
    public class OrderRepository : IRepository<int, Order>
    {
        private readonly PizzaTrackerContext _context;

        public OrderRepository(PizzaTrackerContext context)
        {
            _context = context;
        }
        public async Task<Order> Add(Order item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Order> Delete(int key)
        {
            var order = await Get(key);
            if (order != null)
            {
                _context.Remove(order);
                await _context.SaveChangesAsync(true);
                return order;
            }
            throw new NotImplementedException();
        }

        public async Task<Order> Get(int key)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(e => e.OrderId == key);
            return order;
        }

        public async Task<IEnumerable<Order>> Get()
        {
            var orders = await _context.Orders.ToListAsync();
            return orders;
        }

        public async Task<Order> Update(Order item)
        {
            var order = await Get(item.OrderId);
            if (order != null)
            {
                _context.Update(order);
                await _context.SaveChangesAsync();
                return order;
            }
            throw new NotImplementedException();
        }
    }
}
