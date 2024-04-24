using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddContractReferenceBankAndCreditReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAndCreditReferences",
                schema: "dbo",
                columns: table => new
                {
                    BankAndCreditReferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    TypeOfAccount = table.Column<int>(type: "int", nullable: false),
                    Signatories = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreditLine = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LoanDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAndCreditReferences", x => x.BankAndCreditReferenceId);
                    table.ForeignKey(
                        name: "FK_BankAndCreditReferences_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "dbo",
                        principalTable: "Addresses",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_BankAndCreditReferences_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankAndCreditReferences_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateTable(
                name: "ContractReferences",
                schema: "dbo",
                columns: table => new
                {
                    ContractReferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyOrOrganizationName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    BuyerOrRepresentative = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProductOrService = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DollarValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractReferences", x => x.ContractReferenceId);
                    table.ForeignKey(
                        name: "FK_ContractReferences_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "dbo",
                        principalTable: "Addresses",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_ContractReferences_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAndCreditReferences_AddressId",
                schema: "dbo",
                table: "BankAndCreditReferences",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAndCreditReferences_ApplicationId",
                schema: "dbo",
                table: "BankAndCreditReferences",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAndCreditReferences_DocumentId",
                schema: "dbo",
                table: "BankAndCreditReferences",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractReferences_AddressId",
                schema: "dbo",
                table: "ContractReferences",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractReferences_ApplicationId",
                schema: "dbo",
                table: "ContractReferences",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAndCreditReferences",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ContractReferences",
                schema: "dbo");
        }
    }
}
