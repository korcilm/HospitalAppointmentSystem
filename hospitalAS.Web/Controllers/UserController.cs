using hospitalAS.Business.Interfaces;
using hospitalAS.Dto.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace hospitalAS.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBloodTypeService _bloodTypeService;
        private readonly IRoleService _roleService;
        public UserController(IBloodTypeService bloodTypeService, IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _bloodTypeService = bloodTypeService;
            _roleService = roleService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.BloodTypes = new SelectList(await _bloodTypeService.GetAllBloodTypes(), "Id", "Name");
            var patient = await _userService.GetUser(await GetUserId());
            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UpdateUserDto model)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateUser(model);
                return RedirectToAction("Index");
            }
            ViewBag.BloodTypes = new SelectList(await _bloodTypeService.GetAllBloodTypes(), "Id", "Name");
            return View();

        }
        public async Task<IActionResult> ListUser()
        {
            ViewBag.BloodTypes = new SelectList(await _bloodTypeService.GetAllBloodTypes(), "Id", "Name");
            ViewBag.Roles = new SelectList(await _roleService.GetAllRoles(), "Id", "Name");
            var users = await _userService.GetAllUser();
            return View(users);
        }
        [HttpPost]
        public async Task<IActionResult> AddUserViaAdmin(RegisterDto model)
        {
            ViewBag.BloodTypes = new SelectList(await _bloodTypeService.GetAllBloodTypes(), "Id", "Name");
            ViewBag.Roles = new SelectList(await _roleService.GetAllRoles(), "Id", "Name");
            var users = await _userService.AddUser(model);
            return Json("true");
        }
      
        private async Task<int> GetUserId()
        {
            var identityNumber = User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value;
            int userId = await _userService.GetUserIdByIdentityNumber(identityNumber);
            return userId;
        }
    }
}
