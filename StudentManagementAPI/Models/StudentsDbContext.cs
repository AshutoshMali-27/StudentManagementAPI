using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementAPI.Models;

public partial class StudentsDbContext : DbContext
{
    public StudentsDbContext()
    {
    }

    public StudentsDbContext(DbContextOptions<StudentsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<TblExam> TblExams { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    public virtual DbSet<TblStudentDetail1> TblStudentDetails1 { get; set; }

    public virtual DbSet<TblSubject> TblSubjects { get; set; }

    public virtual DbSet<TblstudentDetail> TblstudentDetails { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_dbo.Students");

            entity.Property(e => e.id).HasColumnName("id");
        });

        modelBuilder.Entity<TblExam>(entity =>
        {
            entity.HasKey(e => e.ExamId);

            entity.ToTable("TblExam");

            entity.Property(e => e.ExamId).ValueGeneratedNever();
            entity.Property(e => e.ExamName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.ClassName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TblStudentDetail1>(entity =>
        {
            entity.ToTable("tblStudentDetails");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.MarkObtained).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.TotalMarks).HasColumnType("numeric(18, 0)");
        });

        modelBuilder.Entity<TblSubject>(entity =>
        {
            entity.HasKey(e => e.SubjectId);

            entity.ToTable("tblSubject");

            entity.Property(e => e.SubjectName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblstudentDetail>(entity =>
        {
            entity.ToTable("tblstudentDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FatherName).HasMaxLength(50);
            entity.Property(e => e.StudentGender).HasMaxLength(50);
            entity.Property(e => e.StudentName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
