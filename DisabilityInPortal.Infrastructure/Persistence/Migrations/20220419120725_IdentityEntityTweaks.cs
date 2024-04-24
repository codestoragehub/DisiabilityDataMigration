using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class IdentityEntityTweaks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_ApplicationRoleId",
                schema: "Identity",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_ApplicationUserId",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_ApplicationRoleId",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_ApplicationUserId",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_ApplicationRoleId",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_ApplicationUserId",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserClaims_ApplicationUserId",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropIndex(
                name: "IX_RoleClaims_ApplicationRoleId",
                schema: "Identity",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "ApplicationRoleId",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropColumn(
                name: "ApplicationRoleId",
                schema: "Identity",
                table: "RoleClaims");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationRoleId",
                schema: "Identity",
                table: "UserRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "UserRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "UserClaims",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationRoleId",
                schema: "Identity",
                table: "RoleClaims",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_ApplicationRoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "ApplicationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_ApplicationUserId",
                schema: "Identity",
                table: "UserRoles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_ApplicationUserId",
                schema: "Identity",
                table: "UserClaims",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_ApplicationRoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "ApplicationRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_ApplicationRoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "ApplicationRoleId",
                principalSchema: "Identity",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_ApplicationUserId",
                schema: "Identity",
                table: "UserClaims",
                column: "ApplicationUserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_ApplicationRoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "ApplicationRoleId",
                principalSchema: "Identity",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_ApplicationUserId",
                schema: "Identity",
                table: "UserRoles",
                column: "ApplicationUserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
