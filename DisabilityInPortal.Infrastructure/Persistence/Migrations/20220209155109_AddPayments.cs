using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddPayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                schema: "dbo",
                columns: table => new
                {
                    PaymentDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsRecertification = table.Column<bool>(type: "bit", nullable: false),
                    StripeCustomerId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    StripePaymentMethod = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IsExpeditedApplication = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfDaysToExpedite = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.PaymentDetailId);
                    table.ForeignKey(
                        name: "FK_PaymentDetails_Applications_ApplicationId",
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
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "dbo",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
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
                name: "PaymentIntents",
                schema: "dbo",
                columns: table => new
                {
                    PaymentIntentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StripePaymentIntentId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    StripePaymentMethod = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PaymentIntentStatus = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentIntents", x => x.PaymentIntentId);
                    table.ForeignKey(
                        name: "FK_PaymentIntents_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "dbo",
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "dbo",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentReference = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    PaymentIntentId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentIntents_PaymentIntentId",
                        column: x => x.PaymentIntentId,
                        principalSchema: "dbo",
                        principalTable: "PaymentIntents",
                        principalColumn: "PaymentIntentId");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_ApplicationId",
                schema: "dbo",
                table: "PaymentDetails",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentIntents_InvoiceId",
                schema: "dbo",
                table: "PaymentIntents",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentIntentId",
                schema: "dbo",
                table: "Payments",
                column: "PaymentIntentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                schema: "dbo",
                table: "InvoiceItems",
                column: "InvoiceId",
                principalSchema: "dbo",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Payments_InvoiceId",
                schema: "dbo",
                table: "Invoices",
                column: "InvoiceId",
                principalSchema: "dbo",
                principalTable: "Payments",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentIntents_Invoices_InvoiceId",
                schema: "dbo",
                table: "PaymentIntents");

            migrationBuilder.DropTable(
                name: "InvoiceItems",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PaymentDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PaymentIntents",
                schema: "dbo");
        }
    }
}
