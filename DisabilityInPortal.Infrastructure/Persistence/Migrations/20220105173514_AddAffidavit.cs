using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddAffidavit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Affidavits",
                schema: "dbo",
                columns: table => new
                {
                    AffidavitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    AcceptedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    IP = table.Column<int>(type: "nvarchar(250)", nullable: true),
                    OS = table.Column<int>(type: "nvarchar(250)", nullable: true),
                    Browser = table.Column<int>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affidavits", x => x.AffidavitId);
                    table.ForeignKey(
                        name: "FK_Affidavits_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Affidavits_ApplicationId",
                schema: "dbo",
                table: "Affidavits",
                column: "ApplicationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Affidavits",
                schema: "dbo");
        }
    }
}
