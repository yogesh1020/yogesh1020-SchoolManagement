using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolManagementApi
{
    public partial class SchoolManagementDbContext : DbContext
    {
        public SchoolManagementDbContext()
        {
        }

        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admissions> Admissions { get; set; }
        public virtual DbSet<Installments> Installments { get; set; }
        public virtual DbSet<Standards> Standards { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<VStudentDetails> VStudentDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=YOGESH;Initial Catalog=SchoolManagementDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admissions>(entity =>
            {
                entity.HasKey(e => e.AdmissionId);

                entity.HasOne(d => d.Standard)
                    .WithMany(p => p.Admissions)
                    .HasForeignKey(d => d.StandardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admissions_Standards");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Admissions)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admissions_Students");
            });

            modelBuilder.Entity<Installments>(entity =>
            {
                entity.HasKey(e => e.InstallmentId);

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Standard)
                    .WithMany(p => p.Installments)
                    .HasForeignKey(d => d.StandardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Installments_Standards");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Installments)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Installments_Students");
            });

            modelBuilder.Entity<Standards>(entity =>
            {
                entity.HasKey(e => e.StandardId);

                entity.Property(e => e.StandardName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Standards)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Standards_Students");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentDob)
                    .HasColumnName("StudentDOB")
                    .HasColumnType("date");

                entity.Property(e => e.StudentGender)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VStudentDetails>(entity =>
            {
                entity.HasKey(e=>e.StudentId);

                entity.ToView("vStudentDetails");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentDob)
                    .HasColumnName("StudentDOB")
                    .HasColumnType("date");

                entity.Property(e => e.StudentGender)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
