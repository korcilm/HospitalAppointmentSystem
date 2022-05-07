using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Entities
{
    public class Test : IEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? TestTypeId { get; set; }
        public DateTime TestDate { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }
        public TestType TestType { get; set; }
        public User User { get; set; }
    }
}
