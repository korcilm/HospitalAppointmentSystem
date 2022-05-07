using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Entities
{
    public class Policlinic : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
