using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Contexts;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddAdditionalInformationsForEachApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @$"INSERT INTO {nameof(IDisabilityInPortalDbContext.AdditionalInformations)} 
                (
                    {nameof(AdditionalInformation.ApplicationId)}, 
                    {nameof(AdditionalInformation.IsInvolvedInLawsuit)}, 
                    {nameof(AdditionalInformation.IsInvolvedInBankruptcy)},
                    {nameof(AdditionalInformation.HasBeenDeniedCertification)},
                    {nameof(AdditionalInformation.RequiresAccommodationsDuringSiteVisit)},
                    {nameof(AdditionalInformation.LawsuitDocumentId)},
                    {nameof(AdditionalInformation.BankruptcyDocumentId)},
                    {nameof(AdditionalInformation.CertificationDenialDocumentId)},
                    {nameof(AdditionalInformation.SiteVisitAccomodationRequirementsDocumentId)}
                )
                SELECT {nameof(Application.ApplicationId)}, 
                    'false', 
                    'false',
                    'false',
                    'false',
                    null,
                    null,
                    null,
                    null
                FROM {nameof(IDisabilityInPortalDbContext.Applications)}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM {nameof(IDisabilityInPortalDbContext.AdditionalInformations)}");
        }
    }
}
