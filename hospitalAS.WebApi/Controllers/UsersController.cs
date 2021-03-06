using hospitalAS.Business.Interfaces;
using hospitalAS.Dto.UserDtos;
using hospitalAS.Entities;
using hospitalAS.WebApi.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hospitalAS.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUser();
            return Ok(users);
        }

        [ServiceFilter(typeof(ValidId<User>))]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUser(id);
            return Ok(user);
        }

        [ValidModel]
        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUser(RegisterDto model)
        {
            await _userService.AddUser(model);
            return Ok();
        }

        [ServiceFilter(typeof(ValidId<User>))]
        [ValidModel]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto model)
        {
            await _userService.UpdateUser(model);
            return Ok();
        }

        [ServiceFilter(typeof(ValidId<User>))]
        [HttpDelete("[action]/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUser(id);
            user.IsActive = false;
            await _userService.UpdateUser(user);
            return Ok();
        }
    }
}
