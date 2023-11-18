using Grocery.Business.Services;
using Grocery.Business.Services.Interface;
using Grocery.Repo.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Grocery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;
        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;   
        }
        [HttpGet]
        public IEnumerable<Vendor> AllVendors()
        {
            return _vendorService.AllVendors();
        }
        // GET api/<VendorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VendorController>
        [HttpPost]
        [Route ("AddVendor")]
        public int AddVendor([FromBody] Vendor vendor)
        {
            return _vendorService.AddVendor(vendor);
        }
        // DELETE api/<VendorController>/5
        [HttpDelete("{id}")]
        
        public IActionResult DeleteVendor(int id)
        {
            var vendor = _vendorService.DeleteVendor(id);
            if (vendor != 0)
            {
                // return Ok($"Vendor Id: {id} Deleted Successfully");
                return Ok(new { Id=id, msg="Deleted Successfully" });
            }
            return BadRequest($"Unable to delete Vendor Id: {id}");
        }
        //GET VENDOR BY ID
        // GET: api/Vendor/5
        [HttpGet]
        [Route("GetVendorById")]
        public IActionResult GetVendorById(int id)
        {
            var vendor = _vendorService.GetVendorById(id);

            if (vendor == null)
            {
                return NotFound();
            }

            return Ok(vendor);
        }

        //UPDATE VENDOR 
        [HttpPut]
        [Route("UpdateVendor")]
        public IActionResult UpdateVendor(int id, [FromBody] Vendor updatedVendor)
        {
            if (id <= 0) // Null check for id
            {
                return BadRequest("Invalid ID");
            }
            if (!ModelState.IsValid) // Check if updatedVendor is valid
            {
                return BadRequest(ModelState);
            }
            var result = _vendorService.UpdateVendor(id, updatedVendor);
            if (result == -1)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
