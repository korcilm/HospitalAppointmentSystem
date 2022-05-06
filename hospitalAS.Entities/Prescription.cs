using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Entities
{
    public class Prescription:IEntity
    {
        public int Id { get; set; }
        public string Medicament { get; set; }
        public string Description { get; set; }
        public string Period { get; set; }
        public string Usage { get; set; }
        public int UsingCount { get; set; }
        public int MedicamentCount { get; set; }
        public Appointment Appointment { get; set; }
    }
}
