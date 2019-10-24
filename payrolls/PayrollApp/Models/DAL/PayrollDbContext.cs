
using PayrollApp.Models.Head;
using Microsoft.EntityFrameworkCore;
using PayrollApp.Models.Employment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PayrollApp.Models.ForIdentity;
using PayrollApp.Models.DepartmentHead;
using PayrollApp.Models.PayrollSpecialist;


namespace PayrollApp.Models.DAL
{
    public class PayrollDbContext : IdentityDbContext<ApplicationUser>
    { 
        public PayrollDbContext(DbContextOptions<PayrollDbContext> options) : base(options) { }




        public DbSet<Company> Companies { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<PastPosition> PastPositions { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<PastEmployment> PastEmployments { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<StoreBonus> StoreBonuses { get; set; }
        public DbSet<Absent> Absents { get; set; }
        public DbSet<Xitam> Xitams { get; set; }
        public DbSet<WorkerBonus> WorkerBonuses { get; set; }
        public DbSet<WorkerPenalty> WorkerPenalties { get; set; }


        public DbSet<Store> Stores { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Holding> Holdings { get; set; }

        public DbSet<Education> Educations { get; set; }
        public DbSet<FamilyStatus> FamilyStatuses { get; set; }
        public DbSet<Gender> Genders { get; set; }


        public DbSet<Payment> Payments { get; set; }

        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<SalaryPayment> SalaryPayments { get; set; }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //}
    }
}
