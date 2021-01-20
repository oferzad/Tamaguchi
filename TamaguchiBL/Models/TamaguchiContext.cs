using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TamaguchiBL.Models
{
    public partial class TamaguchiContext : DbContext
    {
        public TamaguchiContext()
        {
        }

        public TamaguchiContext(DbContextOptions<TamaguchiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActivityCategory> ActivityCategory { get; set; }
        public virtual DbSet<ActivityType> ActivityType { get; set; }
        public virtual DbSet<HealthStatus> HealthStatus { get; set; }
        public virtual DbSet<LifeCycleStatus> LifeCycleStatus { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<PlayerAnimals> PlayerAnimals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasKey(e => new { e.AnimalId, e.ActivityDate });

                entity.Property(e => e.ActivityDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ActivityType)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.ActivityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Activity__Activi__38996AB5");

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Activity__Animal__36B12243");

                entity.HasOne(d => d.HealthStatus)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.HealthStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Activity__Health__46E78A0C");

                entity.HasOne(d => d.Lcstatus)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.LcstatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Activity__LCStat__45F365D3");
            });

            modelBuilder.Entity<ActivityCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Activity__19093A2B0441BCDE");
            });

            modelBuilder.Entity<ActivityType>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ActivityType)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__ActivityT__Categ__5070F446");
            });

            modelBuilder.Entity<HealthStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__HealthSt__C8EE204396A67FC0");
            });

            modelBuilder.Entity<LifeCycleStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__LifeCycl__C8EE20433E186672");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasIndex(e => e.ActiveAnimal)
                    .HasDatabaseName("UQ__Player__9705BE275E535CAC")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasDatabaseName("UQ__Player__A9D10534D0A881B8")
                    .IsUnique();

                entity.HasOne(d => d.ActiveAnimalNavigation)
                    .WithOne(p => p.Player)
                    .HasForeignKey<Player>(d => d.ActiveAnimal)
                    .HasConstraintName("FK__Player__ActiveAn__44FF419A");
            });

            modelBuilder.Entity<PlayerAnimals>(entity =>
            {
                entity.HasKey(e => e.AnimalId)
                    .HasName("PK__PlayerAn__A21A7327B4E0DCBA");

                entity.Property(e => e.BirthDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LcstatusDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.HealthStatus)
                    .WithMany(p => p.PlayerAnimals)
                    .HasForeignKey(d => d.HealthStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerAni__Healt__33D4B598");

                entity.HasOne(d => d.Lcstatus)
                    .WithMany(p => p.PlayerAnimals)
                    .HasForeignKey(d => d.LcstatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerAni__LCSta__31EC6D26");

                entity.HasOne(d => d.PlayerNavigation)
                    .WithMany(p => p.PlayerAnimals)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerAni__Playe__300424B4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
