using Grocery.Business.Services;
using Grocery.Business.Services.Interface;
using Grocery.Repo.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Grocery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("GetUserAddressById/{id}")]
        public IEnumerable<UserAddress> GetUserAddressById(int id)
        {
            return _userService.GetUserAddressById(id);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if(user != null)
            {
                return Ok(user);
            }
            return NotFound("User Data Not Found");
        }

        // POST api/<UserController>
        [HttpPost]
       
        public IActionResult AddUser([FromBody] User user)
        {
            if (ModelState.IsValid)
                return Ok(_userService.AddUser(user));
            return BadRequest();
        }

        [HttpPost("AddUserAddress")]
        public IActionResult AddUserAddress([FromBody] UserAddress userAddress)
        {
            if (ModelState.IsValid)
                return Ok(_userService.AddUserAddress(userAddress));
            return BadRequest();
        }

        //Put Update User
        [HttpPut]
        [Route("UpdateUser")]
        public int UpdateUser(int id, [FromBody] User updateUser)
        {
            return _userService.UpdateUser(id, updateUser);
        }
        // PUT api/<UserController>/5
        [HttpPut]
        [Route("UpdateRole")]
        public void UpdateRole(int id, [FromBody] Role role)
        {
            _userService.UpdateRole(id, role);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if(ModelState.IsValid)
                return Ok(_userService.DeleteUser(id));
            return BadRequest();
        }

        [HttpPost]
        [Route("UploadImage")]
        public  IActionResult UploadImage(int userId, IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("No image was uploaded.");
            }

            var path = @"..\Grocery.Repo\Images\UserImages";
           // Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(path, userId.ToString()+""+Path.GetExtension(image.FileName));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyToAsync(stream);
            }

            return Ok("Image uploaded successfully.");
        }

        /*--------------CHECK LOGIN FUNCTIONALITY------------------------*/
        //For admin Only
        [HttpGet]
        [Route("Admins")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi you are an {currentUser.EmailId}");
        }
        private User GetCurrentUser()
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var userClaims = identity.Claims;
                return new User
                {
                    EmailId = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    /*Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value*/
                };
            }
            return null;
        }

    }
}
