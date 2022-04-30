using hospitalAS.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hospitalAS.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IPatientService _patientService;
        public AuthController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            
            return View();
        }

    }
}
