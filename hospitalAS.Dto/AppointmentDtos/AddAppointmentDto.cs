using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hospitalAS.Dto.AppointmentDtos
{
    public class AddAppointmentDto
    {
        [Required(ErrorMessage = "Hasta alanı boş geçilmez")]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "Doktor alanı boş geçilmez")]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Poliklinik alanı boş geçilmez")]
        public int PoliclinicId { get; set; }
        [Required(ErrorMessage = "Tarih alanı boş geçilmez")]
        public DateTime Date { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
