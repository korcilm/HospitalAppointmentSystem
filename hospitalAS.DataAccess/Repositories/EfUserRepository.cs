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
    public class EfUserRepository : EfGenericRepository<User>, IUserRepository
    {
        private readonly hospitalASDbContext _context;
        public EfUserRepository(hospitalASDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User> ValidateUser(string identityNumber, string password)
        {
            return await _context.Users.Include(x => x.Role).Where(x => x.IdentityNumber == identityNumber && x.Password == password).FirstOrDefaultAsync();
        }
        public async Task<int> GetUserIdByIdentityNumber(string identityNumber)
        {
            var user = await _context.Users.Where(x => x.IdentityNumber == identityNumber).FirstOrDefaultAsync();
            return user.Id;
        }

        public async Task<IList<User>> GetDoctorsByPoliclinicId(int id)
        {
            return await _context.Users.Where(x => x.PoliclinicId == id).ToListAsync();
        }
    }
}
