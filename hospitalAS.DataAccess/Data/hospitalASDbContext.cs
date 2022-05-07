using hospitalAS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.DataAccess.Data
{
    public class hospitalASDbContext:DbContext
    {
        public hospitalASDbContext(DbContextOptions<hospitalASDbContext> options):base(options)
        {

        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Policlinic> Policlinics { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestType> TestTypes { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<Appointment>().HasOne(p => p.User)
                                              .WithMany(p => p.Appointments)
                                              .HasForeignKey(p => p.DoctorId)
                                              .OnDelete(DeleteBehavior.NoAction); 
            modelBuilder.Entity<Appointment>().HasOne(p => p.Policlinic)
                                              .WithMany(p => p.Appointments)
                                              .HasForeignKey(p => p.PoliclinicId)
                                              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
