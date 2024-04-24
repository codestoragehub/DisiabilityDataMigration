using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration
{
    public class TrustDetailConfiguration : IEntityTypeConfiguration<TrustDetail>
    {
        public void Configure(EntityTypeBuilder<TrustDetail> builder)
        {
            builder
                .HasOne(e => e.Document)
                .WithOne()
                .IsRequired(false);
        }
    }
}