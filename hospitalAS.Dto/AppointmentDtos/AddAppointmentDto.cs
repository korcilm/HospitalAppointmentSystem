using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hospitalAS.Dto.AppointmentDtos
{
    public class AddAppointmentDto
    {
        public int PatientId { get; set; }      
        public int DoctorId { get; set; }
        public int PoliclinicId { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
