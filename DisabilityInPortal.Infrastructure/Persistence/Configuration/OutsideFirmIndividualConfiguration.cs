using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration;

public class OutsideFirmIndividualConfiguration : IEntityTypeConfiguration<OutsideFirmIndividual>
{
    public void Configure(EntityTypeBuilder<OutsideFirmIndividual> builder)
    {
        builder
            .HasOne(p => p.Owner)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
    }
}