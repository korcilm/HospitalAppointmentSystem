using AutoMapper;
using hospitalAS.Dto.AppointmentDtos;
using hospitalAS.Dto.BloodTypeDtos;
using hospitalAS.Dto.ClaimDtos;
using hospitalAS.Dto.DoctorDtos;
using hospitalAS.Dto.HospitalDtos;
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
            CreateMap<BloodType, BloodTypeDropdownListDto>();
            CreateMap<Policlinic, PoliclinicDropdownListDto>();
            CreateMap<Doctor, DoctorDropdownListDto>();
            CreateMap<Appointment, ListAppointmentDto>().ForMember(x => x.DoctorName, act => act.MapFrom(src => src.Doctor.Name + " " + src.Doctor.Surname))
                                                        .ForMember(x => x.HospitalName, act => act.MapFrom(src => src.Policlinic.Hospital.Name))
                                                        .ForMember(x => x.PoliclinicName, act => act.MapFrom(src => src.Policlinic.Name))
                                                        .ForMember(x => x.Date, act => act.MapFrom(src => src.Date))
                                                        .ForMember(x => x.IsActive, act => act.MapFrom(src => src.IsActive))
                                                        .ForMember(x => x.Id, act => act.MapFrom(src => src.Id));
            CreateMap<Hospital, HospitalDropdownListDto>();
            CreateMap<RegisterDto, Patient>();
            CreateMap<Patient, UpdatePatientDto>().ReverseMap();
            CreateMap<AddAppointmentDto, Appointment>();
            CreateMap<Patient, ClaimDto>();
            CreateMap<Doctor, ClaimDto>();
        }
    }
}
