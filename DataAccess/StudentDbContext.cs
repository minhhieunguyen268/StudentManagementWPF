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
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC077AC8B7BC");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Username, "UQ__Account__536C85E409E26442").IsUnique();

            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Student).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Account__Student__534D60F1");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__Account__Teacher__5441852A");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Class__3214EC07A3608F1F");

            entity.ToTable("Class");

            entity.Property(e => e.ClassName).HasMaxLength(50);
            entity.Property(e => e.Course).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B992C4500A6");

            entity.ToTable("Student");

            entity.HasIndex(e => e.Mssv, "UQ__Student__6CB3B7F80E82E8C7").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Mssv)
                .HasMaxLength(20)
                .HasColumnName("MSSV");
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.StudentCode).HasMaxLength(50);

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Student__ClassId__4CA06362");
        });

        modelBuilder.Entity<StudentScore>(entity =>
        {
            entity.HasKey(e => new { e.Mssv, e.Subject }).HasName("PK__StudentS__2698AA6920B4C889");

            entity.Property(e => e.Mssv)
                .HasMaxLength(20)
                .HasColumnName("MSSV");
            entity.Property(e => e.Subject).HasMaxLength(100);
            entity.Property(e => e.ExamScore).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.FinalScore).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.MidTermScore).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.MssvNavigation).WithMany(p => p.StudentScores)
                .HasPrincipalKey(p => p.Mssv)
                .HasForeignKey(d => d.Mssv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentSco__MSSV__5CD6CB2B");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__EDF25964675F0D63");

            entity.ToTable("Teacher");

            entity.HasIndex(e => e.Msgv, "UQ__Teacher__6CB35173DFA582FB").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Msgv)
                .HasMaxLength(20)
                .HasColumnName("MSGV");
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        modelBuilder.Entity<Timetable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Timetabl__3214EC07637ED7B8");

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
                .HasConstraintName("FK__Timetable__Class__59FA5E80");

            entity.HasOne(d => d.MsgvNavigation).WithMany(p => p.Timetables)
                .HasPrincipalKey(p => p.Msgv)
                .HasForeignKey(d => d.Msgv)
                .HasConstraintName("FK__Timetable__MSGV__59063A47");

            entity.HasOne(d => d.MssvNavigation).WithMany(p => p.Timetables)
                .HasPrincipalKey(p => p.Mssv)
                .HasForeignKey(d => d.Mssv)
                .HasConstraintName("FK__Timetable__MSSV__5812160E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
