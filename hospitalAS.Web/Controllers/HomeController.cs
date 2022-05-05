using hospitalAS.Business.Interfaces;
using hospitalAS.Dto.AppointmentDtos;
using hospitalAS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace hospitalAS.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPoliclinicService _policlinicService;
        private readonly IDoctorService _doctorService;
        private readonly IHospitalService _hospitalService;
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;

        public HomeController(ILogger<HomeController> logger, IPoliclinicService policlinicService, IDoctorService doctorService,
            IHospitalService hospitalService, IAppointmentService appointmentService, IPatientService patientService)
        {
            _logger = logger;
            _doctorService = doctorService;
            _policlinicService = policlinicService;
            _hospitalService = hospitalService;
            _appointmentService = appointmentService;
            _patientService = patientService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Hospitals = new SelectList(await _hospitalService.GetAllHospitals(), "Id", "Name");
            var appointments = await _appointmentService.GetAllAppointmentsByUserId(await GetUserId());
            return View(appointments);
        }
        public async Task<IActionResult> DoctorList(int id)
        {
            var jsonString = JsonConvert.SerializeObject(await _doctorService.GetDoctorsByPoliclinicId(id));
            return Json(jsonString);
        }
        public async Task<IActionResult> PoliclinicList(int id)
        {
            var jsonString = JsonConvert.SerializeObject(await _policlinicService.GetPoliclinicsByHospitalId(id));
            return Json(jsonString);
        }
        [HttpPost]
        public async Task<IActionResult> TakeAnAppointment(AddAppointmentDto model)
        {            
            model.PatientId = await GetUserId(); 
            await _appointmentService.AddAppointment(model);
            return Json("true");
        }

        private async Task<int> GetUserId()
        {
            var identityNumber = User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value;
            int userId = await _patientService.GetUserIdByIdentityNumber(identityNumber);
            return userId;
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
