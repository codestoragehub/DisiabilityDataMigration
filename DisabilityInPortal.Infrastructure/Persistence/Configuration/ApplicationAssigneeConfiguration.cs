using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration;

public class ApplicationAssigneeConfiguration : IEntityTypeConfiguration<ApplicationAssignee>
{
    public void Configure(EntityTypeBuilder<ApplicationAssignee> builder)
    {
        builder
            .Property(a => a.UserId)
            .IsRequired();
    }
}