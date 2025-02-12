using FleetManagement.Domain.Models.Warehouses;
using FleetManagement.Persistence.EF.Common;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetManagement.Persistence.EF.Mappings.Warehouses;

public class WarehouseConfiguration : AuditableAggregateRootConfiguration<Warehouse, long>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Warehouse> builder)
    {
        builder.ToTable(nameof(Warehouse).Pluralize());

        builder.Property(w => w.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(w => w.Street)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(w => w.City)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(w => w.State)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(w => w.PostalCode)
               .IsRequired()
               .HasMaxLength(20);

        builder.Property(w => w.Country)
               .IsRequired()
               .HasMaxLength(100);

        builder.OwnsOne(w => w.PhoneNumber, map =>
        {
            map.Property(p => p.CountryCode)
              .HasColumnName("PhoneNumberCountryCode")
              .IsRequired(true)
              .HasMaxLength(10);

            map.Property(p => p.Number)
              .HasColumnName("PhoneNumber")
              .IsRequired(true)
              .HasMaxLength(20);

            map.Property(p => p.Title)
              .HasColumnName("PhoneNumberTitle")
              .IsRequired(true)
              .HasMaxLength(100);
        });

        builder.Navigation(w => w.PhoneNumber)
            .IsRequired();

        builder.Property(w => w.Email)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(w => w.Latitude)
               .IsRequired()
               .HasPrecision(9, 6);

        builder.Property(w => w.Longitude)
               .IsRequired()
               .HasPrecision(9, 6);
    }
}
