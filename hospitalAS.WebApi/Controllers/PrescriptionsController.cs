using hospitalAS.Business.Interfaces;
using hospitalAS.Dto.PrescriptionDtos;
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
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;
        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetPrescriptionsByAppointmentId(int id)
        {
            var prescriptions = await _prescriptionService.GetAllPrescriptionByAppointmentId(id);
            return Ok(prescriptions);
        }

        [ValidModel]
        [HttpPost("[action]")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> AddPrescription(AddPrescriptionDto model)
        {
            await _prescriptionService.AddPresscription(model);
            return CreatedAtAction(nameof(GetPrescriptionsByAppointmentId), routeValues: new { id = model.AppointmentId }, null);
        }

        [HttpDelete("[action]/{id}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            await _prescriptionService.DeletePrescription(id);
            return Ok();
        }
    }
}
