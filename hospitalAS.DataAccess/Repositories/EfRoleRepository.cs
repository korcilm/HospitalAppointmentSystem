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
    public class EfRoleRepository : EfGenericRepository<Role>, IRoleRepository
    {
        private readonly hospitalASDbContext _context;
        public EfRoleRepository(hospitalASDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
