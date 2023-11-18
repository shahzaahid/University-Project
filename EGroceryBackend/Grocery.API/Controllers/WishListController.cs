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
    public class WishListController : ControllerBase
    {
        private readonly IWishListService _wishListService;
        public WishListController(IWishListService wishListService)
        {
            _wishListService = wishListService;
        }
        // GET: api/<CartController>
        [HttpGet]
        public IEnumerable<WishList>? GetWishLists()
        {
            var wishLists = _wishListService.GetWishLists();
            if (wishLists != null)
            {
                return wishLists;
            }
            return Enumerable.Empty<WishList>();
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public IActionResult GetWishListById(int id)
        {
            var wishList = _wishListService.GetWishListById(id);
            if (wishList != null)
            {
                return Ok(wishList);
            }
            return NotFound("Wish List Data Not Found");
        }

        // GET api/<CartController>/5
        [HttpGet("GetWishListDetails/{id}")]
        public IActionResult GetWishListDetails(int id)
        {
            if (id > 0)
            {
                var wishLists = _wishListService.GetWishListDetails(id);
                if (wishLists != null)
                    return Ok(wishLists);
                return NotFound("WishList Id details not available");
            }
            return BadRequest("You have entered invalid Parameters.");
        }

        // POST api/<CartController>
        [HttpPost]
        public IActionResult AddWishList([FromBody] WishList wishList)
        {
            if (ModelState.IsValid)
            {
                var result = _wishListService.AddWishList(wishList);
                if (result != 0)
                    return Ok("WishList Created On Id: " + result);
                return BadRequest("Something Went Wrong");
            }
            return BadRequest("There is an error with your data");
        }

        [HttpPost("AddWishListItem")]
        public IActionResult AddWishListItem([FromBody] WishListItem wishListItem)
        {
            if (ModelState.IsValid)
            {
                var result = _wishListService.AddWishListItem(wishListItem);
                if (result != 0)
                    // return Ok("Wish List Item Created On Id: " + result);
                    return Ok(new { msg = "Item Added Successfully", Id = result });
                return BadRequest("Something Went Wrong");
            }
            return BadRequest("There is an error with your data");
        }

        // PUT api/<CartController>/5
        [HttpPut]
        [Route("UpdateWishList")]
        public IActionResult UpdateWishList(int id, [FromBody] WishList wishList)
        {
            var result = _wishListService.UpdateWishList(id, wishList);
            if (result != 0)
            {
                return Ok($"WishList Id: {id} Updated Successfully");
            }
            return BadRequest($"Error in Updating WishList Id: {id}");
        }

        // DELETE api/<CartController>/5
        [HttpDelete]
        public IActionResult DeleteWishList(int id)
        {
            var wishList = _wishListService.DeleteWishList(id);
            if (wishList != 0)
            {
                return Ok($"WishList Id: {id} Deleted Successfully");
            }
            return BadRequest($"Unable to delete WishList Id: {id}");
        }
        //Delete wishlist Item
        [HttpDelete("wishlist/{wishListId}/product/{productId}")]
        public IActionResult DeleteWishListItem(int wishListId, int productId)
        {
            var deletedId = _wishListService.DeleteWishListItem(wishListId, productId);

            if (deletedId != 0)
            {
                // return Ok($"WishListItem with Id {deletedId} has been deleted.");
                return Ok(new { msg = "WishListItem Deleted Successfully", Id = deletedId });
            }
            else
            {
                return NotFound($"WishListItem with WishListId {wishListId} and ProductId {productId} not found.");
            }
        }

        [HttpGet]
        [Route("GetWishListItemsByCustomerId")]
        public List<Item> GetWishListItemsByCustomerId(int userId)
        {
            return _wishListService.GetWishListItemsByCustomerId(userId);
        }

        [HttpGet]
        [Route("GetWishListItemsByWishListId")]
        public IEnumerable<WishListItem> GetWishListItemsByWishListId(int wishListId)
        {
            return _wishListService.GetWishListItemsByWishListId(wishListId);
        }
    }
}