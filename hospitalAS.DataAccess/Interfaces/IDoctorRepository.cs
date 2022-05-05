﻿using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.DataAccess.Interfaces
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        Task<IList<Doctor>> GetDoctorsByPoliclinicId(int id);
    }
}