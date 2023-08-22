using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dr.Domain.Entities.Doctor;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dr.Infrastracture.Migration
{
	public class DoctorMapping: IEntityTypeConfiguration<Doctor>
	{
		public void Configure(EntityTypeBuilder<Doctor> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Skill).IsRequired().HasMaxLength(500);
			builder.Property(x => x.Name).IsRequired().HasMaxLength(500);
			builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
			builder.Property(x => x.IsActive).IsRequired();
		}
	}
}
