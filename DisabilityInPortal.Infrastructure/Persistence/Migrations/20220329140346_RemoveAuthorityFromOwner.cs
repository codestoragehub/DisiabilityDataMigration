using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class RemoveAuthorityFromOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Authority",
                schema: "dbo",
                table: "Owners");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Authority",
                schema: "dbo",
                table: "Owners",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }
    }
}
