using Microsoft.EntityFrameworkCore;
using PizzaTrackerApi.Context;
using PizzaTrackerApi.Models;
using PizzaTrackerApplication.Interfaces;
using PizzaTrackerApplication.Models.DTOs;

namespace PizzaTrackerApplication.Models.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private readonly PizzaTrackerContext _context;

        public PizzaRepository(PizzaTrackerContext context)

        {
            _context = context;
        }
        public async Task<Pizza> Add(Pizza item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Pizza> Delete(int key)
        {
            var pizza = await Get(key);
            if (pizza != null)
            {
                _context.Remove(pizza);
                await _context.SaveChangesAsync(true);
                return pizza;
            }
            throw new NotImplementedException();
        }

        public async Task<Pizza> Get(int key)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(e => e.PizzaId == key);
            return pizza;
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            var pizzas = await _context.Pizzas.ToListAsync();
            return pizzas;
        }

        public async Task<Pizza> Update(Pizza item)
        {
            var pizza = await Get(item.PizzaId);
            if(pizza != null)
            {
                _context.Update(pizza);
                await _context.SaveChangesAsync();
                return pizza;
            }
            throw new NotImplementedException();
        }
    }
}
