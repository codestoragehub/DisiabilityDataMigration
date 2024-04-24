using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddedManagersAndUpdateOperationControl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Managers",
                schema: "dbo",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    OwnerDuties = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OperationAndControlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_Managers_OperationAndControls_OperationAndControlId",
                        column: x => x.OperationAndControlId,
                        principalSchema: "dbo",
                        principalTable: "OperationAndControls",
                        principalColumn: "OperationAndControlId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Managers_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "dbo",
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Managers_OperationAndControlId",
                schema: "dbo",
                table: "Managers",
                column: "OperationAndControlId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_OwnerId",
                schema: "dbo",
                table: "Managers",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers",
                schema: "dbo");
        }
    }
}
