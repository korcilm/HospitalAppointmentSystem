using hospitalAS.Dto.ClaimDtos;
using hospitalAS.Dto.UserDtos;
using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Interfaces
{
    public interface IUserService: IGenericService<User>
    {
        Task<ClaimDto> ValidateUser(string identityNumber, string password);
        Task<int> AddUser(RegisterDto model);
        Task<int> GetUserIdByIdentityNumber(string identityNumber);
        Task<IList<DoctorDropdownListDto>> GetDoctorsByPoliclinicId(int id);
        Task<UpdateUserDto> GetUser(int id);
        Task UpdateUser(UpdateUserDto model);
        Task<IList<ListUserDto>> GetAllUser();
        Task<bool> IsExists(int id);
    }
}
