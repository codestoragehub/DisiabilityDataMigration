using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration;

public class SiteVisitReviewOwnerConfiguration : IEntityTypeConfiguration<SiteVisitReviewOwner>
{
    public void Configure(EntityTypeBuilder<SiteVisitReviewOwner> builder)
    {
        builder.HasIndex(s => new { s.SiteVisitReviewId, s.OwnerId });

        builder
            .HasOne(s => s.SiteVisitReview)
            .WithMany(a => a.SiteVisitReviewOwners)
            .HasForeignKey(s => s.SiteVisitReviewId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(s => s.Owner)
            .WithOne();
    }
}