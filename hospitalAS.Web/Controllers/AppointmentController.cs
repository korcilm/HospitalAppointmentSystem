using hospitalAS.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hospitalAS.Web.Controllers
{
    
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public async Task<IActionResult> CancelAppointment(int id)
        {
            await _appointmentService.DeleteAppointment(id);
            return RedirectToAction("Index","Home");
        }
    }
}
