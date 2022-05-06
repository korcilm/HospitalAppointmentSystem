using hospitalAS.Business.Interfaces;
using hospitalAS.Dto.PatientDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace hospitalAS.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IBloodTypeService _bloodTypeService;  
        public PatientController(IPatientService patientService, IBloodTypeService bloodTypeService)
        {
            _patientService = patientService;
            _bloodTypeService = bloodTypeService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.BloodTypes = new SelectList(await _bloodTypeService.GetAllBloodTypes(), "Id", "Name");
            var patient= await _patientService.GetPatient(await GetUserId());
            return View(patient);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UpdatePatientDto model)
        {
            if (ModelState.IsValid)
            {
                await _patientService.UpdatePatient(model);
                return RedirectToAction("Index");
            }
            ViewBag.BloodTypes = new SelectList(await _bloodTypeService.GetAllBloodTypes(), "Id", "Name");
            return View();
            
        }

        private async Task<int> GetUserId()
        {
            var identityNumber = User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value;
            int userId = await _patientService.GetUserIdByIdentityNumber(identityNumber);
            return userId;
        }
    }
}
