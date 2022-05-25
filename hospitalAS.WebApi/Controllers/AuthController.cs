using hospitalAS.Business.Interfaces;
using hospitalAS.Dto.UserDtos;
using hospitalAS.WebApi.Filters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [ValidModel]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userService.ValidateUser(model.IdentityNumber, model.Password);
            if (user != null)
            {
                var claims = new[]{
                        new Claim(JwtRegisteredClaimNames.UniqueName,user.IdentityNumber),
                        new Claim(JwtRegisteredClaimNames.Jti,user.Id.ToString()),
                        new Claim(ClaimTypes.Role,user.Role.Name)
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Dont-count-your-chickens-before-they-hatch"));
                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    issuer: "google.com.tr",
                    audience: "google.com.tr",
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credential
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return BadRequest(new { messages = "Kullanıcı adı veya şifre hatalı" });
        }

        [ValidModel]
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            await _userService.AddUser(model);
            return Ok();
        }


    }
}
