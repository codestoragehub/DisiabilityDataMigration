using DisabilityInPortal.Domain.Constants;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration;

public class CertificationAgencyConfiguration : IEntityTypeConfiguration<CertificationAgency>
{
    public void Configure(EntityTypeBuilder<CertificationAgency> builder)
    {
        builder.HasData(CertificationAgencies.Data);
    }
}