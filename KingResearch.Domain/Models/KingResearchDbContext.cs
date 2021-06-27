using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KingResearch.Domain.Models
{
    public partial class KingResearchDbContext : DbContext
    {
        public KingResearchDbContext()
        {
        }

        public KingResearchDbContext(DbContextOptions<KingResearchDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dmat> Dmats { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-AKDMP76I\\SQLEXPRESS;Initial Catalog=KingResearchDb;User ID=sa;Password=Admin@123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Dmat>(entity =>
            {
                entity.ToTable("DMat");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.Property(e => e.DmatLink)
                    .IsUnicode(false)
                    .HasColumnName("DMatLink");

                entity.Property(e => e.DmatName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DMatName");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.CreateBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.Property(e => e.EventContent).IsUnicode(false);

                entity.Property(e => e.EventDescription).IsUnicode(false);

                entity.Property(e => e.EventName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EventVideoLink).IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ServiceDescription).IsUnicode(false);

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("Video");

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateOn).HasColumnType("datetime");

                entity.Property(e => e.VideoDescption).IsUnicode(false);

                entity.Property(e => e.VideoLink).IsUnicode(false);

                entity.Property(e => e.VideoName)
                    .HasMaxLength(550)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
