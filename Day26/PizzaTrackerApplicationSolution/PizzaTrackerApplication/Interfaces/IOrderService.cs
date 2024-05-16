using PizzaTrackerApi.Models;
using PizzaTrackerApplication.Models.DTOs;

namespace PizzaTrackerApplication.Interfaces
{
    public interface IOrderService
    {
        public Task<IList<Order>> GetAllOrders();
      
         public Task<Order> PlaceOrder(OrderDTO pizza);
    }
}
