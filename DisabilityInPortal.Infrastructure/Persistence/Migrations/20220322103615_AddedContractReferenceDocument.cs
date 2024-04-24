using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddedContractReferenceDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                schema: "dbo",
                table: "ContractReferences",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractReferences_DocumentId",
                schema: "dbo",
                table: "ContractReferences",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractReferences_Documents_DocumentId",
                schema: "dbo",
                table: "ContractReferences",
                column: "DocumentId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractReferences_Documents_DocumentId",
                schema: "dbo",
                table: "ContractReferences");

            migrationBuilder.DropIndex(
                name: "IX_ContractReferences_DocumentId",
                schema: "dbo",
                table: "ContractReferences");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                schema: "dbo",
                table: "ContractReferences");
        }
    }
}
