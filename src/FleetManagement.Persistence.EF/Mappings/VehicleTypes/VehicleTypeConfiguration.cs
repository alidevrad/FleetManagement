using FleetManagement.Domain.Models.VehicleTypes;
using FleetManagement.Domain.Models.VehicleTypes.Enums;
using FleetManagement.Persistence.EF.Common;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FleetManagement.Persistence.EF.Mappings.VehicleTypes;

public class VehicleTypeConfiguration : AuditableAggregateRootConfiguration<VehicleType, long>
{
    protected override void ConfigureEntity(EntityTypeBuilder<VehicleType> builder)
    {
        builder.ToTable(nameof(VehicleType).Pluralize());

        builder.Property(vt => vt.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(vt => vt.Category)
               .IsRequired()
               .HasConversion(new EnumToNumberConverter<VehicleCategory, byte>());

        builder.Property(vt => vt.MaxWeightCapacity)
               .IsRequired()
               .HasPrecision(18, 2); // Ensures decimal precision

        builder.Property(vt => vt.MaxVolumeCapacity)
               .IsRequired()
               .HasPrecision(18, 2);

        builder.Property(vt => vt.FuelType)
               .IsRequired()
               .HasConversion(new EnumToNumberConverter<FuelType, byte>());

        builder.Property(vt => vt.AverageFuelConsumption)
               .IsRequired()
               .HasPrecision(10, 2);

        builder.Property(vt => vt.RequiredLicenseType)
               .IsRequired()
               .HasMaxLength(10);

        builder.Property(vt => vt.IsRefrigerated)
               .IsRequired();

        builder.Property(vt => vt.IsHazardousMaterialApproved)
               .IsRequired();

        builder.Property(vt => vt.MaxSpeedLimit)
               .IsRequired();

        builder.Property(vt => vt.NumberOfWheels)
               .IsRequired();
    }
}
