using hospitalAS.Business.Interfaces;
using hospitalAS.Dto.AppointmentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace hospitalAS.Web.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IUserService _userService;
        private readonly IHospitalService _hospitalService;
        private readonly IPoliclinicService _policlinicService;
        public AppointmentController(IAppointmentService appointmentService, IPoliclinicService policlinicService, IHospitalService hospitalService, IUserService userService)
        {
            _userService = userService;
            _hospitalService = hospitalService;
            _appointmentService = appointmentService;
            _policlinicService = policlinicService;
        }
        private async Task<int> GetUserId()
        {
            var identityNumber = User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value;
            int userId = await _userService.GetUserIdByIdentityNumber(identityNumber);
            return userId;
        }
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Hospitals = new SelectList(await _hospitalService.GetAllHospitals(), "Id", "Name");
            var appointments = await _appointmentService.GetAllAppointmentsByUserId(await GetUserId());
            return View(appointments);
        }
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> PoliclinicList(int id)
        {
            var jsonString = JsonConvert.SerializeObject(await _policlinicService.GetPoliclinicsByHospitalId(id));
            return Json(jsonString);
        }
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> DoctorList(int id)
        {
            var jsonString = JsonConvert.SerializeObject(await _userService.GetDoctorsByPoliclinicId(id));
            return Json(jsonString);
        }
        [Authorize(Roles = "Patient")]
        [HttpPost]
        public async Task<IActionResult> TakeAnAppointment(AddAppointmentDto model)
        {
             model.PatientId = await GetUserId(); 
            await _appointmentService.AddAppointment(model);
            return Json("true");
        }
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> PatientList()
        {
            var patients = await _appointmentService.GetAllAppointmentsByDoctorId(await GetUserId());
            return View(patients);
        }
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> OutOfDateAppointment()
        {
            var appointments = await _appointmentService.GetOutOfDateAppointmentByUserId(await GetUserId());
            return View(appointments);
        }
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            await _appointmentService.DeleteAppointment(id);
            return RedirectToAction("Index");
        }
    }
}
