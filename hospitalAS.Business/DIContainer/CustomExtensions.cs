using hospitalAS.Business.Interfaces;
using hospitalAS.Business.Services;
using hospitalAS.DataAccess.Interfaces;
using hospitalAS.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.Business.DIContainer
{
    public static class CustomExtensions
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPatientRepository, EfPatientRepository>();            
            services.AddScoped(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));

        }
    }
}
