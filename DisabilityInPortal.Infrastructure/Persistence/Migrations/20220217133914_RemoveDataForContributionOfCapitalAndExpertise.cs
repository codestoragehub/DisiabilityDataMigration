using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Contexts;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class RemoveDataForContributionOfCapitalAndExpertise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"UPDATE {nameof(IDisabilityInPortalDbContext.SiteVisitReviews)} SET ContributionOfCapitalAndExpertiseId = null");
            migrationBuilder.Sql($"DELETE FROM {nameof(ContributionOfCapitalAndExpertise)}s");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
