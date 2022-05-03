using hospitalAS.Business.Interfaces;
using hospitalAS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace hospitalAS.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPoliclinicService _policlinicService ;
        private readonly IDoctorService _doctorService;
        
        
        public HomeController(ILogger<HomeController> logger, IPoliclinicService policlinicService , IDoctorService doctorService)
        {
            _logger = logger;
            _doctorService = doctorService;
            _policlinicService = policlinicService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Policlinics= new SelectList(await _policlinicService.GetAllPoliclinics(), "Id", "Name"); ;
            //ViewBag.Doctors = new SelectList(await _doctorService.GetDoctorsByPoliclinicId(id), "Id", "Name"); ;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
