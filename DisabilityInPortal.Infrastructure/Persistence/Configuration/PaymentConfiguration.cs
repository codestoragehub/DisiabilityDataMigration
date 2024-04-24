using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder
            .HasOne(p => p.Invoice)
            .WithOne(i => i.Payment);

        builder
            .HasOne(p => p.PaymentIntent)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
    }
}