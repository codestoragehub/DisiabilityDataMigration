using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddReferenceApplicationAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationNumber",
                schema: "dbo",
                table: "Applications");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserReference",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationReference",
                schema: "dbo",
                table: "Applications",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserReference",
                schema: "Identity",
                table: "Users",
                column: "UserReference");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationReference",
                schema: "dbo",
                table: "Applications",
                column: "ApplicationReference");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserReference",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ApplicationReference",
                schema: "dbo",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "UserReference",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ApplicationReference",
                schema: "dbo",
                table: "Applications");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationNumber",
                schema: "dbo",
                table: "Applications",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }
    }
}
