using PizzaTrackerApi.Models;
using PizzaTrackerApplication.Models.DTOs;

namespace PizzaTrackerApplication.Interfaces
{
    public interface IPizzaService
    {
        public Task<IList<Pizza>> GetAllPizzaInStock();
        public Task<IList<Pizza>> GetAllPizza();

        public Task<Pizza> AddPizza(PizzaAddDTO pizza);
    }
}
