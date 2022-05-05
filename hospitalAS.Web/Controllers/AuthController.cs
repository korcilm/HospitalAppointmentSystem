using hospitalAS.Business.Interfaces;
using hospitalAS.Dto.PatientDtos;
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
        private readonly IBloodTypeService _bloodTypeService;
        public AuthController(IPatientService patientService, IBloodTypeService bloodTypeService)
        {
            _patientService = patientService;
            _bloodTypeService = bloodTypeService;
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
                var patient = await _patientService.PatientLogin(model.IdentityNumber, model.Password);
                if (patient != null)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, patient.Name),
                        new Claim(ClaimTypes.Surname, patient.Surname),
                        new Claim(ClaimTypes.NameIdentifier, patient.IdentityNumber),
                    };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    return RedirectToAction("Index","Home");

                }
                ModelState.AddModelError("login", "Kullanıcı adı veya şifre hatalı");
            }
            return View("Index");
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

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

    }
}
