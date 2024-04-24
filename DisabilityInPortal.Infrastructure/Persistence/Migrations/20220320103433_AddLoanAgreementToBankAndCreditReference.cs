using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddLoanAgreementToBankAndCreditReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasOutstandingLoans",
                schema: "dbo",
                table: "BankAndCreditReferences",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LoanAgreementDocumentId",
                schema: "dbo",
                table: "BankAndCreditReferences",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankAndCreditReferences_LoanAgreementDocumentId",
                schema: "dbo",
                table: "BankAndCreditReferences",
                column: "LoanAgreementDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAndCreditReferences_Documents_LoanAgreementDocumentId",
                schema: "dbo",
                table: "BankAndCreditReferences",
                column: "LoanAgreementDocumentId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAndCreditReferences_Documents_LoanAgreementDocumentId",
                schema: "dbo",
                table: "BankAndCreditReferences");

            migrationBuilder.DropIndex(
                name: "IX_BankAndCreditReferences_LoanAgreementDocumentId",
                schema: "dbo",
                table: "BankAndCreditReferences");

            migrationBuilder.DropColumn(
                name: "HasOutstandingLoans",
                schema: "dbo",
                table: "BankAndCreditReferences");

            migrationBuilder.DropColumn(
                name: "LoanAgreementDocumentId",
                schema: "dbo",
                table: "BankAndCreditReferences");
        }
    }
}
