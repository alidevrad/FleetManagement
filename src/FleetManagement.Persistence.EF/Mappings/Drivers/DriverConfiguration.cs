﻿using FleetManagement.Domain.Models.Drivers;
using FleetManagement.Domain.Models.Drivers.Enums;
using FleetManagement.Persistence.EF.Common;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FleetManagement.Persistence.EF.Mappings.Drivers;

public class DriverConfiguration : AuditableAggregateRootConfiguration<Driver, long>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Driver> builder)
    {
        builder.ToTable(nameof(Driver).Pluralize());

        builder.Property(d => d.FirstName)
              .IsRequired()
              .HasMaxLength(100);

        builder.Property(d => d.LastName)
              .IsRequired()
              .HasMaxLength(100);

        builder.Property(d => d.Gender)
               .IsRequired()
               .HasConversion(new EnumToNumberConverter<Gender, byte>());

        builder.OwnsOne(b => b.PhoneNumber, ap =>
        {
            ap.Property(p => p.CountryCode)
              .HasColumnName("DriverPhoneNumberCountryCode")
              .IsRequired(true)
              .HasMaxLength(10);

            ap.Property(p => p.Number)
              .HasColumnName("DriverPhoneNumber")
              .IsRequired(true)
              .HasMaxLength(20);

            ap.Property(p => p.Title)
              .HasColumnName("DriverPhoneNumberTitle")
              .IsRequired(true)
              .HasMaxLength(100);
        });

        builder.Navigation(d => d.PhoneNumber)
            .IsRequired();

        builder.Property(d => d.Address)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(d => d.NativeLanguage)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.DateOfBirth)
               .IsRequired();

        builder.Property(d => d.LicenseType)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(d => d.LicenseIssueDate)
               .IsRequired();

        builder.Property(d => d.LicenseExpirationDate)
               .IsRequired();

        builder.Property(d => d.IsActive)
               .IsRequired();

        builder.Property(v => v.ImageUrl)
               .HasMaxLength(500)
               .IsRequired(false);

        // Configure Owned Entity - Emergency Contacts
        builder.OwnsMany(d => d.EmergencyContacts, contact =>
        {
            contact.ToTable(nameof(EmergencyContact).Pluralize());

            contact.WithOwner().HasForeignKey("DriverId");

            contact.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            contact.Property(c => c.Relationship)
                .IsRequired()
                .HasMaxLength(50);

            contact.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            contact.UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        // Configure Owned Entity - Training Qualifications
        builder.OwnsMany(d => d.TrainingQualifications, training =>
        {
            training.ToTable(nameof(TrainingQualification).Pluralize());

            training.WithOwner().HasForeignKey("DriverId");

            training.Property(t => t.QualificationName)
                .IsRequired()
                .HasMaxLength(150);

            training.Property(t => t.ObtainedDate)
                .HasColumnType("datetime2");

            training.Property(t => t.ExpirationDate)
                .HasColumnType("datetime2");

            training.UsePropertyAccessMode(PropertyAccessMode.Field);
        });


        // Configure Owned Entity - Reservations
        //builder.OwnsMany(d => d.ReservationPeriods, reservation =>
        //{
        //    reservation.ToTable("DriverReservationPeriods");

        //    reservation.WithOwner().HasForeignKey("DriverId");

        //    reservation.Property(r => r.Start)
        //        .IsRequired()
        //        .HasColumnType("datetime2");

        //    reservation.Property(r => r.End)
        //        .IsRequired()
        //        .HasColumnType("datetime2");

        //    reservation.Property(r => r.Status)
        //        .IsRequired()
        //        .HasConversion(new EnumToNumberConverter<ReservationStatus, byte>());

        //    reservation.Property(r => r.ActivatedAt)
        //        .HasColumnType("datetime2");

        //    reservation.Property(r => r.CanceledAt)
        //        .HasColumnType("datetime2");

        //    reservation.Property(r => r.FinishedAt)
        //        .HasColumnType("datetime2");

        //    reservation.UsePropertyAccessMode(PropertyAccessMode.Field);
        //});
    }
}
