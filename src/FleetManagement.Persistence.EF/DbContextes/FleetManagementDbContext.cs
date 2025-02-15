using FleetManagement.Domain.Models.Drivers;
using FleetManagement.Domain.Models.Resources;
using FleetManagement.Domain.Models.Vehicles;
using FleetManagement.Domain.Models.VehicleTypes;
using FleetManagement.Domain.Models.Warehouses;
using FleetManagement.Persistence.EF.Mappings.Warehouses;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.Persistence.EF.DbContextes;

public class FleetManagementDbContext : DbContext
{
    public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;
    public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;
    public virtual DbSet<Driver> Drivers { get; set; } = null!;
    public virtual DbSet<Resource> Reservations { get; set; }
    public virtual DbSet<VehicleType> VehicleTypes { get; set; } = null!;

    public FleetManagementDbContext(DbContextOptions options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("Fleet");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WarehouseConfiguration).Assembly);
    }
}
