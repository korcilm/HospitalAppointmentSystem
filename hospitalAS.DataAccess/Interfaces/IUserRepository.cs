using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.DataAccess.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> ValidateUser(string identityNumber, string password);
        Task<IList<User>> GetDoctorsByPoliclinicId(int id);
        Task<int> GetUserIdByIdentityNumber(string identityNumber);
    }
}
