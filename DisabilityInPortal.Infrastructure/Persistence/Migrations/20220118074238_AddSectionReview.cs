using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddSectionReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SectionReviews",
                schema: "dbo",
                columns: table => new
                {
                    SectionReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sectiontype = table.Column<int>(type: "int", nullable: false),
                    DoesSectionPass = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AppicationId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionReviews", x => x.SectionReviewId);
                    table.ForeignKey(
                        name: "FK_SectionReviews_Applications_AppicationId",
                        column: x => x.AppicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionReviews_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SectionReviews_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectionReviews_AppicationId",
                schema: "dbo",
                table: "SectionReviews",
                column: "AppicationId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionReviews_RoleId",
                schema: "dbo",
                table: "SectionReviews",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionReviews_UserId",
                schema: "dbo",
                table: "SectionReviews",
                column: "UserId");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectionReviews",
                schema: "dbo");
        }
    }
}
