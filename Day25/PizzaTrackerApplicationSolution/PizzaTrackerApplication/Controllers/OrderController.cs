using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaTrackerApi.Models;
using PizzaTrackerApplication.Interfaces;
using PizzaTrackerApplication.Models;
using PizzaTrackerApplication.Models.DTOs;
using PizzaTrackerApplication.Services;

namespace PizzaTrackerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IList<Order>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<Pizza>>> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]

        public async Task<ActionResult<Order>> PostOrders([FromBody] OrderDTO order)
        {
            try
            {
                await _orderService.PlaceOrder(order);
                return Ok(order);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));

            }

        }

    }
}
