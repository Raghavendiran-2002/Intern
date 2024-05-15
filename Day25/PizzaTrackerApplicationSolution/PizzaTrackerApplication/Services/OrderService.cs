using PizzaTrackerApi.Models;
using PizzaTrackerApplication.Interfaces;
using PizzaTrackerApplication.Models.DTOs;

namespace PizzaTrackerApplication.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<int, Order> _orderRepo;

        public OrderService(IRepository<int ,Order> orderRepo)
        {
            _orderRepo = orderRepo;
        }

      
        public async Task<IList<Order>> GetAllOrders()
        {
            var orders = await _orderRepo.Get();
            //Exception
            return orders.ToList();
        }

        public async Task<Order> PlaceOrder(Order order)
        {
            var odr = await _orderRepo.Add(order);
            return odr;
        }

        public async Task<Order> PlaceOrder(OrderDTO orderToBePlaced)
        {
            Order order = new Order() { UserId = orderToBePlaced.UserId, TotalPrice = orderToBePlaced.TotalPrice, PizzaId = orderToBePlaced.PizzaId,IsPaid=orderToBePlaced.IsPaid };
            var odr = await _orderRepo.Add(order);
            return odr;
        }
    }
}
