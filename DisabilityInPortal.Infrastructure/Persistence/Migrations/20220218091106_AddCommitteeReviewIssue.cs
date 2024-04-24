using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddCommitteeReviewIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommitteeReviewIssues",
                schema: "dbo",
                columns: table => new
                {
                    CommitteeReviewIssueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Issue = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Resolution = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    SiteVisitReviewId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeReviewIssues", x => x.CommitteeReviewIssueId);
                    table.ForeignKey(
                        name: "FK_CommitteeReviewIssues_SiteVisitReviews_SiteVisitReviewId",
                        column: x => x.SiteVisitReviewId,
                        principalSchema: "dbo",
                        principalTable: "SiteVisitReviews",
                        principalColumn: "SiteVisitReviewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeReviewIssues_SiteVisitReviewId",
                schema: "dbo",
                table: "CommitteeReviewIssues",
                column: "SiteVisitReviewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommitteeReviewIssues",
                schema: "dbo");
        }
    }
}
