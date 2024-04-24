using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class UpdateUserAndCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VeteranStatusType",
                schema: "Identity",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LegalStructureTypeOther",
                schema: "dbo",
                table: "Companies",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VeteranStatusType",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LegalStructureTypeOther",
                schema: "dbo",
                table: "Companies");
        }
    }
}
