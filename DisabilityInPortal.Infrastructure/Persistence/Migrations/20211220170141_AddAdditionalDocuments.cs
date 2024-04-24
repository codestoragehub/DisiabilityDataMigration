using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddAdditionalDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalDocumentLists",
                schema: "dbo",
                columns: table => new
                {
                    AdditionalDocumentListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalDocumentLists", x => x.AdditionalDocumentListId);
                    table.ForeignKey(
                        name: "FK_AdditionalDocumentLists_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalDocuments",
                schema: "dbo",
                columns: table => new
                {
                    AdditionalDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    AdditionalDocumentListId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalDocuments", x => x.AdditionalDocumentId);
                    table.ForeignKey(
                        name: "FK_AdditionalDocuments_AdditionalDocumentLists_AdditionalDocumentListId",
                        column: x => x.AdditionalDocumentListId,
                        principalSchema: "dbo",
                        principalTable: "AdditionalDocumentLists",
                        principalColumn: "AdditionalDocumentListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalDocuments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalDocumentLists_ApplicationId",
                schema: "dbo",
                table: "AdditionalDocumentLists",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalDocuments_AdditionalDocumentListId",
                schema: "dbo",
                table: "AdditionalDocuments",
                column: "AdditionalDocumentListId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalDocuments_DocumentId",
                schema: "dbo",
                table: "AdditionalDocuments",
                column: "DocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalDocuments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AdditionalDocumentLists",
                schema: "dbo");
        }
    }
}
