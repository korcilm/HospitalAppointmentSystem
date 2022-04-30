using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Entities
{
    public class TestType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Test> Tests { get; set; }
    }
}
