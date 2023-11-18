using Grocery.Business.Services;
using Grocery.Business.Services.Interface;
using Grocery.Repo.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Grocery.Repo.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Grocery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        // GET: api/<CartController>
        [HttpGet]
        public IEnumerable<Cart>? GetCarts()
        {
            var carts = _cartService.GetCarts();
            if (carts != null)
            {
                return carts;
            }
            return Enumerable.Empty<Cart>();
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public IActionResult GetCartById(int id)
        {
            var cart = _cartService.GetCartById(id);
            if (cart != null)
            {
                return Ok(cart);
            }
            return NotFound("Cart Data Not Found");
        }

        // GET api/<CartController>/5
        [HttpGet("GetCartandCartItems/{id}")]
        public IActionResult GetCartDetails(int id)
        {
            if (id > 0)
            {
                var carts = _cartService.GetCartDetails(id);
                if (carts != null)
                    return Ok(carts);
                return NotFound("Cart Id details not available");
            }
            return BadRequest("You have entered invalid Parameters.");
        }

        // POST api/<CartController>
        [HttpPost]
        public IActionResult AddCart([FromBody] Cart cart)
        {
            if (ModelState.IsValid)
            {
                var result = _cartService.AddCart(cart);
                if (result != 0)
                    return Ok("Cart Created On Id: " + result);
                return BadRequest("Something Went Wrong");
            }
            return BadRequest("There is an error with your data");
        }

        // POST api/<CartController>
        [HttpPost("AddCartItem")]
        public IActionResult AddCartItem([FromBody] CartItem cartitem)
        {
            if (ModelState.IsValid)
            {
                var result = _cartService.AddCartItem(cartitem);
                if (result != 0)
                    // return Ok("CartItem Created On Id: " + result);
                    return Ok(new { msg = "Added  Successfully", Id = result });
                return BadRequest("Something Went Wrong");
            }
            return BadRequest("There is an error with your data");
        }

        //Update Cart
        [HttpPut("{cartId}")]
        public IActionResult UpdateCartItem(int cartId,int productId, [FromBody] CartItem updatedCartItem)
        {
            if (updatedCartItem == null)
            {
                return BadRequest("Invalid data received.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _cartService.UpdateCartItem(cartId,productId, updatedCartItem);

            if (result != 0)
            {
                // return Ok($"CartItem Id: {id} Updated Successfully");
                return Ok(new { msg = "Updated   Successfully", Id = result });
            }

            return NotFound($"CartItem with ID {cartId} not found.");
        }


        // DELETE api/<CartController>/5
        [HttpDelete]
        public IActionResult DeleteCart(int id)
        {
            var cart = _cartService.DeleteCart(id);
            if(cart != 0)
            {
                return Ok($"Cart Id: {id} Deleted Successfully");
            }
            return BadRequest($"Unable to delete Cart Id: {id}");
        }
        [HttpDelete]
        [Route ("DeleteCartItem")]
        public IActionResult DeleteCartItem(int id)
        {
            var cartItem = _cartService.DeleteCartItem(id);
            if(cartItem != 0)
            {
                //return Ok($"Cart Item Id: {id} Deleted Successfully");
                return Ok(new { msg = "Deleted Successfully", Id = id });
            }
            return BadRequest($"Unable to Delete Cart Item Id: {id}");
        }
        [HttpDelete]
        [Route("RemoveCartItem")]
        public IActionResult RemoveCartItem(int cartId)
        {
            var cartItem = _cartService.DeleteCartItem(cartId);
            if (cartItem != 0)
            {
                //return Ok($"Cart Item Id: {id} Deleted Successfully");
                return Ok(new { msg = "Deleted Successfully", Id = cartId });
            }
            return BadRequest($"Unable to Delete Cart Item Id: {cartId}");
        }

        [HttpGet]
        [Route("GetCartItemsByCustomerId")]
        public List<Item> GetCartItemsByCustomerId(int userId)
        {
            return _cartService.GetCartItemsByCustomerId(userId);
        }

        [HttpGet]
        [Route("GetCartItemsByCartId")]
        public IEnumerable<CartItem> GetCartItemsByCartId(int cartId)
        {
            return _cartService.GetCartItemsByCartId(cartId);
        }
    }
}
