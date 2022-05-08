using AutoMapper;
using hospitalAS.Business.Interfaces;
using hospitalAS.DataAccess.Interfaces;
using hospitalAS.Dto.PrescriptionDtos;
using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IMapper _mapper;
        public PrescriptionService(IPrescriptionRepository prescriptionRepository, IMapper mapper)
        {
            _prescriptionRepository = prescriptionRepository;
            _mapper = mapper;
        }
        public async Task AddPresscription(AddPrescriptionDto model)
        {
            await _prescriptionRepository.Add(_mapper.Map<Prescription>(model));
        }

        public async Task<IList<ListPrescriptionDto>> GetAllPrescriptionByAppointmentId(int id)
        {
            var prescriptions = await _prescriptionRepository.GetAllPrescriptionByAppointmentId(id);
            return _mapper.Map<IList<ListPrescriptionDto>>(prescriptions);
        }
    }
}
