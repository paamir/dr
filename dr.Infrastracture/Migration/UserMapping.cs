using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dr.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dr.Infrastracture.Migration
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Mobile).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(500);
            builder.Property(x => x.RoleId).IsRequired();


        }
    }
}
