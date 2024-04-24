using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class UpdateSectionReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionReviews_Applications_AppicationId",
                schema: "dbo",
                table: "SectionReviews");

            migrationBuilder.RenameColumn(
                name: "AppicationId",
                schema: "dbo",
                table: "SectionReviews",
                newName: "ApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionReviews_AppicationId",
                schema: "dbo",
                table: "SectionReviews",
                newName: "IX_SectionReviews_ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionReviews_Applications_ApplicationId",
                schema: "dbo",
                table: "SectionReviews",
                column: "ApplicationId",
                principalSchema: "dbo",
                principalTable: "Applications",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionReviews_Applications_ApplicationId",
                schema: "dbo",
                table: "SectionReviews");

            migrationBuilder.RenameColumn(
                name: "ApplicationId",
                schema: "dbo",
                table: "SectionReviews",
                newName: "AppicationId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionReviews_ApplicationId",
                schema: "dbo",
                table: "SectionReviews",
                newName: "IX_SectionReviews_AppicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionReviews_Applications_AppicationId",
                schema: "dbo",
                table: "SectionReviews",
                column: "AppicationId",
                principalSchema: "dbo",
                principalTable: "Applications",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
