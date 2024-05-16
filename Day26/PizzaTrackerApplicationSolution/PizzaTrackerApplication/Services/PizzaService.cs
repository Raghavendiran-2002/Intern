using PizzaTrackerApi.Models;
using PizzaTrackerApplication.Exceptions;
using PizzaTrackerApplication.Interfaces;
using PizzaTrackerApplication.Models.DTOs;

namespace PizzaTrackerApplication.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int, Pizza> _pizzaRepo;

        public PizzaService(IRepository<int, Pizza> pizzaRepo) 
        {
            _pizzaRepo = pizzaRepo;
        }
        public async Task<IList<Pizza>> GetAllPizzaInStock()
        {
            var pizzaList = await _pizzaRepo.Get();
            if(pizzaList.Count() == 0) { throw new NoPizzaInDB("No pizza registered"); }
            var availablePizza =  pizzaList.Where(p=>p.StocksQuantity  > 0).ToList();
            if(availablePizza .Count() == 0) { throw new PizzaNotAvailable("Pizza not available for now"); }
            return availablePizza;
        }

        public async Task<IList<Pizza>> GetAllPizza()
        {
            var pizzaList = await _pizzaRepo.Get();
            if (pizzaList.Count() == 0) { throw new NoPizzaInDB("No pizza registered"); }
            return pizzaList.ToList();
        }

        public async Task<Pizza> AddPizza(PizzaAddDTO piz)
        {
            Pizza pizza = new Pizza() { Name = piz.Name, Price= piz.Price,  StocksQuantity =piz.StocksQuantity };
           return await _pizzaRepo.Add(pizza);
            
        }
    }
}
