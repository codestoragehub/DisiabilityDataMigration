using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddedOwnerToManagementContributions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameOfIndividual",
                schema: "dbo",
                table: "ManagementContributions");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                schema: "dbo",
                table: "ManagementContributions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ManagementContributions_OwnerId",
                schema: "dbo",
                table: "ManagementContributions",
                column: "OwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ManagementContributions_Owners_OwnerId",
                schema: "dbo",
                table: "ManagementContributions",
                column: "OwnerId",
                principalSchema: "dbo",
                principalTable: "Owners",
                principalColumn: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManagementContributions_Owners_OwnerId",
                schema: "dbo",
                table: "ManagementContributions");

            migrationBuilder.DropIndex(
                name: "IX_ManagementContributions_OwnerId",
                schema: "dbo",
                table: "ManagementContributions");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                schema: "dbo",
                table: "ManagementContributions");

            migrationBuilder.AddColumn<string>(
                name: "NameOfIndividual",
                schema: "dbo",
                table: "ManagementContributions",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);
        }
    }
}
