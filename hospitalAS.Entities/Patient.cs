using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public int? BloodTypeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<Appointment> Appointments { get; set; }
        public BloodType BloodType { get; set; }
        public List<Test> Tests { get; set; }
    }
}
