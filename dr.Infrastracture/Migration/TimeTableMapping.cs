using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using dr.Domain.Entities.TimeTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dr.Infrastracture.Migration
{
    public class TimeTableMapping : IEntityTypeConfiguration<TimeTable>
    {
        public void Configure(EntityTypeBuilder<TimeTable> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsMany(x => x.ShiftHoursList, navigationBuilder =>
            {
                navigationBuilder.ToTable("ShiftTimes");
                navigationBuilder.HasKey(x => x.Id);
                navigationBuilder.Property(x => x.StartDate).IsRequired();
                navigationBuilder.Property(x => x.EndDate).IsRequired();
                navigationBuilder.Property(x => x.IsReserved).IsRequired();
                navigationBuilder.WithOwner(x => x.TimeTable).HasForeignKey(x => x.TimeTableId);
            });
        }
    }
}
