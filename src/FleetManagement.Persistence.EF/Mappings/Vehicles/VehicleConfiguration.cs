using FleetManagement.Domain.Models.Vehicles;
using FleetManagement.Domain.Models.VehicleTypes;
using FleetManagement.Persistence.EF.Common;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetManagement.Persistence.EF.Mappings.Vehicles;

public class VehicleConfiguration : AuditableAggregateRootConfiguration<Vehicle, long>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable(nameof(Vehicle).Pluralize());

        builder.Property(v => v.Manufacturer)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(v => v.LicensePlateNumber)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(v => v.ModelYear)
               .IsRequired();

        builder.Property(v => v.Color)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(v => v.IsAvailable)
               .IsRequired();

        builder.HasOne<VehicleType>()
               .WithMany()
               .HasForeignKey(v => v.VehicleTypeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.OwnsMany(v => v.VehicleMaintenances, map =>
        {
            map.HasKey(v => v.Id);

            map.ToTable(nameof(VehicleMaintenance).Pluralize());

            map.Property(vm => vm.Reason)
              .IsRequired()
              .HasMaxLength(250);

            map.Property(vm => vm.RepairDate)
              .IsRequired();

            map.Property(vm => vm.RowVersion)
               .IsRowVersion();

            map.WithOwner()
               .HasForeignKey(vm => vm.VehicleId);

            map.UsePropertyAccessMode(PropertyAccessMode.Field);
        });

    }
}
