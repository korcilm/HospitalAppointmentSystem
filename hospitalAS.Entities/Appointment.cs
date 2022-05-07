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
        public int? PrescriptionId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int PoliclinicId { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public Policlinic Policlinic { get; set; }
        public User User { get; set; }
        public Prescription Prescription { get; set; }
    }
}
