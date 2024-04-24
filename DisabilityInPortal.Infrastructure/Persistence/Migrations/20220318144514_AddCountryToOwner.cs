using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddCountryToOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                schema: "dbo",
                table: "Owners",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_CountryId",
                schema: "dbo",
                table: "Owners",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Countries_CountryId",
                schema: "dbo",
                table: "Owners",
                column: "CountryId",
                principalSchema: "dbo",
                principalTable: "Countries",
                principalColumn: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Countries_CountryId",
                schema: "dbo",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_CountryId",
                schema: "dbo",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "dbo",
                table: "Owners");
        }
    }
}
