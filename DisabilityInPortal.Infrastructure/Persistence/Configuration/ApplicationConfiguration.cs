using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration;

public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.HasIndex(u => u.ApplicationReference);

        builder
            .Property(u => u.ApplicationReference)
            .HasMaxLength(14);

        builder
            .Property(u => u.ReferredBy)
            .HasMaxLength(100);
    }
}