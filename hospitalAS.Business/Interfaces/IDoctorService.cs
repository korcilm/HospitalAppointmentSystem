﻿using hospitalAS.Dto.DoctorDtos;
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
    }
}
