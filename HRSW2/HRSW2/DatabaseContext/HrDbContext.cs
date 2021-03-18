using HRSW2.Entities;
using HRSW2.Entities.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HRSW2.DatabaseContext
{
    public class HrDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public HrDbContext(DbContextOptions<HrDbContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           

            builder.ApplyConfiguration(new EmpInfoConfig());
            builder.ApplyConfiguration(new DepartmentConfig());
            builder.ApplyConfiguration(new MonthsSalaryConfig());
            builder.ApplyConfiguration(new PositionConfig());
            builder.ApplyConfiguration(new SalaryConfig());
            builder.ApplyConfiguration(new OffDayConfig());

            builder.Entity<AppUser>().ToTable("AppUser");
            builder.Entity<AppRole>().ToTable("AppRole");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserToken").HasKey(x => x.UserId);
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<AppRole> AppRole { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<EmpInfo> EmpInfo { get; set; }

        public DbSet<Months> Month { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Salary> Salary { get; set; }
        public DbSet<OffDay> OffDay { get; set; }
        public DbSet<MonthsSalary> MonthsSalary { get; set; }

    }
}
