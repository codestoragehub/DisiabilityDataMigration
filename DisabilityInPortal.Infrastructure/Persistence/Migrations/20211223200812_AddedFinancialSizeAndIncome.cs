using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddedFinancialSizeAndIncome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialSizeInfos",
                schema: "dbo",
                columns: table => new
                {
                    FinancialSizeInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicesProvided = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IndustryType = table.Column<int>(type: "int", nullable: false),
                    IndustryTypeOther = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CurrentEmployeesNo = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialSizeInfos", x => x.FinancialSizeInfoId);
                    table.ForeignKey(
                        name: "FK_FinancialSizeInfos_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinancialSizeInfos_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateTable(
                name: "Income",
                schema: "dbo",
                columns: table => new
                {
                    IncomeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    YearIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IncomeType = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    FinancialSizeInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Income", x => x.IncomeId);
                    table.ForeignKey(
                        name: "FK_Income_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                    table.ForeignKey(
                        name: "FK_Income_FinancialSizeInfos_FinancialSizeInfoId",
                        column: x => x.FinancialSizeInfoId,
                        principalSchema: "dbo",
                        principalTable: "FinancialSizeInfos",
                        principalColumn: "FinancialSizeInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialSizeInfos_ApplicationId",
                schema: "dbo",
                table: "FinancialSizeInfos",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinancialSizeInfos_DocumentId",
                schema: "dbo",
                table: "FinancialSizeInfos",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Income_DocumentId",
                schema: "dbo",
                table: "Income",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Income_FinancialSizeInfoId",
                schema: "dbo",
                table: "Income",
                column: "FinancialSizeInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Income",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FinancialSizeInfos",
                schema: "dbo");
        }
    }
}
