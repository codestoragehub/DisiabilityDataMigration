using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddedContributionOfCapitalAndExpertise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContributionOfCapitalAndExpertiseId",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContributionOfCapitalAndExpertises",
                schema: "dbo",
                columns: table => new
                {
                    ContributionOfCapitalAndExpertiseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceOfExpertise = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    YourContributionOfMoney = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    YourContributionOfEquipment = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    YourContributionOfRealEstate = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    YourContributionOfExperience = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    YourContributionOfOther = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    HasOtherIndividualsMadeContribution = table.Column<bool>(type: "bit", nullable: false),
                    OtherContributionOfMoney = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    OtherContributionOfEquipment = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    OtherContributionOfRealEstate = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    OtherContributionOfExperience = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    OtherContributionOfOther = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    HasAnyCurrentLoans = table.Column<bool>(type: "bit", nullable: false),
                    CircumstanceOfLoanTermsForRepayment = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SiteVisitorsComment = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributionOfCapitalAndExpertises", x => x.ContributionOfCapitalAndExpertiseId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiteVisitReviewDetails_ContributionOfCapitalAndExpertiseId",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                column: "ContributionOfCapitalAndExpertiseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteVisitReviewDetails_ContributionOfCapitalAndExpertises_ContributionOfCapitalAndExpertiseId",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                column: "ContributionOfCapitalAndExpertiseId",
                principalSchema: "dbo",
                principalTable: "ContributionOfCapitalAndExpertises",
                principalColumn: "ContributionOfCapitalAndExpertiseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteVisitReviewDetails_ContributionOfCapitalAndExpertises_ContributionOfCapitalAndExpertiseId",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropTable(
                name: "ContributionOfCapitalAndExpertises",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_SiteVisitReviewDetails_ContributionOfCapitalAndExpertiseId",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropColumn(
                name: "ContributionOfCapitalAndExpertiseId",
                schema: "dbo",
                table: "SiteVisitReviewDetails");
        }
    }
}
