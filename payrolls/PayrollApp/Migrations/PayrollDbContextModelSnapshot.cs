﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PayrollApp.Models.DAL;

namespace PayrollApp.Migrations
{
    [DbContext(typeof(PayrollDbContext))]
    partial class PayrollDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PayrollApp.Models.DepartmentHead.StoreBonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<int>("Month");

                    b.Property<DateTime>("StoreBonusWritedDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("StoreBonuses","departmentHead");
                });

            modelBuilder.Entity("PayrollApp.Models.DepartmentHead.WorkerBonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<DateTime>("BonusWritedDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("WorkerId");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerBonuses","departmentHead");
                });

            modelBuilder.Entity("PayrollApp.Models.DepartmentHead.WorkerPenalty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<DateTime>("PenaltyWritedDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("WorkerId");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerPenalties","departmentHead");
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Absent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AbsentDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("Attandence");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("WorkerId");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("Absents","employment");
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About")
                        .IsRequired()
                        .HasMaxLength(600);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("HoldingId");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.HasIndex("HoldingId");

                    b.ToTable("Companies","employment");
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("LibDepartamentId");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("LibDepartamentId");

                    b.ToTable("Departments","employment");
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EducationType")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Educations","common");
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("DistrictRegistration")
                        .HasMaxLength(100);

                    b.Property<int>("EducationId");

                    b.Property<int>("FamilyStatusId");

                    b.Property<int>("GenderId");

                    b.Property<string>("IdentityCardNumber")
                        .HasMaxLength(100);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("LivingPlace")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Patronymic")
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("EducationId");

                    b.HasIndex("FamilyStatusId");

                    b.HasIndex("GenderId");

                    b.ToTable("Employees","employment");
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.FamilyStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("FamilyStatus","common");
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PersonGender")
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Genders","common");
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.PastEmployment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("TheReasonForFailure")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("PastEmployments","employment");
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.PastPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PositionSalary")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)))
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("PastPositions","employment");
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PositionSalary")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)))
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Positions","employment");
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Stories","employment");
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Vacation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("WorkerId");

                    b.Property<int>("WorkerVacation");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("Vacations","employment");
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<int>("DepartmentId");

                    b.Property<int>("EmployeeId");

                    b.Property<int?>("PastPositionId");

                    b.Property<int>("PositionId");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PastPositionId");

                    b.HasIndex("PositionId");

                    b.HasIndex("StoreId");

                    b.ToTable("Workers","employment");
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Xitam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("WorkerId");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("Xitam","employment");
                });

            modelBuilder.Entity("PayrollApp.Models.ForIdentity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Image");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("PayrollApp.Models.Head.Holding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About")
                        .IsRequired()
                        .HasMaxLength(600);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("HoldingName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Holdings","head");
                });

            modelBuilder.Entity("PayrollApp.Models.Library.LibDepartament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departaments","library");
                });

            modelBuilder.Entity("PayrollApp.Models.PayrollSpecialist.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("WorkerId");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("Payments","payrollSpecialist");
                });

            modelBuilder.Entity("PayrollApp.Models.PayrollSpecialist.SalaryPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttandenceCount");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("PaymentAmount");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("PositionId");

                    b.Property<string>("StoreBonus");

                    b.Property<string>("VacationDay");

                    b.Property<string>("WorkerBonus");

                    b.Property<string>("WorkerPenalty");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PositionId");

                    b.ToTable("SalaryPayments","payrollSpecialist");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PayrollApp.Models.ForIdentity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PayrollApp.Models.ForIdentity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollApp.Models.ForIdentity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PayrollApp.Models.ForIdentity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollApp.Models.DepartmentHead.StoreBonus", b =>
                {
                    b.HasOne("PayrollApp.Models.Employment.Store", "Store")
                        .WithMany("StoreBonuses")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollApp.Models.DepartmentHead.WorkerBonus", b =>
                {
                    b.HasOne("PayrollApp.Models.Employment.Worker", "Worker")
                        .WithMany("WorkerBonuses")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollApp.Models.DepartmentHead.WorkerPenalty", b =>
                {
                    b.HasOne("PayrollApp.Models.Employment.Worker", "Worker")
                        .WithMany("WorkerPenalties")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Absent", b =>
                {
                    b.HasOne("PayrollApp.Models.Employment.Worker", "Worker")
                        .WithMany("Absents")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Company", b =>
                {
                    b.HasOne("PayrollApp.Models.Head.Holding", "Holding")
                        .WithMany("Companies")
                        .HasForeignKey("HoldingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Department", b =>
                {
                    b.HasOne("PayrollApp.Models.Employment.Company", "Company")
                        .WithMany("Departments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollApp.Models.Library.LibDepartament", "LibDepartament")
                        .WithMany()
                        .HasForeignKey("LibDepartamentId");
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Employee", b =>
                {
                    b.HasOne("PayrollApp.Models.Employment.Education", "Education")
                        .WithMany("Employees")
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollApp.Models.Employment.FamilyStatus", "FamilyStatus")
                        .WithMany("Employees")
                        .HasForeignKey("FamilyStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollApp.Models.Employment.Gender", "Gender")
                        .WithMany("Employees")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.PastEmployment", b =>
                {
                    b.HasOne("PayrollApp.Models.Employment.Employee", "Employee")
                        .WithMany("PastEmployments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.PastPosition", b =>
                {
                    b.HasOne("PayrollApp.Models.Employment.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollApp.Models.Employment.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Position", b =>
                {
                    b.HasOne("PayrollApp.Models.Employment.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollApp.Models.Employment.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Store", b =>
                {
                    b.HasOne("PayrollApp.Models.Employment.Department", "Department")
                        .WithMany("Stores")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Vacation", b =>
                {
                    b.HasOne("PayrollApp.Models.Employment.Worker", "Worker")
                        .WithMany("Vacations")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Worker", b =>
                {
                    b.HasOne("PayrollApp.Models.Employment.Company", "Company")
                        .WithMany("Workers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollApp.Models.Employment.Department", "Department")
                        .WithMany("Workers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollApp.Models.Employment.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollApp.Models.Employment.PastPosition", "PastPosition")
                        .WithMany("Workers")
                        .HasForeignKey("PastPositionId");

                    b.HasOne("PayrollApp.Models.Employment.Position", "Position")
                        .WithMany("Workers")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollApp.Models.Employment.Store", "Store")
                        .WithMany("Workers")
                        .HasForeignKey("StoreId");
                });

            modelBuilder.Entity("PayrollApp.Models.Employment.Xitam", b =>
                {
                    b.HasOne("PayrollApp.Models.Employment.Worker", "Worker")
                        .WithMany("Xitams")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollApp.Models.PayrollSpecialist.Payment", b =>
                {
                    b.HasOne("PayrollApp.Models.Employment.Worker", "Worker")
                        .WithMany("Payments")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollApp.Models.PayrollSpecialist.SalaryPayment", b =>
                {
                    b.HasOne("PayrollApp.Models.Employment.Employee", "Employee")
                        .WithMany("SalaryPayments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollApp.Models.Employment.Position", "Position")
                        .WithMany("SalaryPayments")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
