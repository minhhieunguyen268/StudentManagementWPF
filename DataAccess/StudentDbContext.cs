using System;
using System.Collections.Generic;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess;

public partial class StudentDbContext : DbContext
{
    public StudentDbContext()
    {
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentScore> StudentScores { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Timetable> Timetables { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsetting.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DBDefault");
        optionsBuilder.UseSqlServer(connectionString);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC074DF9CB48");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Username, "UQ__Account__536C85E4BD1C20B2").IsUnique();

            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Class__3214EC0792497CB5");

            entity.ToTable("Class");

            entity.Property(e => e.ClassName).HasMaxLength(50);
            entity.Property(e => e.Course).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Mssv).HasName("PK__Student__6CB3B7F98F82E2DC");

            entity.ToTable("Student");

            entity.Property(e => e.Mssv)
                .HasMaxLength(20)
                .HasColumnName("MSSV");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.StudentCode).HasMaxLength(10);

            entity.HasOne(d => d.Account).WithMany(p => p.Students)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Student__Account__4F7CD00D");

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Student__ClassId__4E88ABD4");
        });

        modelBuilder.Entity<StudentScore>(entity =>
        {
            entity.HasKey(e => new { e.Mssv, e.Subject }).HasName("PK__StudentS__2698AA6900341E7A");

            entity.Property(e => e.Mssv)
                .HasMaxLength(20)
                .HasColumnName("MSSV");
            entity.Property(e => e.Subject).HasMaxLength(100);
            entity.Property(e => e.ExamScore).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.FinalScore).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.MidTermScore).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.MssvNavigation).WithMany(p => p.StudentScores)
                .HasForeignKey(d => d.Mssv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentSco__MSSV__59FA5E80");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Msgv).HasName("PK__Teacher__6CB35172F1A33F31");

            entity.ToTable("Teacher");

            entity.Property(e => e.Msgv)
                .HasMaxLength(20)
                .HasColumnName("MSGV");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);

            entity.HasOne(d => d.Account).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Teacher__Account__52593CB8");
        });

        modelBuilder.Entity<Timetable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Timetabl__3214EC07388BC120");

            entity.ToTable("Timetable");

            entity.Property(e => e.Msgv)
                .HasMaxLength(20)
                .HasColumnName("MSGV");
            entity.Property(e => e.Mssv)
                .HasMaxLength(20)
                .HasColumnName("MSSV");
            entity.Property(e => e.Room).HasMaxLength(50);
            entity.Property(e => e.Subject).HasMaxLength(100);

            entity.HasOne(d => d.Class).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Timetable__Class__571DF1D5");

            entity.HasOne(d => d.MsgvNavigation).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.Msgv)
                .HasConstraintName("FK__Timetable__MSGV__5629CD9C");

            entity.HasOne(d => d.MssvNavigation).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.Mssv)
                .HasConstraintName("FK__Timetable__MSSV__5535A963");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
