using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public int? PoliclinicId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Policlinic Policlinic { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
