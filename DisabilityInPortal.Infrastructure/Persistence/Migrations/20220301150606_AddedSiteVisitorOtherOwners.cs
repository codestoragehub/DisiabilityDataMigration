using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddedSiteVisitorOtherOwners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteVisitInPerson",
                schema: "dbo",
                table: "SiteVisitReviews");

            migrationBuilder.DropColumn(
                name: "SiteVisitVirtual",
                schema: "dbo",
                table: "SiteVisitReviews");

            migrationBuilder.AddColumn<bool>(
                name: "IsSiteVisitInPersonOrVirtual",
                schema: "dbo",
                table: "SiteVisitReviews",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SiteVisitOtherOwners",
                schema: "dbo",
                columns: table => new
                {
                    SiteVisitOtherOwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    VotingPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyHistoryAndOwnershipId = table.Column<int>(type: "int", nullable: false),
                    SiteVisitReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteVisitOtherOwners", x => x.SiteVisitOtherOwnerId);
                    table.ForeignKey(
                        name: "FK_SiteVisitOtherOwners_CompanyHistoryAndOwnerships_CompanyHistoryAndOwnershipId",
                        column: x => x.CompanyHistoryAndOwnershipId,
                        principalSchema: "dbo",
                        principalTable: "CompanyHistoryAndOwnerships",
                        principalColumn: "CompanyHistoryAndOwnershipId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SiteVisitOtherOwners_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "dbo",
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SiteVisitOtherOwners_SiteVisitReviews_SiteVisitReviewId",
                        column: x => x.SiteVisitReviewId,
                        principalSchema: "dbo",
                        principalTable: "SiteVisitReviews",
                        principalColumn: "SiteVisitReviewId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiteVisitOtherOwners_CompanyHistoryAndOwnershipId",
                schema: "dbo",
                table: "SiteVisitOtherOwners",
                column: "CompanyHistoryAndOwnershipId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteVisitOtherOwners_OwnerId",
                schema: "dbo",
                table: "SiteVisitOtherOwners",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteVisitOtherOwners_SiteVisitReviewId",
                schema: "dbo",
                table: "SiteVisitOtherOwners",
                column: "SiteVisitReviewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteVisitOtherOwners",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "IsSiteVisitInPersonOrVirtual",
                schema: "dbo",
                table: "SiteVisitReviews");

            migrationBuilder.AddColumn<string>(
                name: "SiteVisitInPerson",
                schema: "dbo",
                table: "SiteVisitReviews",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteVisitVirtual",
                schema: "dbo",
                table: "SiteVisitReviews",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
