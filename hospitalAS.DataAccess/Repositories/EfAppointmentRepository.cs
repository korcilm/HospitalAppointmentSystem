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
    public class EfAppointmentRepository:EfGenericRepository<Appointment>,IAppointmentRepository
    {
        private readonly hospitalASDbContext _context;
        public EfAppointmentRepository(hospitalASDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<IList<Appointment>> GetAllAppointmentsByUserId(int userId)
        {
           return await _context.Appointments.Include(x=>x.User).Include(x=>x.Policlinic).ThenInclude(x=>x.Hospital).Where(x => x.PatientId == userId && x.Date > DateTime.Now).OrderBy(x=>x.Date).ToListAsync();
        }  
        public async Task<IList<Appointment>> GetAllAppointmentsByDoctorId(int userId)
        {
           return await _context.Appointments.Include(x => x.Policlinic).ThenInclude(x => x.Hospital).Join(_context.Users, app => app.PatientId, user => user.Id,
                (resultApp, resultUser) => new
                {
                    app = resultApp,
                    user= resultUser
                }).Where(x => x.app.DoctorId == userId && x.app.Date > DateTime.Now).Select(I => new Appointment()
                {
                    Id = I.app.Id,
                    Date = I.app.Date,
                    DoctorId = I.app.DoctorId,
                    PatientId = I.app.PatientId,
                    Policlinic = I.app.Policlinic,
                    PoliclinicId = I.app.PoliclinicId,
                    IsActive = I.app.IsActive,
                    Prescriptions = I.app.Prescriptions,
                    User =I.user,                 
                    
                }).OrderBy(x => x.Date).ToListAsync();
        }

        public async Task<IList<Appointment>> GetOutOfDateAppointmentByUserId(int userId)
        {
            return await _context.Appointments.Include(x => x.User).Include(x => x.Policlinic).ThenInclude(x => x.Hospital).Where(x => x.PatientId == userId && x.Date < DateTime.Now).OrderBy(x => x.Date).ToListAsync();
        }
    }
}
