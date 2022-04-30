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
        public int? TownId { get; set; }
        public string Name { get; set; }
        public Town Town { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
