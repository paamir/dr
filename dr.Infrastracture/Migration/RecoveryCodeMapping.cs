using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dr.Domain.Entities.RecoveryCode;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dr.Infrastracture.Migration
{
    public class RecoveryCodeMapping : IEntityTypeConfiguration<RecoverCode>
    {
        public void Configure(EntityTypeBuilder<RecoverCode> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User).WithOne(x => x.RecoverCode).HasForeignKey<RecoverCode>(x => x.UserId);
        }
    }
}
