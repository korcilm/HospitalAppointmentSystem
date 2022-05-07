using AutoMapper;
using hospitalAS.Dto.AppointmentDtos;
using hospitalAS.Dto.BloodTypeDtos;
using hospitalAS.Dto.ClaimDtos;
using hospitalAS.Dto.HospitalDtos;
using hospitalAS.Dto.PoliclinicDtos;
using hospitalAS.Dto.RoleDtos;
using hospitalAS.Dto.UserDtos;
using hospitalAS.Entities;

namespace hospitalAS.Business.Mapping.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<BloodType, BloodTypeDropdownListDto>();
            CreateMap<Policlinic, PoliclinicDropdownListDto>();
            CreateMap<User, DoctorDropdownListDto>();
            CreateMap<Role, RoleListDto>();
            CreateMap<Appointment, ListAppointmentDto>().ForMember(x => x.UserName, act => act.MapFrom(src => src.User.Name + " " + src.User.Surname))
                                                          .ForMember(x => x.HospitalName, act => act.MapFrom(src => src.Policlinic.Hospital.Name))
                                                          .ForMember(x => x.PoliclinicName, act => act.MapFrom(src => src.Policlinic.Name))
                                                          .ForMember(x => x.Date, act => act.MapFrom(src => src.Date))
                                                          .ForMember(x => x.IsActive, act => act.MapFrom(src => src.IsActive))
                                                          .ForMember(x => x.Id, act => act.MapFrom(src => src.Id));
            CreateMap<Hospital, HospitalDropdownListDto>();
            CreateMap<RegisterDto, User>();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<AddAppointmentDto, Appointment>();
            CreateMap<User, ClaimDto>();
            CreateMap<User, ListUserDto>();
        }
    }
}
