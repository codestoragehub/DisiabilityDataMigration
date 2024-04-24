using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration;

public class NaicsCodeConfiguration : IEntityTypeConfiguration<NaicsCode>
{
    public void Configure(EntityTypeBuilder<NaicsCode> builder)
    {
        builder.HasKey(n => n.Code);
        builder.HasIndex(u => u.Description);
    }
}