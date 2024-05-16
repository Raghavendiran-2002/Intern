using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaTrackerApi.Models;
using PizzaTrackerApplication.Interfaces;
using PizzaTrackerApplication.Models;
using PizzaTrackerApplication.Models.DTOs;

namespace PizzaTrackerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService; 
        }
        [Authorize]
        [HttpGet]
        [Route("GetAllPizza")]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<Pizza>>> GetAllPizza()
        {
            try
            {
                var pizzas = await _pizzaService.GetAllPizza();
                return Ok(pizzas);
            } catch (Exception ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }
        [Authorize]
        [HttpGet]
        [Route("GetPizzaInStock")]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
    
        public async Task<ActionResult<IList<Pizza>>> GetPizzaInStock()
        {
            try
            {
                var pizzas = await _pizzaService.GetAllPizzaInStock();
                return Ok(pizzas);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }
        [Authorize]
        [HttpPost]
       
        [ProducesResponseType(typeof(PizzaAddDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<Pizza>> PostPizza([FromBody] PizzaAddDTO pizza)
        {
            try
            {
                var pizzas = await _pizzaService.AddPizza(pizza);
                return Ok(pizzas);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }
    }
}
