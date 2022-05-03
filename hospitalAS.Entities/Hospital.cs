using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Entities
{
    public class Hospital:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TownId { get; set; }
        public Town Town { get; set; }
        public ICollection<Policlinic> Policlinics { get; set; }
    }
}
