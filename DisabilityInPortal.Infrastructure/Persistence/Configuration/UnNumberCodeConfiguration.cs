using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration;

public class UnNumberCodeConfiguration : IEntityTypeConfiguration<UnNumberCode>
{
    public void Configure(EntityTypeBuilder<UnNumberCode> builder)
    {
        builder.HasKey(u => u.Code);
        builder.HasIndex(u => u.Description);
    }
}