using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSW2.Entities.Configuration
{
    public class OffDayConfig : IEntityTypeConfiguration<OffDay>
    {
        public void Configure(EntityTypeBuilder<OffDay> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.EmpInfo).WithMany(x => x.OffDay).HasForeignKey(x => x.EmployeeId).OnDelete(0);
        }
    }
}
