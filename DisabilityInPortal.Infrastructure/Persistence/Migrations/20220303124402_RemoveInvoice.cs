using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class RemoveInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentIntents_Invoices_InvoiceId",
                schema: "dbo",
                table: "PaymentIntents");

            migrationBuilder.DropTable(
                name: "InvoiceItems",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_PaymentIntents_InvoiceId",
                schema: "dbo",
                table: "PaymentIntents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "dbo",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    CurrencyType = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    InvoiceReference = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    InvoiceStatus = table.Column<int>(type: "int", nullable: false),
                    StripeCustomerId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    StripePaymentMethod = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Invoices_Payments_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "dbo",
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                schema: "dbo",
                columns: table => new
                {
                    InvoiceItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
        }
    }
}
