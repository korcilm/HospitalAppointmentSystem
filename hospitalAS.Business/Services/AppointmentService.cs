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
    public class AppointmentService: IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task AddAppointment(AppointmentDto model)
        {
            
           await _appointmentRepository.Add(_mapper.Map<Appointment>(model));
        }
    }
}
