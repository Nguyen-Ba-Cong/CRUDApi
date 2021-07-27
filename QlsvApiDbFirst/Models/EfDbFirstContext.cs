using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QuanLySinhVien.Models
{
    public partial class EfDbFirstContext : DbContext
    {
        public EfDbFirstContext()
        {
        }

        public EfDbFirstContext(DbContextOptions<EfDbFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DevConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
