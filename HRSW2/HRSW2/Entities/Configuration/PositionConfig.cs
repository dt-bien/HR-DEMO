using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSW2.Entities.Configuration
{
    public class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NamePos).IsRequired(true);
            builder.Property(x => x.DepId).IsRequired(true);
            builder.HasOne(x => x.Department).WithMany(x => x.Position).HasForeignKey(x => x.DepId).OnDelete(0);
            builder.HasIndex(x => x.NamePos).IsUnique();
        }     
    }
}


