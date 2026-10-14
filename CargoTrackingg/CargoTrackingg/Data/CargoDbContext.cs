using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CargoTrackingg.Models;
using Microsoft.AspNetCore.Identity;

namespace CargoTrackingg.Data
{
    public class CargoDbContext : IdentityDbContext<AppUser>
    {
        public CargoDbContext(DbContextOptions<CargoDbContext> options) : base(options)
        {
        }

        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<TrackingStatus> TrackingStatuses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<ShipmentStatusHistory> ShipmentStatusHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Rolleri ekleyelim
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "personel-role-id",
                    Name = "Personel",
                    NormalizedName = "PERSONEL"
                },
                new IdentityRole
                {
                    Id = "musteri-role-id",
                    Name = "Müşteri",
                    NormalizedName = "MÜŞTERİ"
                }
            ); // ← BU parantez eksikti

            // Shipment ile Branch arasında ilişki
            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.Branch)
                .WithMany()
                .HasForeignKey(s => s.BranchId)
                .OnDelete(DeleteBehavior.SetNull); // veya .Cascade, ihtiyacına göre
        }

    }
}
