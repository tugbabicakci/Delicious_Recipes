using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Delicious_Recipes.Dal.Models
{
    public partial class Delicious_RecipeContext : DbContext
    {
        public Delicious_RecipeContext()
        {
        }

        public Delicious_RecipeContext(DbContextOptions<Delicious_RecipeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Birim> Birim { get; set; }
        public virtual DbSet<Kategoriler> Kategoriler { get; set; }
        public virtual DbSet<Malzemeler> Malzemeler { get; set; }
        public virtual DbSet<Miktar> Miktar { get; set; }
        public virtual DbSet<Tarifler> Tarifler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("data source=TBICAKCIW10;initial catalog=Delicious_Recipe;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Birim>(entity =>
            {
                entity.Property(e => e.Adi).HasMaxLength(50);
            });

            modelBuilder.Entity<Kategoriler>(entity =>
            {
                entity.Property(e => e.Adi).HasMaxLength(50);

                entity.HasOne(d => d.Tarif)
                    .WithMany(p => p.Kategoriler)
                    .HasForeignKey(d => d.TarifId)
                    .HasConstraintName("FK_Kategoriler_Tarifler");
            });

            modelBuilder.Entity<Malzemeler>(entity =>
            {
                entity.HasOne(d => d.Miktar)
                    .WithMany(p => p.Malzemeler)
                    .HasForeignKey(d => d.MiktarId)
                    .HasConstraintName("FK_Malzemeler_Miktar");

                entity.HasOne(d => d.Tarif)
                    .WithMany(p => p.Malzemeler)
                    .HasForeignKey(d => d.TarifId)
                    .HasConstraintName("FK_Malzemeler_Tarifler");
            });

            modelBuilder.Entity<Miktar>(entity =>
            {
                entity.Property(e => e.Adet).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Birim)
                    .WithMany(p => p.Miktar)
                    .HasForeignKey(d => d.BirimId)
                    .HasConstraintName("FK_Miktar_Birim");
            });
        }
    }
}
