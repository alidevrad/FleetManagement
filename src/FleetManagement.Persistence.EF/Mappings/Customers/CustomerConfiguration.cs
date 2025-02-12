using FleetManagement.Domain.Models.Customers;
using FleetManagement.Persistence.EF.Common;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetManagement.Persistence.EF.Mappings.Customers;

public class CustomerConfiguration : AuditableAggregateRootConfiguration<Customer, long>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer).Pluralize());

        builder.Property(c => c.StoreName)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(c => c.StoreOwnerName)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(c => c.TaxNumber)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(c => c.Latitude)
               .IsRequired()
               .HasPrecision(9, 6);

        builder.Property(c => c.Longitude)
               .IsRequired()
               .HasPrecision(9, 6);

        builder.Property(c => c.Email)
            .IsRequired(false)
            .HasMaxLength(150);

        builder.OwnsMany(c => c.PhoneNumbers, pn =>
        {
            pn.ToTable("CustomerPhoneNumbers");

            pn.WithOwner().HasForeignKey("CustomerId");

            pn.Property(p => p.CountryCode)
              .IsRequired()
              .HasMaxLength(10);

            pn.Property(p => p.Number)
              .IsRequired()
              .HasMaxLength(20);

            pn.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(100);

            pn.HasKey("CustomerId", "Number");

        });

        builder.OwnsMany(c => c.Branches, b =>
        {
            b.ToTable(nameof(Branch).Pluralize());

            b.WithOwner().HasForeignKey(b => b.CustomerId);

            b.HasKey(b => b.Id);

            b.Property(b => b.Name)
              .IsRequired()
              .HasMaxLength(200);

            b.Property(b => b.Latitude)
              .IsRequired()
              .HasPrecision(9, 6);

            b.Property(b => b.Longitude)
              .IsRequired()
              .HasPrecision(9, 6);

            b.Property(b => b.Address)
              .IsRequired()
              .HasMaxLength(255);

            b.Property(b => b.AgentFullName)
              .IsRequired()
              .HasMaxLength(200);

            b.OwnsOne(b => b.AgentPhoneNumber, ap =>
            {
                ap.Property(p => p.CountryCode)
                  .HasColumnName("AgentPhoneNumberCountryCode")
                  .IsRequired()
                  .HasMaxLength(10);

                ap.Property(p => p.Number)
                  .HasColumnName("AgentPhoneNumber")
                  .IsRequired()
                  .HasMaxLength(20);

                ap.Property(p => p.Title)
                  .HasColumnName("AgentPhoneNumberTitle")
                  .IsRequired()
                  .HasMaxLength(100);
            });

            b.Navigation(b => b.AgentPhoneNumber)
             .IsRequired();

            b.Property(b => b.IsActive)
              .IsRequired();

            b.Property(b => b.RowVersion)
            .IsRowVersion();

            b.OwnsMany(b => b.PhoneNumbers, pb =>
            {
                pb.ToTable("BranchPhoneNumbers");

                pb.WithOwner().HasForeignKey("BranchId");

                pb.Property(p => p.CountryCode)
                  .IsRequired()
                  .HasMaxLength(10);

                pb.Property(p => p.Number)
                  .IsRequired()
                  .HasMaxLength(20);

                pb.Property(p => p.Title)
                  .IsRequired()
                  .HasMaxLength(100);

                pb.HasKey("BranchId", "Number");

            });
        });

        builder.Metadata
               .FindNavigation(nameof(Customer.Branches))
               .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
