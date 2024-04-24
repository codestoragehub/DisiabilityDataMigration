using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisabilityInPortal.Infrastructure.Persistence.Configuration
{
    public class ApplicationCertificationAgencyConfiguration : IEntityTypeConfiguration<ApplicationCertificationAgency>
    {
        public void Configure(EntityTypeBuilder<ApplicationCertificationAgency> builder)
        {
            builder.HasIndex(aca => new { aca.ApplicationId, aca.CertificationAgencyId });
            
            builder
                .HasOne(aca => aca.Application)
                .WithMany(a => a.ApplicationCertificationAgencies)
                .HasForeignKey(aca => aca.ApplicationId);

            builder
                .HasOne(aca => aca.CertificationAgency)
                .WithMany(ca => ca.ApplicationCertificationAgencies)
                .HasForeignKey(aca => aca.CertificationAgencyId);

            builder
                .HasOne(aca => aca.Document)
                .WithOne()
                .IsRequired(false);
        }
    }
}