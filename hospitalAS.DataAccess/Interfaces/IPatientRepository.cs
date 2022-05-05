using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.DataAccess.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<Patient> GetPatientLogin(string identityNumber, string password);
        Task<int> GetUserIdByIdentityNumber(string identityNumber);
    }
}
