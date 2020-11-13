using System;
using LayerArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace LayerArchitecture.DataLayer.EFContext
{
    public partial class CarDBV2Context : DbContext
    {
        public CarDBV2Context()
        {
        }

        public CarDBV2Context(DbContextOptions<CarDBV2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Train> Train { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=SURFACE-KW4;Initial Catalog=CarDBV2;Trusted_Connection=True;MultipleActiveResultSets=true");



                //optionBuilder.UseSqlServer(Configuration.GetConnectionString("MyConnection"));
                //Der Connection String kann auch in einer AppSetting ausgelagert werden. Ist die bessere Variante
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsCaprio)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.MitRadio)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<Train>(entity =>
            {
                entity.Property(e => e.Kmh).HasColumnName("KMH");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
