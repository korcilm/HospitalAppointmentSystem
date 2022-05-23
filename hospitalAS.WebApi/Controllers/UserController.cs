using hospitalAS.Business.Interfaces;
using hospitalAS.Dto.UserDtos;
using hospitalAS.WebApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hospitalAS.WebApi.Controllers
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
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUser();
            return Ok(users);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUser(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound(new { message = $"({id}) Bu id ye ait kullanıcı bulunamadı" });
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddUser(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddUser(model);
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpPut("[action]/{id}")]
        [IsExists]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto model)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateUser(model);
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("[action]/{id}")]
        [IsExists]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUser(id);
            user.IsActive = false;
            await _userService.UpdateUser(user);
            return Ok();
        }
    }
}
