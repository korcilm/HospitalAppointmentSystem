using AutoMapper;
using hospitalAS.Business.Interfaces;
using hospitalAS.DataAccess.Interfaces;
using hospitalAS.Dto.AppointmentDtos;
using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Services
{
    public class AppointmentService : GenericService<Appointment>, IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper, IGenericRepository<Appointment> genericRepository):base(genericRepository)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task AddAppointment(AddAppointmentDto model)
        {

            await _appointmentRepository.Add(_mapper.Map<Appointment>(model));
        }

        public async Task DeleteAppointment(int id)
        {
            var appointment=await _appointmentRepository.GetEntityById(id);
            appointment.IsActive = false;
            await _appointmentRepository.Update(appointment);
        }

        public async Task<IList<ListAppointmentDto>> GetAllAppointmentsByDoctorId(int userId)
        {
            var appointments = await _appointmentRepository.GetAllAppointmentsByDoctorId(userId);
            return _mapper.Map<IList<ListAppointmentDto>>(appointments);
        }

        public async Task<IList<ListAppointmentDto>> GetAllAppointmentsByUserId(int userId)
        {
            var appointments = await _appointmentRepository.GetAllAppointmentsByUserId(userId);
            return _mapper.Map<IList<ListAppointmentDto>>(appointments);
        }

        public async Task<IList<ListAppointmentDto>> GetOutOfDateAppointmentByUserId(int userId)
        {
            var appointments = await _appointmentRepository.GetOutOfDateAppointmentByUserId(userId);
            return _mapper.Map<IList<ListAppointmentDto>>(appointments);
        }

      
    }
}
