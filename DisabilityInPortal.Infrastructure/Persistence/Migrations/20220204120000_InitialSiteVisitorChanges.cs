using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class InitialSiteVisitorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteVisitReviewDetails",
                schema: "dbo",
                columns: table => new
                {
                    SiteVisitReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteVisitDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    SiteVisitorFirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SiteVisitorLastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AdditionalSiteVisitorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ApplicantCompanyVisited = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Recommendation = table.Column<int>(type: "int", nullable: false),
                    RecommendationReasons = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsOwnershipReview = table.Column<bool>(type: "bit", nullable: false),
                    IsCapitalExpertiseReview = table.Column<bool>(type: "bit", nullable: false),
                    IsOperationAndControlReview = table.Column<bool>(type: "bit", nullable: false),
                    IsEmployeesCompensationReview = table.Column<bool>(type: "bit", nullable: false),
                    IsOtherSectionReview = table.Column<bool>(type: "bit", nullable: false),
                    OtherReviewSectionName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PwdCanNotDemonstrateInvestment = table.Column<bool>(type: "bit", nullable: false),
                    PwdCapitalContributionNotCommensurate = table.Column<bool>(type: "bit", nullable: false),
                    PwdExpertiseContributionNotCommensurate = table.Column<bool>(type: "bit", nullable: false),
                    PwdNotControlDailyOperations = table.Column<bool>(type: "bit", nullable: false),
                    PwdOperatesWithOtherIndividuals = table.Column<bool>(type: "bit", nullable: false),
                    PwdMaintainsJobElseWhere = table.Column<bool>(type: "bit", nullable: false),
                    PwdMaintainsNotOwnedFirm = table.Column<bool>(type: "bit", nullable: false),
                    FirmNotOwnedByPwd = table.Column<bool>(type: "bit", nullable: false),
                    IsEquityOwnership = table.Column<bool>(type: "bit", nullable: false),
                    IsManagement = table.Column<bool>(type: "bit", nullable: false),
                    IsInterFirmTransactions = table.Column<bool>(type: "bit", nullable: false),
                    IsOfficeOrFacilitiesSharing = table.Column<bool>(type: "bit", nullable: false),
                    HasCommonEmployeesUse = table.Column<bool>(type: "bit", nullable: false),
                    PwdNotHaveTechnicalExpertise = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteVisitReviewDetails", x => x.SiteVisitReviewId);
                    table.ForeignKey(
                        name: "FK_SiteVisitReviewDetails_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiteVisitReviewDetails_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiteVisitReviewDetails_ApplicationId",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteVisitReviewDetails_UserId",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteVisitReviewDetails",
                schema: "dbo");
        }
    }
}
