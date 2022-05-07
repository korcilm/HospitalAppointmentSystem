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
            services.AddScoped<IBloodTypeService, BloodTypeService>();
            services.AddScoped<IBloodTypeRepository, EfBloodTypeRepository>();  
            services.AddScoped<IPoliclinicService, PoliclinicService>();
            services.AddScoped<IPoliclinicRepository, EfPoliclinicRepository>();       
            services.AddScoped<IHospitalService, HospitalService>();
            services.AddScoped<IHospitalRepository, EfHospitalRepository>();        
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAppointmentRepository, EfAppointmentRepository>();    
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, EfUserRepository>();           
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleRepository, EfRoleRepository>();            
            services.AddScoped(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));

        }
    }
}
