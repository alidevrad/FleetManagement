using FleetManagement.Domain.Models.Resources;
using FleetManagement.Persistence.EF.Common;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetManagement.Persistence.EF.Mappings.Resources;

public class ResourceConfiguration : AuditableAggregateRootConfiguration<Resource, long>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Resource> builder)
    {
        builder.ToTable(nameof(Resource).Pluralize());

        builder.Property(r => r.ResourceId)
               .IsRequired();

        builder.Property(r => r.ResourceType)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(r => r.StartDateTime)
               .IsRequired()
               .HasColumnType("datetime2");

        builder.Property(r => r.EndDateTime)
               .IsRequired()
               .HasColumnType("datetime2");

        builder.Property(r => r.IsLocked)
               .IsRequired();

        builder.HasIndex(r => new { r.ResourceId, r.ResourceType, r.StartDateTime, r.EndDateTime })
               .IsUnique()
               .HasDatabaseName("IX_Resource_Lock"); // Ensuring no duplicate locks for overlapping times
    }
}
