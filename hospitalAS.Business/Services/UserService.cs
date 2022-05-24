using AutoMapper;
using hospitalAS.Business.Interfaces;
using hospitalAS.DataAccess.Interfaces;
using hospitalAS.Dto.ClaimDtos;
using hospitalAS.Dto.UserDtos;
using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Services
{
    public class UserService :GenericService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper, IGenericRepository<User> genericRepository) :base(genericRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> AddUser(RegisterDto model)
        {
            model.RoleId = model.RoleId == 0 ? 1:model.RoleId;
            return await _userRepository.Add(_mapper.Map<User>(model));
        }
        public async Task<UpdateUserDto> GetUser(int id)
        {
            return _mapper.Map<UpdateUserDto>(await _userRepository.GetEntityById(id));
        }

        public async Task<IList<DoctorDropdownListDto>> GetDoctorsByPoliclinicId(int id)
        {
            var doctors = await _userRepository.GetDoctorsByPoliclinicId(id);
            return _mapper.Map<IList<DoctorDropdownListDto>>(doctors);
        }
        public async Task<int> GetUserIdByIdentityNumber(string identityNumber)
        {
            return await _userRepository.GetUserIdByIdentityNumber(identityNumber);
        }
        public async Task UpdateUser(UpdateUserDto model)
        {
            await _userRepository.Update(_mapper.Map<User>(model));
        }
        public async Task<ClaimDto> ValidateUser(string identityNumber, string password)
        {
            var user = await _userRepository.ValidateUser(identityNumber, password);
            return _mapper.Map<ClaimDto>(user);
        }

        public async Task<IList<ListUserDto>> GetAllUser()
        {
            var users = await _userRepository.GetAllUser();
            return _mapper.Map<IList<ListUserDto>>(users);
        }

        public async Task<bool> IsExists(int id)
        {
            return await _userRepository.IsExists(id);
        }
    }
}
