using AutoMapper;
using hospitalAS.Business.Interfaces;
using hospitalAS.DataAccess.Interfaces;
using hospitalAS.Dto.ClaimDtos;
using hospitalAS.Dto.DoctorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<ClaimDto> DoctorLogin(string identityNumber, string password)
        {
            var doctor = await _doctorRepository.GetDoctorLogin(identityNumber, password);
            return _mapper.Map<ClaimDto>(doctor);
        }

        public async Task<IList<DoctorDropdownListDto>> GetDoctorsByPoliclinicId(int id)
        {
            var doctors = await _doctorRepository.GetDoctorsByPoliclinicId(id);
            return _mapper.Map<IList<DoctorDropdownListDto>>(doctors);
        }
    }
}
