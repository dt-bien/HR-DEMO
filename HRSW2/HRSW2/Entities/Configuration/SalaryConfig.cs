using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSW2.Entities.Configuration
{
    public class SalaryConfig : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Bonus).HasDefaultValue(0);
            builder.Property(x => x.OTSalary).HasDefaultValue(0);

            builder.HasOne(x => x.Position).WithMany(x => x.Salary).HasForeignKey(x => x.PosId).OnDelete(0);
           
            builder.HasOne(x => x.Months).WithMany(x => x.Salary).HasForeignKey(x => x.MonthId).OnDelete(0);
            
           
        }

       
    }
}
