using AutoMapper;
using hospitalAS.Business.Interfaces;
using hospitalAS.Dto.ClaimDtos;
using hospitalAS.Dto.UserDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace hospitalAS.Web.Controllers
{
    public class AuthController : Controller
    {
       
        private readonly IBloodTypeService _bloodTypeService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AuthController(IUserService userService, IBloodTypeService bloodTypeService, IMapper mapper)
        {
            _userService = userService;
            _bloodTypeService = bloodTypeService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.ValidateUser(model.IdentityNumber, model.Password);
                if (user != null)
                {
                    await CreateClaim(_mapper.Map<ClaimDto>(user));
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("Giriş yap", "Kullanıcı adı veya şifre hatalı");
            }
            return View("Index");
        }

        private async Task CreateClaim(ClaimDto model)
        {
            List<Claim> claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, model.Name),
                            new Claim(ClaimTypes.Surname, model.Surname),
                            new Claim(ClaimTypes.Role, model.Role.Name),
                            new Claim(ClaimTypes.NameIdentifier, model.IdentityNumber),
                        };
            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(claimsPrincipal);
        }

        public async Task<IActionResult> Register()
        {
            ViewBag.BloodTypes = new SelectList(await _bloodTypeService.GetAllBloodTypes(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                int addedPatientId = await _userService.AddUser(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.BloodTypes = new SelectList(await _bloodTypeService.GetAllBloodTypes(), "Id", "Name");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

    }
}
