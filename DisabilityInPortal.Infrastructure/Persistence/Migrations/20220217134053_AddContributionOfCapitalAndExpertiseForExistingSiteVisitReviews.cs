using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Contexts;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddContributionOfCapitalAndExpertiseForExistingSiteVisitReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @$"INSERT INTO {nameof(ContributionOfCapitalAndExpertise)}s 
                (
                    {nameof(ContributionOfCapitalAndExpertise.SiteVisitReviewId)},
                    {nameof(ContributionOfCapitalAndExpertise.HasAnyCurrentLoans)},
                    {nameof(ContributionOfCapitalAndExpertise.HasOtherIndividualsMadeContribution)}
                )
                SELECT {nameof(SiteVisitReview.SiteVisitReviewId)}, 'false', 'false'                     
                FROM {nameof(IDisabilityInPortalDbContext.SiteVisitReviews)}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM {nameof(ContributionOfCapitalAndExpertise)}s");
        }
    }
}
