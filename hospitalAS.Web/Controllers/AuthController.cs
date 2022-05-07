using AutoMapper;
using hospitalAS.Business.Interfaces;
using hospitalAS.Dto.ClaimDtos;
using hospitalAS.Dto.PatientDtos;
using hospitalAS.Entities;
using hospitalAS.Web.Models;
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
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IBloodTypeService _bloodTypeService;
        private readonly IMapper _mapper;
        public AuthController(IPatientService patientService, IBloodTypeService bloodTypeService, IMapper mapper, IDoctorService doctorService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
            _bloodTypeService = bloodTypeService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model, int id)
        {
            if (ModelState.IsValid)
            {
                if (id == 1)
                {
                    var patient = await _patientService.PatientLogin(model.IdentityNumber, model.Password);
                    if (patient != null)
                    {
                        await CreateClaim(_mapper.Map<ClaimDto>(patient));
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("Giriş yap", "Kullanıcı adı veya şifre hatalı");
                }
                else
                {
                    var doctor = await _doctorService.DoctorLogin(model.IdentityNumber, model.Password);
                    if (doctor != null)
                    {
                        await CreateClaim(doctor);
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("Giriş yap", "Kullanıcı adı veya şifre hatalı");
                }

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
                int addedPatientId = await _patientService.AddPatient(model);
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
