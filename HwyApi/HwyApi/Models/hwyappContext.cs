using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HwyApi.Models
{
    public partial class hwyappContext : DbContext
    {
        public virtual DbSet<Testmap> Testmap { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=den1.mssql7.gear.host;Initial Catalog=hwyapp;Persist Security Info=False;User ID=hwyapp;Password=Ai47?87u6-50;MultipleActiveResultSets=False;TrustServerCertificate=True;Connection Timeout=60;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Testmap>(entity =>
            {
                entity.HasKey(e => e.Testid);

                entity.ToTable("testmap");

                entity.Property(e => e.Testid).HasColumnName("testid");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lng).HasColumnName("lng");

                entity.Property(e => e.Obj)
                    .HasColumnName("obj")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
