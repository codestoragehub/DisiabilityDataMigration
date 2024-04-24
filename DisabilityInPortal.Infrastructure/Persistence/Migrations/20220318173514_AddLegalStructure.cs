using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddLegalStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LegalStructureType",
                schema: "dbo",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LegalStructureTypeOther",
                schema: "dbo",
                table: "Companies");

            migrationBuilder.CreateTable(
                name: "LegalStructures",
                schema: "dbo",
                columns: table => new
                {
                    LegalStructureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegalStructureType = table.Column<int>(type: "int", nullable: false),
                    LegalStructureTypeOther = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalStructures", x => x.LegalStructureId);
                    table.ForeignKey(
                        name: "FK_LegalStructures_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegalStructures_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                });

            migrationBuilder.CreateTable(
                name: "LegalStructureDocuments",
                schema: "dbo",
                columns: table => new
                {
                    LegalStructureDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LegalStructureDocumentTypeValue = table.Column<int>(type: "int", nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    LegalStructureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalStructureDocuments", x => x.LegalStructureDocumentId);
                    table.ForeignKey(
                        name: "FK_LegalStructureDocuments_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_LegalStructureDocuments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                    table.ForeignKey(
                        name: "FK_LegalStructureDocuments_LegalStructures_LegalStructureId",
                        column: x => x.LegalStructureId,
                        principalSchema: "dbo",
                        principalTable: "LegalStructures",
                        principalColumn: "LegalStructureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalStructureDocuments_CompanyId",
                schema: "dbo",
                table: "LegalStructureDocuments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalStructureDocuments_DocumentId",
                schema: "dbo",
                table: "LegalStructureDocuments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalStructureDocuments_LegalStructureId",
                schema: "dbo",
                table: "LegalStructureDocuments",
                column: "LegalStructureId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalStructures_ApplicationId",
                schema: "dbo",
                table: "LegalStructures",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalStructures_CompanyId",
                schema: "dbo",
                table: "LegalStructures",
                column: "CompanyId",
                unique: true,
                filter: "[CompanyId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegalStructureDocuments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LegalStructures",
                schema: "dbo");

            migrationBuilder.AddColumn<int>(
                name: "LegalStructureType",
                schema: "dbo",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalStructureTypeOther",
                schema: "dbo",
                table: "Companies",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
