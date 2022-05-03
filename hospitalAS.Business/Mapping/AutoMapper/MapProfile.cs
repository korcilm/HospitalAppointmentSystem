using AutoMapper;
using hospitalAS.Dto.BloodTypeDtos;
using hospitalAS.Dto.PatientDtos;
using hospitalAS.Dto.PoliclinicDtos;
using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Mapping.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<BloodType, BloodTypeListDto>();
            CreateMap<Policlinic, PoliclinicListDto>();
            CreateMap<RegisterDto, Patient>();
        }
    }
}
