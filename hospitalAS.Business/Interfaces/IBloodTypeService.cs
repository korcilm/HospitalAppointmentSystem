using hospitalAS.Dto.BloodTypeDtos;
using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Interfaces
{
    public interface IBloodTypeService
    {
        Task<IList<BloodTypeListDto>> GetAllBloodTypes();
    }
}
