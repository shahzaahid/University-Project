using Grocery.Business.Services.Interface;
using Grocery.Repo.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Grocery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IVendorService _vendorService;

        public LoginController(IUserService userService, IVendorService vendorService, IConfiguration configuration)
        {
            _configuration = configuration;
            _userService = userService;
            _vendorService = vendorService;
        }

        [AllowAnonymous]
        [HttpPost("User")]
        public IActionResult LoginUser([FromBody] Login user)
        {
            var validUser = _userService.Authenticate(user);
            if (validUser != null)
            {
                var token = GenerateToken(validUser);
                var response = new UserDTO
                {
                    Token = token,
                    UserId = validUser.Id // Assuming UserDTO has a property named UserId
                };

                return Ok(response);
            }

            return Unauthorized("Unauthorized: user not found");
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.EmailId),
                new Claim("UserId", user.Id.ToString()) // Use "UserId" instead of "userId"
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost("Vendor")]
        public IActionResult LoginVendor([FromBody] Login vendor)
        {
            var validVendor = _vendorService.Authenticate(vendor);
            if (validVendor != null)
            {
                var token = GenerateToken(validVendor);
                var response = new VendorDTO
                {
                    Token = token,
                    VendorId = validVendor.Id
                };

                return Ok(response);
            }

            return Unauthorized("Unauthorized: vendor not found");
        }

        private string GenerateToken(Vendor vendor)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, vendor.EmailId),
                new Claim("VendorId", vendor.Id.ToString()) // Use "VendorId" instead of "VendorID"
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
