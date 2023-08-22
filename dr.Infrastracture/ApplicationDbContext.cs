using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dr.Domain.Entities.Doctor;
using dr.Domain.Entities.RecoveryCode;
using dr.Domain.Entities.Role;
using dr.Domain.Entities.TimeTable;
using dr.Domain.Entities.User;
using dr.Infrastracture.Migration;
using Microsoft.EntityFrameworkCore;

namespace dr.Infrastracture
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RecoverCode> RecoverCodes { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}