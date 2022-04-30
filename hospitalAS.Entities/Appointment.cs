using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Entities
{
    public class Appointment:IEntity
    {
        public int Id { get; set; }        
        public int PatientId { get; set; }
        [Required(ErrorMessage = "Doktor seçiniz")]
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
