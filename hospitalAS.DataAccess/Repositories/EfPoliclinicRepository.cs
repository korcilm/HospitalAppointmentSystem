using hospitalAS.DataAccess.Data;
using hospitalAS.DataAccess.Interfaces;
using hospitalAS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.DataAccess.Repositories
{
    public class EfPoliclinicRepository : EfGenericRepository<Policlinic>, IPoliclinicRepository
    {
        private readonly hospitalASDbContext _context;

        public EfPoliclinicRepository(hospitalASDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<Policlinic>> GetPoliclinicsByHospitalId(int id)
        {
            return await _context.Policlinics.Where(x => x.HospitalId == id).ToListAsync();
        }
    }
}
