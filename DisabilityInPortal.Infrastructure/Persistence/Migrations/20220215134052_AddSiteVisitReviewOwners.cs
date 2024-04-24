using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddSiteVisitReviewOwners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteVisitReviewOwners",
                schema: "dbo",
                columns: table => new
                {
                    SiteVisitReviewOwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    SiteVisitReviewId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteVisitReviewOwners", x => x.SiteVisitReviewOwnerId);
                    table.ForeignKey(
                        name: "FK_SiteVisitReviewOwners_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "dbo",
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiteVisitReviewOwners_SiteVisitReviewDetails_SiteVisitReviewId",
                        column: x => x.SiteVisitReviewId,
                        principalSchema: "dbo",
                        principalTable: "SiteVisitReviewDetails",
                        principalColumn: "SiteVisitReviewId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiteVisitReviewOwners_OwnerId",
                schema: "dbo",
                table: "SiteVisitReviewOwners",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SiteVisitReviewOwners_SiteVisitReviewId_OwnerId",
                schema: "dbo",
                table: "SiteVisitReviewOwners",
                columns: new[] { "SiteVisitReviewId", "OwnerId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteVisitReviewOwners",
                schema: "dbo");
        }
    }
}
