using hospitalAS.DataAccess.Interfaces;
using hospitalAS.Dto.PatientDtos;
using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Interfaces
{
    public interface IPatientService
    {
        Task<int> AddPatient(RegisterDto model);
        Task<Patient> PatientLogin(string identityNumber, string password);
        Task<int> GetUserIdByIdentityNumber(string identityNumber);
    }
}
