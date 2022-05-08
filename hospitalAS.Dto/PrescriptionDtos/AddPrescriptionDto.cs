using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Dto.PrescriptionDtos
{
    public class AddPrescriptionDto
    {
        public int AppointmentId { get; set; }
        [Required(ErrorMessage ="İlaç adı boş geçilemez")]
        public string Medicament { get; set; }
        public string Description { get; set; }
        public string Period { get; set; }
        public string Usage { get; set; }
        public int UsingCount { get; set; }
        public int MedicamentCount { get; set; }
    }
}
