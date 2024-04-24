using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class UpdatedDisabilityImpact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisabilityImpacts_Documents_DocumentId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.DropIndex(
                name: "IX_DisabilityImpacts_ApplicationId",
                schema: "dbo",
                table: "DisabilityImpacts");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                newName: "IEPDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_DisabilityImpacts_DocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                newName: "IX_DisabilityImpacts_IEPDocumentId");

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

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityImpacts_ApplicationId",
                schema: "dbo",
                table: "DisabilityImpacts",
                column: "ApplicationId",
                unique: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IX_DisabilityImpacts_ApplicationId",
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

            migrationBuilder.RenameColumn(
                name: "IEPDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_DisabilityImpacts_IEPDocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                newName: "IX_DisabilityImpacts_DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityImpacts_ApplicationId",
                schema: "dbo",
                table: "DisabilityImpacts",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisabilityImpacts_Documents_DocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                column: "DocumentId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");
        }
    }
}
