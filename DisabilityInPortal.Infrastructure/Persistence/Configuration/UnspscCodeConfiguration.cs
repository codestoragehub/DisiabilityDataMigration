using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration;

public class UnspscCodeConfiguration : IEntityTypeConfiguration<UnspscCode>
{
    public void Configure(EntityTypeBuilder<UnspscCode> builder)
    {
        builder.HasKey(u => u.Code);
        builder.HasIndex(u => u.Description);
    }
}