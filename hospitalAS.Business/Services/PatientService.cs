using AutoMapper;
using hospitalAS.Business.Interfaces;
using hospitalAS.DataAccess.Interfaces;
using hospitalAS.Dto.PatientDtos;
using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Services
{
    public class PatientService:IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<int> AddPatient(RegisterDto model)
        {
            return await _patientRepository.Add(_mapper.Map<Patient>(model));
        }

        public async Task<Patient> PatientLogin(string identityNumber, string password)
        {
            return await _patientRepository.GetPatientLogin(identityNumber, password);
        }
    }
}
