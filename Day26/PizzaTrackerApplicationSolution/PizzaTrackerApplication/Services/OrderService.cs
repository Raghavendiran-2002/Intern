using PizzaTrackerApi.Models;
using PizzaTrackerApplication.Interfaces;
using PizzaTrackerApplication.Models.DTOs;

namespace PizzaTrackerApplication.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<int, Order> _orderRepo;
        private readonly IRepository<int, Pizza> _pizzaRepo;
        public OrderService(IRepository<int ,Order> orderRepo, IRepository<int, Pizza> pizzaRepo)
        {
            _orderRepo = orderRepo;
            _pizzaRepo = pizzaRepo;
        }

      
        public async Task<IList<Order>> GetAllOrders()
        {
            var orders = await _orderRepo.Get();
            if(orders == null)
            {
                throw new NoOrdersPlaced("No Orders Placed");
            }
            return orders.ToList();
        }

        
        public async Task<Order> PlaceOrder(OrderDTO orderToBePlaced)
        {
            Order order = new Order() { UserId = orderToBePlaced.UserId, PizzaId = orderToBePlaced.PizzaId,  IsPaid = false ,  OrderedDate = DateTime.Now};
            var odr = await _orderRepo.Add(order);
            return odr;
        }
    }
}
