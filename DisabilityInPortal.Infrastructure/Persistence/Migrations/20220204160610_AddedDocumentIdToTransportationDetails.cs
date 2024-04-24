using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddedDocumentIdToTransportationDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                schema: "dbo",
                table: "TransportationDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransportationDetails_DocumentId",
                schema: "dbo",
                table: "TransportationDetails",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportationDetails_Documents_DocumentId",
                schema: "dbo",
                table: "TransportationDetails",
                column: "DocumentId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportationDetails_Documents_DocumentId",
                schema: "dbo",
                table: "TransportationDetails");

            migrationBuilder.DropIndex(
                name: "IX_TransportationDetails_DocumentId",
                schema: "dbo",
                table: "TransportationDetails");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                schema: "dbo",
                table: "TransportationDetails");
        }
    }
}
