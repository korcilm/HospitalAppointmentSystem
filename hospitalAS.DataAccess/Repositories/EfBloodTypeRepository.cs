using hospitalAS.DataAccess.Data;
using hospitalAS.DataAccess.Interfaces;
using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.DataAccess.Repositories
{
    public class EfBloodTypeRepository : EfGenericRepository<BloodType>, IBloodTypeRepository
    {
        private readonly hospitalASDbContext _context;

        public EfBloodTypeRepository(hospitalASDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
