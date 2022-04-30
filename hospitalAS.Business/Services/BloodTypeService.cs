using hospitalAS.Business.Interfaces;
using hospitalAS.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.Services
{
    public class BloodTypeService : IBloodTypeService
    {
        private readonly IBloodTypeRepository _bloodTypeRepository;
        public BloodTypeService(IBloodTypeRepository bloodTypeRepository)
        {
            _bloodTypeRepository = bloodTypeRepository;
        }
    }
}
