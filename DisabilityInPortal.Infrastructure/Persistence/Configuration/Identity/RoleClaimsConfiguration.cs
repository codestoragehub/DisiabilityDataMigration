using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration.Identity;

public class RoleClaimsConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<string>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
    {
        builder.Property(u => u.ClaimType).HasMaxLength(256);
        builder.Property(u => u.ClaimValue).HasMaxLength(256);
    }
}