using DisabilityInPortal.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration.Identity;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasIndex(u => u.UserReference);

        builder
            .Property(u => u.UserReference)
            .HasMaxLength(14);

        builder
            .Property(u => u.FirstName)
            .HasMaxLength(128);

        builder
            .Property(u => u.LastName)
            .HasMaxLength(128);

        builder.Property(u => u.ConcurrencyStamp).HasMaxLength(256);
        builder.Property(u => u.PasswordHash).HasMaxLength(1024);
        builder.Property(u => u.PhoneNumber).HasMaxLength(256);
        builder.Property(u => u.SecurityStamp).HasMaxLength(256);

        builder
            .HasMany(u => u.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
    }
}