using Grocery.API.Helper;
using Grocery.Business.Services.Interface;
using Grocery.Repo.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Grocery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IConfiguration _config;
        public ProductController(IProductService productService, IConfiguration config)
        {
            _productService = productService;
            _config = config;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetProducts();
            if (products != null)
                return Ok(products);
            return NotFound();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        //[Route("GetById")]
        public IActionResult GetProductById(int id)
        {
            if (id > 0)
                return Ok(_productService.GetProductById(id));
            return BadRequest();
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
                return Ok(_productService.AddProduct(product));
            return BadRequest();
        }


        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Product updatedProduct)
        {
            return _productService.UpdateProduct(id, updatedProduct);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _productService.DeleteProduct(id);

        }


        // Upload Multiple Images Of A Product
        //[HttpPost]
        // [Route("UploadImages")]
        // public async Task<IActionResult> UploadImages(int ProductId, List<IFormFile> images)
        // {
        //     if (images == null || images.Count == 0)
        //     {
        //         return BadRequest("No images were uploaded.");
        //     }

        //     var baseDirectory = @"..\Grocery.Repo\Images\ProductImages";
        //     await UploadHelper.UploadMultipleImages(ProductId, images, baseDirectory);

        //     return Ok("Images uploaded successfully.");
        // }

        [HttpPost]
        [Route("UploadImage")]
        public IActionResult UploadImage(int userId, IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("No image was uploaded.");
            }

            var path = @"..\Grocery.Repo\Images\ProductImages";
            // Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(path, userId.ToString() + "" + Path.GetExtension(image.FileName));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyToAsync(stream);
            }

            // return Ok("Image uploaded successfully.");
            return Ok(new { msg= "Image Uploaded Succesfully", Id = 0 });
        }


        [HttpGet("images/{productId}")]
        public IActionResult GetImage(int productId)
        {
            byte[] imageBytes = _productService.GetProductImage(productId);

            if (imageBytes == null)
            {
                return NotFound();
            }

            return File(imageBytes, "image/jpeg"); // Adjust the content type as needed.
        }

    }
}





