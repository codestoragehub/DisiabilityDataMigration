using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration;

public class ManagementResponsibilityOwnerConfiguration : IEntityTypeConfiguration<ManagementResponsibilityOwner>
{
    public void Configure(EntityTypeBuilder<ManagementResponsibilityOwner> builder)
    {
        builder
            .HasOne(p => p.Owner)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
    }
}