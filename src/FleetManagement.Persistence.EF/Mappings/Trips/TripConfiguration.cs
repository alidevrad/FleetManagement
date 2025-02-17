using FleetManagement.Domain.Models.Trips;
using FleetManagement.Domain.Models.Trips.Enums;
using FleetManagement.Persistence.EF.Common;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FleetManagement.Persistence.EF.Mappings.Trips;

public class TripConfiguration : AuditableAggregateRootConfiguration<Trip, long>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Trip> builder)
    {
        builder.ToTable(nameof(Trip).Pluralize());

        builder.Property(t => t.TripName)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(t => t.StartDateTime)
               .IsRequired()
               .HasColumnType("datetime2");

        builder.Property(t => t.EstimatedEndTime)
               .HasColumnType("datetime2");

        builder.Property(t => t.ActualEndTime)
               .HasColumnType("datetime2");

        builder.Property(t => t.Status)
               .IsRequired()
               .HasConversion(new EnumToNumberConverter<TripStatus, byte>());

        builder.Property(t => t.DriverId)
               .IsRequired();

        builder.Property(t => t.VehicleId)
               .IsRequired();

        builder.Property(t => t.TotalDelayTime)
               .IsRequired();

        builder.Property(t => t.TotalTripDuration)
               .IsRequired();

        builder.Property(t => t.TotalFuelConsumption)
               .IsRequired();

        builder.Property(t => t.Version)
               .IsRequired()
               .HasMaxLength(50);

        // Configure owned collection for SubTrips (entities)
        builder.OwnsMany(t => t.SubTrips, subTrip =>
        {
            subTrip.ToTable("SubTrips".Pluralize());

            subTrip.WithOwner().HasForeignKey("TripId");
            subTrip.HasKey(st => st.Id);

            subTrip.Property(st => st.Origin)
                   .IsRequired()
                   .HasMaxLength(250);

            subTrip.Property(st => st.RouteDetails)
                   .IsRequired(false);

            subTrip.Property(st => st.EstimatedDuration)
                   .IsRequired();

            subTrip.Property(st => st.EndTime)
                   .HasColumnType("datetime2");

            subTrip.Property(st => st.Status)
                   .IsRequired()
                   .HasConversion(new EnumToNumberConverter<SubTripStatus, byte>());

            subTrip.Property(st => st.FuelConsumption)
                   .IsRequired();

            subTrip.Property(st => st.DelayTimeValue)
                   .IsRequired();

            subTrip.UsePropertyAccessMode(PropertyAccessMode.Field);

            subTrip.OwnsOne(st => st.DeliveryPoint, map =>
            {
                map.Property(d => d.BranchId)
                     .IsRequired();

                map.Property(d => d.Order)
                      .IsRequired();

                map.Property(d => d.Address)
                  .IsRequired()
                  .HasMaxLength(250);

                map.Property(d => d.Latitude)
                  .IsRequired();

                map.Property(d => d.Longitude)
                  .IsRequired();
            });
        });
    }
}
