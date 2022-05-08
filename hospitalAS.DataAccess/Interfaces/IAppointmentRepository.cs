using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.DataAccess.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        Task<IList<Appointment>> GetAllAppointmentsByUserId(int userId);
        Task<IList<Appointment>> GetAllAppointmentsByDoctorId(int userId);
        Task<IList<Appointment>>  GetOutOfDateAppointmentByUserId(int userId);
    }
}
