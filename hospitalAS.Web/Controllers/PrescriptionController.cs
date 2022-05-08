using hospitalAS.Business.Interfaces;
using hospitalAS.Dto.PrescriptionDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hospitalAS.Web.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly IPrescriptionService _prescriptionService;
        private readonly IBloodTypeService _bloodTypeService;
        private readonly IRoleService _roleService;
        public PrescriptionController(IBloodTypeService bloodTypeService, IPrescriptionService prescriptionService, IRoleService roleService)
        {
            _prescriptionService = prescriptionService;
            _bloodTypeService = bloodTypeService;
            _roleService = roleService;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.AppointmentId = id;
           var prescriptions= await _prescriptionService.GetAllPrescriptionByAppointmentId(id);            
            return View(prescriptions);
        }
        public IActionResult AddPrescription(int id)
        {
            AddPrescriptionDto model = new AddPrescriptionDto();
            model.AppointmentId = id;
            return View(model);
        }  

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
    }
}
