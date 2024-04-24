using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class MoveForeignKeyToChildTableForContributionOfCapitalAndExpertise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteVisitReviewDetails_ContributionOfCapitalAndExpertises_ContributionOfCapitalAndExpertiseId",
                schema: "dbo",
                table: "SiteVisitReviews");

            migrationBuilder.DropIndex(
                name: "IX_SiteVisitReviewDetails_ContributionOfCapitalAndExpertiseId",
                schema: "dbo",
                table: "SiteVisitReviews");

            migrationBuilder.DropColumn(
                name: "ContributionOfCapitalAndExpertiseId",
                schema: "dbo",
                table: "SiteVisitReviews");

            migrationBuilder.AddColumn<int>(
                name: "SiteVisitReviewId",
                schema: "dbo",
                table: "ContributionOfCapitalAndExpertises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ContributionOfCapitalAndExpertises_SiteVisitReviewId",
                schema: "dbo",
                table: "ContributionOfCapitalAndExpertises",
                column: "SiteVisitReviewId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContributionOfCapitalAndExpertises_SiteVisitReviews_SiteVisitReviewId",
                schema: "dbo",
                table: "ContributionOfCapitalAndExpertises",
                column: "SiteVisitReviewId",
                principalSchema: "dbo",
                principalTable: "SiteVisitReviews",
                principalColumn: "SiteVisitReviewId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContributionOfCapitalAndExpertises_SiteVisitReviews_SiteVisitReviewId",
                schema: "dbo",
                table: "ContributionOfCapitalAndExpertises");

            migrationBuilder.DropIndex(
                name: "IX_ContributionOfCapitalAndExpertises_SiteVisitReviewId",
                schema: "dbo",
                table: "ContributionOfCapitalAndExpertises");

            migrationBuilder.DropColumn(
                name: "SiteVisitReviewId",
                schema: "dbo",
                table: "ContributionOfCapitalAndExpertises");

            migrationBuilder.AddColumn<int>(
                name: "ContributionOfCapitalAndExpertiseId",
                schema: "dbo",
                table: "SiteVisitReviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SiteVisitReviewDetails_ContributionOfCapitalAndExpertiseId",
                schema: "dbo",
                table: "SiteVisitReviews",
                column: "ContributionOfCapitalAndExpertiseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteVisitReviewDetails_ContributionOfCapitalAndExpertises_ContributionOfCapitalAndExpertiseId",
                schema: "dbo",
                table: "SiteVisitReviews",
                column: "ContributionOfCapitalAndExpertiseId",
                principalSchema: "dbo",
                principalTable: "ContributionOfCapitalAndExpertises",
                principalColumn: "ContributionOfCapitalAndExpertiseId");
        }
    }
}
