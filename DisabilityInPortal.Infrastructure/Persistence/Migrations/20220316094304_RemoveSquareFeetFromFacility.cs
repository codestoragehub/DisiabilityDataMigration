using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class RemoveSquareFeetFromFacility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SquareFeet",
                schema: "dbo",
                table: "Facilities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "SquareFeet",
                schema: "dbo",
                table: "Facilities",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
