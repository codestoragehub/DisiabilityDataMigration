using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration;

public class SicCodeConfiguration : IEntityTypeConfiguration<SicCode>
{
    public void Configure(EntityTypeBuilder<SicCode> builder)
    {
        builder.HasKey(s => s.Code);
        builder.HasIndex(u => u.Description);
    }
}