using hospitalAS.Business.DIContainer;
using hospitalAS.Business.Mapping.AutoMapper;
using hospitalAS.DataAccess.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "hospitalAS.WebApi", Version = "v1" });
            });
            services.AddContainerWithDependencies();
            var connectionString = Configuration.GetConnectionString("db");
            services.AddDbContext<hospitalASDbContext>(opt => opt.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddAutoMapper(typeof(MapProfile));
            services.AddCors(opt => opt.AddPolicy("Allow", builder =>
              {
                  builder.AllowAnyOrigin();
                  builder.AllowAnyMethod();
                  builder.AllowAnyHeader();
              }));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Dont-count-your-chickens-before-they-hatch"));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(opt =>
                                  {
                                      opt.SaveToken = true;
                                      opt.TokenValidationParameters = new TokenValidationParameters
                                      {
                                          ValidateActor = true,
                                          ValidateIssuer = true,
                                          ValidateAudience = true,

                                          ValidIssuer = "google.com.tr",
                                          ValidAudience = "google.com.tr",
                                          ValidateIssuerSigningKey = true,
                                          IssuerSigningKey = key
                                      };
                                  });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "hospitalAS.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("Allow");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
