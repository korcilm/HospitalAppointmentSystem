using hospitalAS.Dto.RoleDtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Interfaces
{
    public interface IRoleService
    {
        Task<IList<RoleListDto>> GetAllRoles();
    }
}
