using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Contexts;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddedOpearationAndControlForExistingSiteReviewVisit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @$"INSERT INTO {nameof(IDisabilityInPortalDbContext.OperationAndControls)} 
                (
                    {nameof(OperationAndControl.SiteVisitReviewId)},
                    {nameof(OperationAndControl.OwnerDutiesAndResponsibilities)},
                    {nameof(OperationAndControl.TimedevoteToBusiness)},
                    {nameof(OperationAndControl.HowDecisionsMadeWhenOwnerUnavailable)},
                    {nameof(OperationAndControl.WhoHasFinalWordOnDecision)},
                    {nameof(OperationAndControl.WhoSupervisesOperations)},
                    {nameof(OperationAndControl.WhoSupervisesFieldwork)},
                    {nameof(OperationAndControl.WhoMakesFinancialDecision)},
                    {nameof(OperationAndControl.WhoConductMarketingSales)},
                    {nameof(OperationAndControl.WhoResponsibleForSigningContracts)},
                    {nameof(OperationAndControl.WhoMakesApprovesPurchases)},
                    {nameof(OperationAndControl.WhoSelectsProjectsToBid)},
                    {nameof(OperationAndControl.WhoActuallyBiddingAndEstimating)},
                    {nameof(OperationAndControl.CompanyBiddingOrEstimatingProcedures)},
                    {nameof(OperationAndControl.WhoHasSignatureAuthority)},
                    {nameof(OperationAndControl.HowManySignaturesRequired)},
                    {nameof(OperationAndControl.IsWorkingForOtherCompany)},
                    {nameof(OperationAndControl.NameAndTypeOfOtherCompany)},
                    {nameof(OperationAndControl.TitleAndResponsibilityAtOtherCompany)},
                    {nameof(OperationAndControl.BusinessPlanForCompanyFuture)},
                    {nameof(OperationAndControl.OperationSectionComments)}
                )
                SELECT {nameof(SiteVisitReview.SiteVisitReviewId)}, 
                    null,
                    0,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    0,
                    'false',
                    null,
                    null,
                    null,
                    null
                FROM {nameof(IDisabilityInPortalDbContext.SiteVisitReviews)}");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM {nameof(IDisabilityInPortalDbContext.OperationAndControls)}");
        }
    }
}
