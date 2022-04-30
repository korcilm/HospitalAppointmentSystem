using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Entities
{
    public class BloodType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
