using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "dbo",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceReference = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyType = table.Column<int>(type: "int", nullable: false),
                    InvoiceStatus = table.Column<int>(type: "int", nullable: false),
                    StripePaymentMethod = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    StripeCustomerId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                schema: "dbo",
                columns: table => new
                {
                    InvoiceItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => x.InvoiceItemId);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "dbo",
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InvoiceId",
                schema: "dbo",
                table: "Payments",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentIntents_InvoiceId",
                schema: "dbo",
                table: "PaymentIntents",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InvoiceId",
                schema: "dbo",
                table: "InvoiceItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ApplicationId",
                schema: "dbo",
                table: "Invoices",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentIntents_Invoices_InvoiceId",
                schema: "dbo",
                table: "PaymentIntents",
                column: "InvoiceId",
                principalSchema: "dbo",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Invoices_InvoiceId",
                schema: "dbo",
                table: "Payments",
                column: "InvoiceId",
                principalSchema: "dbo",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentIntents_Invoices_InvoiceId",
                schema: "dbo",
                table: "PaymentIntents");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Invoices_InvoiceId",
                schema: "dbo",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "InvoiceItems",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Payments_InvoiceId",
                schema: "dbo",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_PaymentIntents_InvoiceId",
                schema: "dbo",
                table: "PaymentIntents");
        }
    }
}
