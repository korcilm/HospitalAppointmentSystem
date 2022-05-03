using hospitalAS.Dto.PoliclinicDtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Interfaces
{
    public interface IPoliclinicService
    {
        //Task<IList<PoliclinicDropdownListDto>> GetAllPoliclinics();
        Task<IList<PoliclinicDropdownListDto>> GetPoliclinicsByHospitalId(int id);
    }
}
