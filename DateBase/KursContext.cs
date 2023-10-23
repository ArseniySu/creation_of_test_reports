using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kurs.DateBase;

public partial class KursContext : DbContext
{
    public KursContext()
    {
    }

    public KursContext(DbContextOptions<KursContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Gruppa> Gruppas { get; set; }

    public virtual DbSet<PassingTest> PassingTests { get; set; }

    public virtual DbSet<ScopeApplication> ScopeApplications { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Kurs;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Gender__3213E83F49350C8E");

            entity.ToTable("Gender");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Gruppa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Gruppa__3213E83FE6DCCF40");

            entity.ToTable("Gruppa");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<PassingTest>(entity =>
        {
            entity.HasKey(e => new { e.UsersId, e.TestsId }).HasName("PK__PassingT__09693706C03DB55B");

            entity.ToTable("PassingTest");

            entity.Property(e => e.UsersId).HasColumnName("UsersID");
            entity.Property(e => e.TestsId).HasColumnName("TestsID");
            entity.Property(e => e.DatePasses).HasColumnType("date");
            entity.Property(e => e.UserResponse).HasMaxLength(100);

            entity.HasOne(d => d.Tests).WithMany(p => p.PassingTests)
                .HasForeignKey(d => d.TestsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PassingTe__Tests__619B8048");

            entity.HasOne(d => d.Users).WithMany(p => p.PassingTests)
                .HasForeignKey(d => d.UsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PassingTe__Users__60A75C0F");
        });

        modelBuilder.Entity<ScopeApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ScopeApp__3213E83F4DC56C22");

            entity.ToTable("ScopeApplication");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tests__3213E83F64173DB9");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Question).HasMaxLength(1000);
            entity.Property(e => e.RightAnswer).HasMaxLength(100);
            entity.Property(e => e.ScopeApplicationId).HasColumnName("ScopeApplicationID");
            entity.Property(e => e.UserCreateId).HasColumnName("UserCreateID");

            entity.HasOne(d => d.ScopeApplication).WithMany(p => p.Tests)
                .HasForeignKey(d => d.ScopeApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tests__ScopeAppl__5DCAEF64");

            entity.HasOne(d => d.UserCreate).WithMany(p => p.Tests)
                .HasForeignKey(d => d.UserCreateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tests__UserCreat__5CD6CB2B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F45DD66F1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateBirth).HasColumnType("date");
            entity.Property(e => e.Fname)
                .HasMaxLength(100)
                .HasColumnName("FName");
            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.GruppaId).HasColumnName("GruppaID");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Mname)
                .HasMaxLength(100)
                .HasColumnName("MName");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sname)
                .HasMaxLength(100)
                .HasColumnName("SName");

            entity.HasOne(d => d.Gender).WithMany(p => p.Users)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__GenderID__5812160E");

            entity.HasOne(d => d.Gruppa).WithMany(p => p.Users)
                .HasForeignKey(d => d.GruppaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__GruppaID__571DF1D5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
