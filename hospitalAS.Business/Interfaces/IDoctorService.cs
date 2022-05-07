using hospitalAS.Dto.ClaimDtos;
using hospitalAS.Dto.DoctorDtos;
using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Interfaces
{
    public interface IDoctorService
    {
        Task<IList<DoctorDropdownListDto>> GetDoctorsByPoliclinicId(int id);
        Task<ClaimDto> DoctorLogin(string identityNumber, string password);
    }
}
