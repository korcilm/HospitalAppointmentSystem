using AutoMapper;
using hospitalAS.Business.Interfaces;
using hospitalAS.DataAccess.Interfaces;
using hospitalAS.Dto.BloodTypeDtos;
using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Services
{
    public class BloodTypeService : IBloodTypeService
    {
        private readonly IBloodTypeRepository _bloodTypeRepository;
        private readonly IMapper _mapper;
        public BloodTypeService(IBloodTypeRepository bloodTypeRepository ,IMapper mapper)
        {
            _bloodTypeRepository = bloodTypeRepository;
            _mapper = mapper;
        }

        public async Task<IList<BloodTypeListDto>> GetAllBloodTypes()
        {
            var bloodTypes = await _bloodTypeRepository.GetAllEntities();
            return _mapper.Map<IList<BloodTypeListDto>>(bloodTypes);
        }
    }
}
