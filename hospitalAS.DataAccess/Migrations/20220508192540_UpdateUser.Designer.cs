﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hospitalAS.DataAccess.Data;

namespace hospitalAS.DataAccess.Migrations
{
    [DbContext(typeof(hospitalASDbContext))]
    [Migration("20220508192540_UpdateUser")]
    partial class UpdateUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("hospitalAS.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("PoliclinicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PoliclinicId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("hospitalAS.Entities.BloodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BloodTypes");
                });

            modelBuilder.Entity("hospitalAS.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("hospitalAS.Entities.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TownId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TownId");

                    b.ToTable("Hospital");
                });

            modelBuilder.Entity("hospitalAS.Entities.Policlinic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.ToTable("Policlinics");
                });

            modelBuilder.Entity("hospitalAS.Entities.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medicament")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MedicamentCount")
                        .HasColumnType("int");

                    b.Property<string>("Period")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsingCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("hospitalAS.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("hospitalAS.Entities.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TestDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TestTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("hospitalAS.Entities.TestType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TestTypes");
                });

            modelBuilder.Entity("hospitalAS.Entities.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("hospitalAS.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BloodTypeId")
                        .HasColumnType("int");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PoliclinicId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BloodTypeId");

                    b.HasIndex("PoliclinicId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("hospitalAS.Entities.Appointment", b =>
                {
                    b.HasOne("hospitalAS.Entities.User", "User")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("hospitalAS.Entities.Policlinic", "Policlinic")
                        .WithMany("Appointments")
                        .HasForeignKey("PoliclinicId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Policlinic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("hospitalAS.Entities.Hospital", b =>
                {
                    b.HasOne("hospitalAS.Entities.Town", "Town")
                        .WithMany("Hospitals")
                        .HasForeignKey("TownId");

                    b.Navigation("Town");
                });

            modelBuilder.Entity("hospitalAS.Entities.Policlinic", b =>
                {
                    b.HasOne("hospitalAS.Entities.Hospital", "Hospital")
                        .WithMany("Policlinics")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("hospitalAS.Entities.Prescription", b =>
                {
                    b.HasOne("hospitalAS.Entities.Appointment", "Appointment")
                        .WithMany("Prescriptions")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("hospitalAS.Entities.Test", b =>
                {
                    b.HasOne("hospitalAS.Entities.TestType", "TestType")
                        .WithMany("Tests")
                        .HasForeignKey("TestTypeId");

                    b.HasOne("hospitalAS.Entities.User", "User")
                        .WithMany("Tests")
                        .HasForeignKey("UserId");

                    b.Navigation("TestType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("hospitalAS.Entities.Town", b =>
                {
                    b.HasOne("hospitalAS.Entities.City", "City")
                        .WithMany("Towns")
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("hospitalAS.Entities.User", b =>
                {
                    b.HasOne("hospitalAS.Entities.BloodType", "BloodType")
                        .WithMany("Users")
                        .HasForeignKey("BloodTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hospitalAS.Entities.Policlinic", "Policlinic")
                        .WithMany("Users")
                        .HasForeignKey("PoliclinicId");

                    b.HasOne("hospitalAS.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BloodType");

                    b.Navigation("Policlinic");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("hospitalAS.Entities.Appointment", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("hospitalAS.Entities.BloodType", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("hospitalAS.Entities.City", b =>
                {
                    b.Navigation("Towns");
                });

            modelBuilder.Entity("hospitalAS.Entities.Hospital", b =>
                {
                    b.Navigation("Policlinics");
                });

            modelBuilder.Entity("hospitalAS.Entities.Policlinic", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("hospitalAS.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("hospitalAS.Entities.TestType", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("hospitalAS.Entities.Town", b =>
                {
                    b.Navigation("Hospitals");
                });

            modelBuilder.Entity("hospitalAS.Entities.User", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Tests");
                });
#pragma warning restore 612, 618
        }
    }
}
