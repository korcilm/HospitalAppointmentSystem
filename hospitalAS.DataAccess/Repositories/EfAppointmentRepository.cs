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
    public class EfAppointmentRepository:EfGenericRepository<Appointment>,IAppointmentRepository
    {
        private readonly hospitalASDbContext _context;
        public EfAppointmentRepository(hospitalASDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<IList<Appointment>> GetAllAppointmentsByUserId(int userId)
        {
            return await _context.Appointments.Include(x=>x.Doctor).Include(x=>x.Policlinic).ThenInclude(x=>x.Hospital).Where(x => x.PatientId == userId).OrderBy(x=>x.Date).ToListAsync();
        }
    }
}