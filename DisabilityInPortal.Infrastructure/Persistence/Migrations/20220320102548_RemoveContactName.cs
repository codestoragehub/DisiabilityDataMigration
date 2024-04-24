using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class RemoveContactName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactName",
                schema: "dbo",
                table: "BankAndCreditReferences");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                schema: "dbo",
                table: "BankAndCreditReferences",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
