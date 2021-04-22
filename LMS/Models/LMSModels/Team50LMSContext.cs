using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LMS.Models.LMSModels
{
    public partial class Team50LMSContext : DbContext
    {
        public Team50LMSContext()
        {
        }

        public Team50LMSContext(DbContextOptions<Team50LMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<AssignmentCat> AssignmentCat { get; set; }
        public virtual DbSet<Assignments> Assignments { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Enroll> Enroll { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Submissions> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=atr.eng.utah.edu;User Id=u0755840;Password=uptosnuff;Database=Team50LMS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasColumnName("fName")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LName)
                    .IsRequired()
                    .HasColumnName("lName")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<AssignmentCat>(entity =>
            {
                entity.HasKey(e => e.AcId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => new { e.ClassId, e.CatName })
                    .HasName("classID")
                    .IsUnique();

                entity.Property(e => e.AcId).HasColumnName("acID");

                entity.Property(e => e.CatName)
                    .IsRequired()
                    .HasColumnName("catName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ClassId)
                    .HasColumnName("classID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GradeWeight).HasColumnName("gradeWeight");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AssignmentCat)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("AssignmentCat_ibfk_1");
            });

            modelBuilder.Entity<Assignments>(entity =>
            {
                entity.HasKey(e => e.AsnId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.AcId)
                    .HasName("acID");

                entity.HasIndex(e => new { e.AName, e.AcId })
                    .HasName("aName")
                    .IsUnique();

                entity.Property(e => e.AsnId).HasColumnName("asnID");

                entity.Property(e => e.AName)
                    .IsRequired()
                    .HasColumnName("aName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AcId).HasColumnName("acID");

                entity.Property(e => e.DueDate)
                    .HasColumnName("dueDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Instructions)
                    .IsRequired()
                    .HasColumnName("instructions")
                    .HasColumnType("varchar(8192)");

                entity.Property(e => e.PointValue).HasColumnName("pointValue");

                entity.HasOne(d => d.Ac)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.AcId)
                    .HasConstraintName("Assignments_ibfk_1");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasIndex(e => e.CourseId)
                    .HasName("courseID");

                entity.HasIndex(e => e.UId)
                    .HasName("uID");

                entity.HasIndex(e => new { e.SemesterYear, e.SemesterSeason, e.CourseId })
                    .HasName("semesterYear")
                    .IsUnique();

                entity.Property(e => e.ClassId)
                    .HasColumnName("classID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CourseId)
                    .HasColumnName("courseID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EndTime)
                    .HasColumnName("endTime")
                    .HasColumnType("time");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SemesterSeason)
                    .HasColumnName("semesterSeason")
                    .HasColumnType("varchar(6)");

                entity.Property(e => e.SemesterYear).HasColumnName("semesterYear");

                entity.Property(e => e.StartTime)
                    .HasColumnName("startTime")
                    .HasColumnType("time");

                entity.Property(e => e.UId)
                    .IsRequired()
                    .HasColumnName("uID")
                    .HasColumnType("varchar(10)");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Class_ibfk_1");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Class_ibfk_2");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasIndex(e => new { e.Abrv, e.CNumber })
                    .HasName("abrv")
                    .IsUnique();

                entity.Property(e => e.CourseId)
                    .HasColumnName("courseID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Abrv)
                    .IsRequired()
                    .HasColumnName("abrv")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasColumnName("cName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.CNumber)
                    .HasColumnName("cNumber")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.AbrvNavigation)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.Abrv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Course_ibfk_1");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.Abrv)
                    .HasName("PRIMARY");

                entity.Property(e => e.Abrv)
                    .HasColumnName("abrv")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.DName)
                    .IsRequired()
                    .HasColumnName("dName")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Enroll>(entity =>
            {
                entity.HasKey(e => new { e.UId, e.ClassId })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ClassId)
                    .HasName("classID");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.ClassId)
                    .HasColumnName("classID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Grade).HasColumnType("varchar(2)");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Enroll)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("Enroll_ibfk_2");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Enroll)
                    .HasForeignKey(d => d.UId)
                    .HasConstraintName("Enroll_ibfk_1");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Abrv)
                    .HasName("abrv");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Abrv)
                    .IsRequired()
                    .HasColumnName("abrv")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasColumnName("fName")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LName)
                    .IsRequired()
                    .HasColumnName("lName")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.AbrvNavigation)
                    .WithMany(p => p.Professor)
                    .HasForeignKey(d => d.Abrv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Professor_ibfk_1");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Abrv)
                    .HasName("abrv");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Abrv)
                    .IsRequired()
                    .HasColumnName("abrv")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasColumnName("fName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LName)
                    .IsRequired()
                    .HasColumnName("lName")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.AbrvNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.Abrv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Student_ibfk_1");
            });

            modelBuilder.Entity<Submissions>(entity =>
            {
                entity.HasKey(e => new { e.Assignment, e.Student })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Student)
                    .HasName("Submissions_ibfk_2");

                entity.Property(e => e.Student).HasColumnType("char(8)");

                entity.Property(e => e.SubmissionContents).HasColumnType("varchar(8192)");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.AssignmentNavigation)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.Assignment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Submissions_ibfk_1");

                entity.HasOne(d => d.StudentNavigation)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.Student)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Submissions_ibfk_2");
            });
        }
    }
}
