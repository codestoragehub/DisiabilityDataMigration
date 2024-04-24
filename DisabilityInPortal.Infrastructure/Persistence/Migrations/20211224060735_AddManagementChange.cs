using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddManagementChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManagementChanges",
                schema: "dbo",
                columns: table => new
                {
                    ManagementChangeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasOrIntendToEnterIntoAnyTypeOfAgreement = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementChanges", x => x.ManagementChangeId);
                    table.ForeignKey(
                        name: "FK_ManagementChanges_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagementChangeAgreements",
                schema: "dbo",
                columns: table => new
                {
                    ManagementChangeAgreementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    Explanation = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ManagementChangeId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementChangeAgreements", x => x.ManagementChangeAgreementId);
                    table.ForeignKey(
                        name: "FK_ManagementChangeAgreements_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                    table.ForeignKey(
                        name: "FK_ManagementChangeAgreements_ManagementChanges_ManagementChangeId",
                        column: x => x.ManagementChangeId,
                        principalSchema: "dbo",
                        principalTable: "ManagementChanges",
                        principalColumn: "ManagementChangeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManagementChangeAgreements_DocumentId",
                schema: "dbo",
                table: "ManagementChangeAgreements",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementChangeAgreements_ManagementChangeId",
                schema: "dbo",
                table: "ManagementChangeAgreements",
                column: "ManagementChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementChanges_ApplicationId",
                schema: "dbo",
                table: "ManagementChanges",
                column: "ApplicationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManagementChangeAgreements",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ManagementChanges",
                schema: "dbo");
        }
    }
}
