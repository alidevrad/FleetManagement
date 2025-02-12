using FleetManagement.Domain.Common.BuildingBlocks.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetManagement.Persistence.EF.Common;

public abstract class AuditableAggregateRootConfiguration<T, TKey> :
    IEntityTypeConfiguration<T>
    where T : AuditableAggregateRoot<TKey>
    where TKey : IEquatable<TKey>
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(e => e.RowVersion)
               .IsRowVersion();

        builder.Property(e => e.CreationDateTime)
               .IsRequired();

        builder.Property(e => e.LastUpdateDateTime)
               .IsRequired(false);

        builder.Property(e => e.DeleteDateTime)
               .IsRequired(false);

        builder.Property(e => e.IsDeleted)
               .IsRequired(false);

        builder.Property(e => e.BusinessId)
               .IsRequired();

        ConfigureEntity(builder);
    }

    protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
}
