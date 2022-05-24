using hospitalAS.Business.Interfaces;
using hospitalAS.Dto.PrescriptionDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hospitalAS.Web.Controllers
{
    [Authorize]
    public class PrescriptionController : Controller
    {
        private readonly IPrescriptionService _prescriptionService;
        public PrescriptionController( IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.AppointmentId = id;
            var prescriptions = await _prescriptionService.GetAllPrescriptionByAppointmentId(id);
            return View(prescriptions);
        }
        [Authorize(Roles = "Admin,Doctor")]
        public IActionResult AddPrescription(int id)
        {
            AddPrescriptionDto model = new AddPrescriptionDto();
            model.AppointmentId = id;
            return View(model);
        }
        [Authorize(Roles = "Admin,Doctor")]
        [HttpPost]
        public async Task<IActionResult> AddPrescription(AddPrescriptionDto model)
        {
            if (ModelState.IsValid)
            {
                await _prescriptionService.AddPresscription(model);
                return RedirectToAction("Index", new { id = model.AppointmentId });
            }
            return View(model);

        }
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> DeletePrescription(int id,int appointmentId)
        {
            await _prescriptionService.DeletePrescription(id);
            return RedirectToAction("Index", new { id = appointmentId });
        }

    }
}
