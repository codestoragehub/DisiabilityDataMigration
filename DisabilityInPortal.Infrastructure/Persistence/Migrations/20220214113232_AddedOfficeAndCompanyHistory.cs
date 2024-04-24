using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddedOfficeAndCompanyHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SiteVisitInPerson",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteVisitVirtual",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompanyHistoryAndOwnerships",
                schema: "dbo",
                columns: table => new
                {
                    CompanyHistoryAndOwnershipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyTotalYears = table.Column<int>(type: "int", nullable: false),
                    BussinessStatus = table.Column<int>(type: "int", nullable: false),
                    CompanyPreviousName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyOwnershipAcquiredYear = table.Column<int>(type: "int", nullable: false),
                    WhyStartOrBoughtCompany = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OwnerCompanyOwnershipPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OwnerVotingStockPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MajorityOwnerStatus = table.Column<int>(type: "int", nullable: false),
                    BecomeMajorityOwnerOther = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    HistoryOwnershipSectionComments = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SiteVisitReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyHistoryAndOwnerships", x => x.CompanyHistoryAndOwnershipId);
                    table.ForeignKey(
                        name: "FK_CompanyHistoryAndOwnerships_SiteVisitReviewDetails_SiteVisitReviewId",
                        column: x => x.SiteVisitReviewId,
                        principalSchema: "dbo",
                        principalTable: "SiteVisitReviewDetails",
                        principalColumn: "SiteVisitReviewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                schema: "dbo",
                columns: table => new
                {
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsFirmNamePubliclyDisplayed = table.Column<bool>(type: "bit", nullable: false),
                    OfficeSpaceType = table.Column<int>(type: "int", nullable: false),
                    OfficeSpaceTypeOther = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ApplicantOfficeLocation = table.Column<int>(type: "int", nullable: false),
                    HasApplicantSharedSpace = table.Column<bool>(type: "bit", nullable: false),
                    OtherSharingSpaceFirmName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PrimaryBusinessOfOtherFirms = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SiteVisitReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.OfficeId);
                    table.ForeignKey(
                        name: "FK_Offices_SiteVisitReviewDetails_SiteVisitReviewId",
                        column: x => x.SiteVisitReviewId,
                        principalSchema: "dbo",
                        principalTable: "SiteVisitReviewDetails",
                        principalColumn: "SiteVisitReviewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyHistoryAndOwnerships_SiteVisitReviewId",
                schema: "dbo",
                table: "CompanyHistoryAndOwnerships",
                column: "SiteVisitReviewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offices_SiteVisitReviewId",
                schema: "dbo",
                table: "Offices",
                column: "SiteVisitReviewId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyHistoryAndOwnerships",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Offices",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "SiteVisitInPerson",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropColumn(
                name: "SiteVisitVirtual",
                schema: "dbo",
                table: "SiteVisitReviewDetails");
        }
    }
}
