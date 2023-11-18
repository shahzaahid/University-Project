using Microsoft.AspNetCore.Mvc;
using Grocery.Business.Services.Interface;
using Grocery.Business.Services;
using Grocery.Repo.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Grocery.API.Controllers
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
        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult Get()
        {
            var orders = _orderService.GetOrders();
            if (orders != null)
                return Ok(orders);
            return NotFound("Order details not available");
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            if (id > 0)
            {
                var orders = _orderService.GetOrderById(id);
                if(orders != null)
                    return Ok(orders);
                return NotFound("Order Id details not available");
            }
            return BadRequest("You have entered invalid Parameters.");
        }

        // POST api/<OrderController>
        [HttpPost]
        public int AddOrder([FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                // Valid data, proceed with adding the order
                return _orderService.AddOrder(order);
            }
            else
            {
                // Invalid data, return a bad request response with validation errors
                return -1;
            }
        }


        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
