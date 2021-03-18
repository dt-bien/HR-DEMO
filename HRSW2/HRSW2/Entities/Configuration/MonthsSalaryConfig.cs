using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSW2.Entities.Configuration
{
    public class MonthsSalaryConfig : IEntityTypeConfiguration<MonthsSalary>
    {
        public void Configure(EntityTypeBuilder<MonthsSalary> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.EmpInfo).WithMany(x => x.MonthsSalary).HasForeignKey(x => x.EmpId).OnDelete(0);
            builder.HasOne(x => x.Salary).WithMany(x => x.MonthsSalary).HasForeignKey(x => x.SalaryId).OnDelete(0);
        }
    }
}
