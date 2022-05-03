﻿using hospitalAS.DataAccess.Data;
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
    public class EfDoctorRepository:EfGenericRepository<Doctor>,IDoctorRepository
    {
        private readonly hospitalASDbContext _context;

        public EfDoctorRepository(hospitalASDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<Doctor>> GetDoctorsByPoliclinicId(int id)
        {
            return await _context.Doctors.Where(x => x.PoliclinicId == id).ToListAsync();
        }
    }
}
