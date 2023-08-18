using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dr.Domain.Entities.Role;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dr.Infrastracture.Migration
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(500);
            builder.HasMany(x => x.Users).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);

            builder.HasData(new List<Role>
            {
                new Role("Doctor", "دکتر"){Id = 1},
                new Role("assistant", "منشی"){Id = 2},
                new Role("Customer", "مشتری"){Id = 3},
            });
        }
    }
}
