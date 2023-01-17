using System;

using EmployeeSignInSystem.Models;
using EmployeeSignInSystem.Models.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmployeeSignInSystem.DBContext
{
    public partial class EmployeeSigningSystemContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public EmployeeSigningSystemContext()
        {
        }

        public EmployeeSigningSystemContext(DbContextOptions<EmployeeSigningSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public virtual DbSet<EmployeeTempBadge> EmployeeTempBadge { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:vanshsqlserver.database.windows.net,1433;Initial Catalog=Vanshdb;Persist Security Info=False;User ID=vansh;Password=1955@Vietnamwar;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<EmployeeDetails>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Photo).IsRequired();
            });

            modelBuilder.Entity<EmployeeTempBadge>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmployeeFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.EmployeeLastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TempBadge).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
