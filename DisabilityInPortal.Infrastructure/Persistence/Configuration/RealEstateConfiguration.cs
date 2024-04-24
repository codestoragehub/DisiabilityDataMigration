using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration
{
    public class RealEstateConfiguration : IEntityTypeConfiguration<RealEstate>
    {
        public void Configure(EntityTypeBuilder<RealEstate> builder)
        {
            builder
                .HasMany(r => r.Facilities)
                .WithOne(f => f.RealEstate)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}