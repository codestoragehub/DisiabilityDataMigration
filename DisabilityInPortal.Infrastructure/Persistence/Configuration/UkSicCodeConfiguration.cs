using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration;

public class UkSicCodeConfiguration : IEntityTypeConfiguration<UkSicCode>
{
    public void Configure(EntityTypeBuilder<UkSicCode> builder)
    {
        builder.HasKey(n => n.Code);
        builder.HasIndex(u => u.Description);
    }
}