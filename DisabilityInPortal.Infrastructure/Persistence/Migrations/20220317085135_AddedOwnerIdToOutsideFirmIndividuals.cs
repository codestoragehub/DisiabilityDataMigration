using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddedOwnerIdToOutsideFirmIndividuals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndividualName",
                schema: "dbo",
                table: "OutsideFirmIndividuals");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                schema: "dbo",
                table: "OutsideFirmIndividuals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OutsideFirmIndividuals_OwnerId",
                schema: "dbo",
                table: "OutsideFirmIndividuals",
                column: "OwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OutsideFirmIndividuals_Owners_OwnerId",
                schema: "dbo",
                table: "OutsideFirmIndividuals",
                column: "OwnerId",
                principalSchema: "dbo",
                principalTable: "Owners",
                principalColumn: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutsideFirmIndividuals_Owners_OwnerId",
                schema: "dbo",
                table: "OutsideFirmIndividuals");

            migrationBuilder.DropIndex(
                name: "IX_OutsideFirmIndividuals_OwnerId",
                schema: "dbo",
                table: "OutsideFirmIndividuals");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                schema: "dbo",
                table: "OutsideFirmIndividuals");

            migrationBuilder.AddColumn<string>(
                name: "IndividualName",
                schema: "dbo",
                table: "OutsideFirmIndividuals",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);
        }
    }
}
