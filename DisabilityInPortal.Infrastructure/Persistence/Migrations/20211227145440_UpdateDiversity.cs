using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class UpdateDiversity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiversityTypeValue",
                schema: "dbo",
                table: "Diversities");

            migrationBuilder.DropColumn(
                name: "EthnicityOther",
                schema: "dbo",
                table: "Diversities");

            migrationBuilder.RenameColumn(
                name: "GenderOther",
                schema: "dbo",
                table: "Diversities",
                newName: "DiversityTypeOther");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiversityTypeOther",
                schema: "dbo",
                table: "Diversities",
                newName: "GenderOther");

            migrationBuilder.AddColumn<int>(
                name: "DiversityTypeValue",
                schema: "dbo",
                table: "Diversities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EthnicityOther",
                schema: "dbo",
                table: "Diversities",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
