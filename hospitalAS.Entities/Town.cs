using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Entities
{
    public class Town : IEntity
    {
        public int Id { get; set; }
        public int? CityId { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public ICollection<Hospital> Hospitals { get; set; }
    }
}
