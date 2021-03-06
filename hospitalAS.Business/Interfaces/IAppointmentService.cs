using hospitalAS.Dto.AppointmentDtos;
using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Interfaces
{
    public interface IAppointmentService : IGenericService<Appointment>
    {
        Task AddAppointment(AddAppointmentDto model);
        Task<IList<ListAppointmentDto>>  GetAllAppointmentsByUserId(int userId);
        Task<IList<ListAppointmentDto>>  GetAllAppointmentsByDoctorId(int userId);
        Task DeleteAppointment(int id);
        Task<IList<ListAppointmentDto>> GetOutOfDateAppointmentByUserId(int userId);
    }
}
