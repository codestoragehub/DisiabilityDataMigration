using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class UpdateFinancialSizeInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LegalStructures_CompanyId",
                schema: "dbo",
                table: "LegalStructures");

            migrationBuilder.DropColumn(
                name: "BusinessAcquisition",
                schema: "dbo",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "BalanceSheetId",
                schema: "dbo",
                table: "Income",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FederalTaxReturnId",
                schema: "dbo",
                table: "Income",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfitLossStatementId",
                schema: "dbo",
                table: "Income",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SsdStatementId",
                schema: "dbo",
                table: "Income",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SsiStatementId",
                schema: "dbo",
                table: "Income",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimarySourceOfIncome",
                schema: "dbo",
                table: "FinancialSizeInfos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecentItemizedPayrollId",
                schema: "dbo",
                table: "FinancialSizeInfos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessAcquisitionType",
                schema: "dbo",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SiteVisitInfo",
                schema: "dbo",
                table: "AdditionalInformations",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalStructures_CompanyId",
                schema: "dbo",
                table: "LegalStructures",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Income_BalanceSheetId",
                schema: "dbo",
                table: "Income",
                column: "BalanceSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Income_FederalTaxReturnId",
                schema: "dbo",
                table: "Income",
                column: "FederalTaxReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_Income_ProfitLossStatementId",
                schema: "dbo",
                table: "Income",
                column: "ProfitLossStatementId");

            migrationBuilder.CreateIndex(
                name: "IX_Income_SsdStatementId",
                schema: "dbo",
                table: "Income",
                column: "SsdStatementId");

            migrationBuilder.CreateIndex(
                name: "IX_Income_SsiStatementId",
                schema: "dbo",
                table: "Income",
                column: "SsiStatementId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialSizeInfos_RecentItemizedPayrollId",
                schema: "dbo",
                table: "FinancialSizeInfos",
                column: "RecentItemizedPayrollId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialSizeInfos_Documents_RecentItemizedPayrollId",
                schema: "dbo",
                table: "FinancialSizeInfos",
                column: "RecentItemizedPayrollId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Income_Documents_BalanceSheetId",
                schema: "dbo",
                table: "Income",
                column: "BalanceSheetId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Income_Documents_FederalTaxReturnId",
                schema: "dbo",
                table: "Income",
                column: "FederalTaxReturnId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Income_Documents_ProfitLossStatementId",
                schema: "dbo",
                table: "Income",
                column: "ProfitLossStatementId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Income_Documents_SsdStatementId",
                schema: "dbo",
                table: "Income",
                column: "SsdStatementId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Income_Documents_SsiStatementId",
                schema: "dbo",
                table: "Income",
                column: "SsiStatementId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialSizeInfos_Documents_RecentItemizedPayrollId",
                schema: "dbo",
                table: "FinancialSizeInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_Documents_BalanceSheetId",
                schema: "dbo",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_Documents_FederalTaxReturnId",
                schema: "dbo",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_Documents_ProfitLossStatementId",
                schema: "dbo",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_Documents_SsdStatementId",
                schema: "dbo",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_Documents_SsiStatementId",
                schema: "dbo",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_LegalStructures_CompanyId",
                schema: "dbo",
                table: "LegalStructures");

            migrationBuilder.DropIndex(
                name: "IX_Income_BalanceSheetId",
                schema: "dbo",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_Income_FederalTaxReturnId",
                schema: "dbo",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_Income_ProfitLossStatementId",
                schema: "dbo",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_Income_SsdStatementId",
                schema: "dbo",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_Income_SsiStatementId",
                schema: "dbo",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_FinancialSizeInfos_RecentItemizedPayrollId",
                schema: "dbo",
                table: "FinancialSizeInfos");

            migrationBuilder.DropColumn(
                name: "BalanceSheetId",
                schema: "dbo",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "FederalTaxReturnId",
                schema: "dbo",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "ProfitLossStatementId",
                schema: "dbo",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "SsdStatementId",
                schema: "dbo",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "SsiStatementId",
                schema: "dbo",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "PrimarySourceOfIncome",
                schema: "dbo",
                table: "FinancialSizeInfos");

            migrationBuilder.DropColumn(
                name: "RecentItemizedPayrollId",
                schema: "dbo",
                table: "FinancialSizeInfos");

            migrationBuilder.DropColumn(
                name: "BusinessAcquisitionType",
                schema: "dbo",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "SiteVisitInfo",
                schema: "dbo",
                table: "AdditionalInformations");

            migrationBuilder.AddColumn<string>(
                name: "BusinessAcquisition",
                schema: "dbo",
                table: "Companies",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalStructures_CompanyId",
                schema: "dbo",
                table: "LegalStructures",
                column: "CompanyId",
                unique: true,
                filter: "[CompanyId] IS NOT NULL");
        }
    }
}
