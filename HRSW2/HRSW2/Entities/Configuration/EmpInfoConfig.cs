using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSW2.Entities.Configuration
{
    public class EmpInfoConfig : IEntityTypeConfiguration<EmpInfo>
    {
        public void Configure(EntityTypeBuilder<EmpInfo> builder)
        {
            builder.ToTable("EmpInfo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdEmp).IsRequired(true);
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(255);
            builder.Property(x => x.Age).IsRequired(true);
            builder.Property(x => x.Address).IsRequired(true).HasMaxLength(255);
            builder.Property(x => x.JoinDay).IsRequired(true);
            builder.Property(x => x.PosId).IsRequired(true);
            builder.HasIndex(x => x.IdEmp).IsUnique();

            builder.HasOne(x => x.Position).WithMany(x => x.EmpInfo).HasForeignKey(x => x.PosId).OnDelete(0);



        }

      
    }
}
