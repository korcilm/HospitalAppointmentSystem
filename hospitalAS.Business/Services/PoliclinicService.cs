using AutoMapper;
using hospitalAS.Business.Interfaces;
using hospitalAS.DataAccess.Interfaces;
using hospitalAS.Dto.PoliclinicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Services
{
    public class PoliclinicService : IPoliclinicService
    {
        private readonly IPoliclinicRepository _policlinicRepository;
        private readonly IMapper _mapper;
        public PoliclinicService(IPoliclinicRepository policlinicRepository, IMapper mapper)
        {
            _policlinicRepository = policlinicRepository;
            _mapper = mapper;
        }
        public async Task<IList<PoliclinicDropdownListDto>> GetPoliclinicsByHospitalId(int id)
        {
            var policlinics = await _policlinicRepository.GetPoliclinicsByHospitalId(id);
            return _mapper.Map<IList<PoliclinicDropdownListDto>>(policlinics);
        }
    }
}
