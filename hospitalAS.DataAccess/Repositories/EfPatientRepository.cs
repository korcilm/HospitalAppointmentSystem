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
    public class EfPatientRepository : EfGenericRepository<Patient>,IPatientRepository
    {
        private readonly hospitalASDbContext _context;

        public EfPatientRepository(hospitalASDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<Patient> GetPatientLogin(string identityNumber, string password)
        {
            return await _context.Patients.Where(x => x.IdentityNumber == identityNumber && x.Password == password).FirstOrDefaultAsync();
        }

        public async Task<int> GetUserIdByIdentityNumber(string identityNumber)
        {
            var user= await _context.Patients.Where(x => x.IdentityNumber == identityNumber).FirstOrDefaultAsync();
            return user.Id;

        }
    }
}
