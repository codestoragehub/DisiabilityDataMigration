using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class ChangedTransportationDocumentsToContractAndLease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportationDetails_Documents_DocumentId",
                schema: "dbo",
                table: "TransportationDetails");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                schema: "dbo",
                table: "TransportationDetails",
                newName: "LeaseDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_TransportationDetails_DocumentId",
                schema: "dbo",
                table: "TransportationDetails",
                newName: "IX_TransportationDetails_LeaseDocumentId");

            migrationBuilder.AddColumn<int>(
                name: "ContractDocumentId",
                schema: "dbo",
                table: "TransportationDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransportationDetails_ContractDocumentId",
                schema: "dbo",
                table: "TransportationDetails",
                column: "ContractDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportationDetails_Documents_ContractDocumentId",
                schema: "dbo",
                table: "TransportationDetails",
                column: "ContractDocumentId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportationDetails_Documents_LeaseDocumentId",
                schema: "dbo",
                table: "TransportationDetails",
                column: "LeaseDocumentId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportationDetails_Documents_ContractDocumentId",
                schema: "dbo",
                table: "TransportationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportationDetails_Documents_LeaseDocumentId",
                schema: "dbo",
                table: "TransportationDetails");

            migrationBuilder.DropIndex(
                name: "IX_TransportationDetails_ContractDocumentId",
                schema: "dbo",
                table: "TransportationDetails");

            migrationBuilder.DropColumn(
                name: "ContractDocumentId",
                schema: "dbo",
                table: "TransportationDetails");

            migrationBuilder.RenameColumn(
                name: "LeaseDocumentId",
                schema: "dbo",
                table: "TransportationDetails",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_TransportationDetails_LeaseDocumentId",
                schema: "dbo",
                table: "TransportationDetails",
                newName: "IX_TransportationDetails_DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportationDetails_Documents_DocumentId",
                schema: "dbo",
                table: "TransportationDetails",
                column: "DocumentId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");
        }
    }
}
