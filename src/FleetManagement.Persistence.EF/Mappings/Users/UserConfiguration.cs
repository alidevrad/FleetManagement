using FleetManagement.Domain.Models.Users;
using FleetManagement.Persistence.EF.Common;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetManagement.Persistence.EF.Mappings.Users;

public class UserConfiguration : AuditableAggregateRootConfiguration<User, long>
{
    protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User).Pluralize());

        builder.Property(u => u.UserName)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasIndex(u => u.UserName)
               .IsUnique();

        builder.Property(u => u.FirstName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.LastName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(250);

        builder.Property(u => u.PasswordHash)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(u => u.PasswordSalt)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(u => u.RegisterDate)
               .IsRequired()
               .HasColumnType("datetime2");

        builder.Property(u => u.LastLoginDate)
               .HasColumnType("datetime2");

        builder.Property(u => u.IsActive)
               .IsRequired();
    }
}
