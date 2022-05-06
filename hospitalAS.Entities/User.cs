using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Entities
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public int? BloodTypeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public BloodType BloodType { get; set; }
        public ICollection<Test> Tests { get; set; }
    }
}
