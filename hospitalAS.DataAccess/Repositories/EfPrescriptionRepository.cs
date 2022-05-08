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
    public class EfPrescriptionRepository : EfGenericRepository<Prescription>, IPrescriptionRepository
    {
        private readonly hospitalASDbContext _context;
        public EfPrescriptionRepository(hospitalASDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<Prescription>> GetAllPrescriptionByAppointmentId(int id)
        {
            return await _context.Prescriptions.Include(x=>x.Appointment).Where(x => x.AppointmentId == id).ToListAsync();
        }
    }
}
