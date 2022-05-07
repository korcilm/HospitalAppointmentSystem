using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Dto.AppointmentDtos
{
    public class ListAppointmentDto
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string PoliclinicName { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
    }
}
