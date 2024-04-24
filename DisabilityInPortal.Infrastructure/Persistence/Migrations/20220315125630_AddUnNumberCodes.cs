using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddUnNumberCodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnNumberCodes",
                schema: "dbo",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnNumberCodes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "CapabilityUnNumberCode",
                schema: "dbo",
                columns: table => new
                {
                    CapabilitiesCapabilityId = table.Column<int>(type: "int", nullable: false),
                    UnNumberCodesCode = table.Column<string>(type: "nvarchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapabilityUnNumberCode", x => new { x.CapabilitiesCapabilityId, x.UnNumberCodesCode });
                    table.ForeignKey(
                        name: "FK_CapabilityUnNumberCode_Capabilities_CapabilitiesCapabilityId",
                        column: x => x.CapabilitiesCapabilityId,
                        principalSchema: "dbo",
                        principalTable: "Capabilities",
                        principalColumn: "CapabilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapabilityUnNumberCode_UnNumberCodes_UnNumberCodesCode",
                        column: x => x.UnNumberCodesCode,
                        principalSchema: "dbo",
                        principalTable: "UnNumberCodes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapabilityUnNumberCode_UnNumberCodesCode",
                schema: "dbo",
                table: "CapabilityUnNumberCode",
                column: "UnNumberCodesCode");

            migrationBuilder.CreateIndex(
                name: "IX_UnNumberCodes_Description",
                schema: "dbo",
                table: "UnNumberCodes",
                column: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapabilityUnNumberCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UnNumberCodes",
                schema: "dbo");
        }
    }
}
