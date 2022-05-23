using hospitalAS.Business.Interfaces;
using hospitalAS.Dto.AppointmentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace hospitalAS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IUserService _userService;
        private readonly IHospitalService _hospitalService;
        private readonly IPoliclinicService _policlinicService;
        public AppointmentsController(IAppointmentService appointmentService, IPoliclinicService policlinicService, IHospitalService hospitalService, IUserService userService)
        {
            _userService = userService;
            _hospitalService = hospitalService;
            _appointmentService = appointmentService;
            _policlinicService = policlinicService;
        }
        [Authorize(Roles = "Patient")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAppointmentsByPatientId()
        {
            var patientId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
            var appointments = await _appointmentService.GetAllAppointmentsByUserId(patientId);
            return Ok(appointments);
        }
        [Authorize(Roles = "Patient")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> PoliclinicList(int id)
        {
            var policlinics = await _policlinicService.GetPoliclinicsByHospitalId(id);
            return Ok(policlinics);
        }
        [Authorize(Roles = "Patient")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> DoctorList(int id)
        {
            var doctors = await _userService.GetDoctorsByPoliclinicId(id);
            return Ok(doctors);
        }
        [Authorize(Roles = "Doctor")]
        [HttpGet("[action]")]
        public async Task<IActionResult> PatientList()
        {
            var doctorId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
            var patients = await _appointmentService.GetAllAppointmentsByDoctorId(doctorId);
            return Ok(patients);
        }
        [Authorize(Roles = "Patient")]
        [HttpGet("[action]")]
        public async Task<IActionResult> OutOfDateAppointment()
        {
            var patientId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
            var appointments = await _appointmentService.GetOutOfDateAppointmentByUserId(patientId);
            return Ok(appointments);
        }
        [Authorize(Roles = "Patient")]
        [HttpPost("[action]")]
        public async Task<IActionResult> TakeAnAppointment(AddAppointmentDto model)
        {
            if (ModelState.IsValid)
            {
                model.PatientId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                await _appointmentService.AddAppointment(model);
                return Ok("true");
            }
            return BadRequest(ModelState);
           
        }
        [Authorize(Roles = "Patient")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            await _appointmentService.DeleteAppointment(id);
            return Ok();
        }
    }
}
