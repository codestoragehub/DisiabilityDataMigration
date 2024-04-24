using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddDisabilityImpactDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisabilityImpacts_Documents_DefenceFormDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropForeignKey(
                name: "FK_DisabilityImpacts_Documents_DisabilityBenefitsDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropForeignKey(
                name: "FK_DisabilityImpacts_Documents_DisabilityINPhysicianFormDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropForeignKey(
                name: "FK_DisabilityImpacts_Documents_DisabilityRatingsLetterDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropForeignKey(
                name: "FK_DisabilityImpacts_Documents_DisabilityStatementDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropForeignKey(
                name: "FK_DisabilityImpacts_Documents_IEPDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropIndex(
                name: "IX_DisabilityImpacts_DefenceFormDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropIndex(
                name: "IX_DisabilityImpacts_DisabilityBenefitsDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropIndex(
                name: "IX_DisabilityImpacts_DisabilityINPhysicianFormDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropIndex(
                name: "IX_DisabilityImpacts_DisabilityRatingsLetterDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropIndex(
                name: "IX_DisabilityImpacts_DisabilityStatementDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropIndex(
                name: "IX_DisabilityImpacts_IEPDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropColumn(
                name: "DefenceFormDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropColumn(
                name: "DisabilityBenefitsDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropColumn(
                name: "DisabilityINPhysicianFormDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropColumn(
                name: "DisabilityRatingsLetterDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropColumn(
                name: "DisabilityStatementDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropColumn(
                name: "IEPDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.AlterColumn<string>(
                name: "LicenseNumber",
                schema: "dbo",
                table: "Contractors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DisabilityImpactDocuments",
                schema: "dbo",
                columns: table => new
                {
                    DisabilityImpactDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DisabilityImpactDocumentType = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    DisabilityImpactId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabilityImpactDocuments", x => x.DisabilityImpactDocumentId);
                    table.ForeignKey(
                        name: "FK_DisabilityImpactDocuments_DisabilityImpacts_DisabilityImpactId",
                        column: x => x.DisabilityImpactId,
                        principalSchema: "dbo",
                        principalTable: "DisabilityImpacts",
                        principalColumn: "DisabilityImpactId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisabilityImpactDocuments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityImpactDocuments_DisabilityImpactId",
                schema: "dbo",
                table: "DisabilityImpactDocuments",
                column: "DisabilityImpactId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityImpactDocuments_DocumentId",
                schema: "dbo",
                table: "DisabilityImpactDocuments",
                column: "DocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisabilityImpactDocuments",
                schema: "dbo");

            migrationBuilder.AddColumn<int>(
                name: "DefenceFormDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisabilityBenefitsDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisabilityINPhysicianFormDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisabilityRatingsLetterDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisabilityStatementDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IEPDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LicenseNumber",
                schema: "dbo",
                table: "Contractors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityImpacts_DefenceFormDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                column: "DefenceFormDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityImpacts_DisabilityBenefitsDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                column: "DisabilityBenefitsDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityImpacts_DisabilityINPhysicianFormDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                column: "DisabilityINPhysicianFormDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityImpacts_DisabilityRatingsLetterDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                column: "DisabilityRatingsLetterDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityImpacts_DisabilityStatementDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                column: "DisabilityStatementDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityImpacts_IEPDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                column: "IEPDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisabilityImpacts_Documents_DefenceFormDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                column: "DefenceFormDocumentId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisabilityImpacts_Documents_DisabilityBenefitsDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                column: "DisabilityBenefitsDocumentId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisabilityImpacts_Documents_DisabilityINPhysicianFormDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                column: "DisabilityINPhysicianFormDocumentId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisabilityImpacts_Documents_DisabilityRatingsLetterDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                column: "DisabilityRatingsLetterDocumentId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisabilityImpacts_Documents_DisabilityStatementDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                column: "DisabilityStatementDocumentId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisabilityImpacts_Documents_IEPDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                column: "IEPDocumentId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");
        }
    }
}
