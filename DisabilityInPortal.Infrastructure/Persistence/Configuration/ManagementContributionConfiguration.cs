using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration;

public class ManagementContributionConfiguration : IEntityTypeConfiguration<ManagementContribution>
{
    public void Configure(EntityTypeBuilder<ManagementContribution> builder)
    {
        builder
            .HasOne(p => p.Owner)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
    }
}