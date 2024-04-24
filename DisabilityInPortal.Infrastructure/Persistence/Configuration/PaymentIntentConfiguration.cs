using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration;

public class PaymentIntentConfiguration : IEntityTypeConfiguration<PaymentIntent>
{
    public void Configure(EntityTypeBuilder<PaymentIntent> builder)
    {
        builder
            .HasOne(e => e.Invoice)
            .WithMany(i => i.PaymentIntents)
            .HasForeignKey(p => p.InvoiceId);
    }
}