using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddedManagementResponsibilityOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManagementResponsibilities_Documents_DocumentId",
                schema: "dbo",
                table: "ManagementResponsibilities");

            migrationBuilder.DropColumn(
                name: "ConductsMarketingAndSales",
                schema: "dbo",
                table: "ManagementResponsibilities");

            migrationBuilder.DropColumn(
                name: "HasHiringFiringAuthorityForManagementPersonnel",
                schema: "dbo",
                table: "ManagementResponsibilities");

            migrationBuilder.DropColumn(
                name: "HasSigningAuthorityForChecks",
                schema: "dbo",
                table: "ManagementResponsibilities");

            migrationBuilder.DropColumn(
                name: "IsResponsibleForSigningContracts",
                schema: "dbo",
                table: "ManagementResponsibilities");

            migrationBuilder.DropColumn(
                name: "MakesAndApprovesMajorCapitalExpenses",
                schema: "dbo",
                table: "ManagementResponsibilities");

            migrationBuilder.DropColumn(
                name: "MakesFinancialDecisions",
                schema: "dbo",
                table: "ManagementResponsibilities");

            migrationBuilder.DropColumn(
                name: "SelectsProjectsOnWhichToBidAndAccept",
                schema: "dbo",
                table: "ManagementResponsibilities");

            migrationBuilder.DropColumn(
                name: "SignsCosignsForLoansLinesOfCredit",
                schema: "dbo",
                table: "ManagementResponsibilities");

            migrationBuilder.DropColumn(
                name: "SupervisesDayToDayOperations",
                schema: "dbo",
                table: "ManagementResponsibilities");

            migrationBuilder.DropColumn(
                name: "SupervisesFieldworkProduction",
                schema: "dbo",
                table: "ManagementResponsibilities");

            migrationBuilder.DropColumn(
                name: "WhoActuallyDoesTheBiddingAndEstimating",
                schema: "dbo",
                table: "ManagementResponsibilities");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                schema: "dbo",
                table: "ManagementResponsibilities",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_ManagementResponsibilities_DocumentId",
                schema: "dbo",
                table: "ManagementResponsibilities",
                newName: "IX_ManagementResponsibilities_OwnerId");

            migrationBuilder.CreateTable(
                name: "ManagementResponsibilityOwners",
                schema: "dbo",
                columns: table => new
                {
                    ManagementResponsibilityOwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    SupervisesDayToDayOperations = table.Column<bool>(type: "bit", nullable: true),
                    SupervisesFieldworkProduction = table.Column<bool>(type: "bit", nullable: true),
                    HasHiringFiringAuthorityForManagementPersonnel = table.Column<bool>(type: "bit", nullable: true),
                    MakesFinancialDecisions = table.Column<bool>(type: "bit", nullable: true),
                    HasSigningAuthorityForChecks = table.Column<bool>(type: "bit", nullable: true),
                    SignsCosignsForLoansLinesOfCredit = table.Column<bool>(type: "bit", nullable: true),
                    ConductsMarketingAndSales = table.Column<bool>(type: "bit", nullable: true),
                    IsResponsibleForSigningContracts = table.Column<bool>(type: "bit", nullable: true),
                    MakesAndApprovesMajorCapitalExpenses = table.Column<bool>(type: "bit", nullable: true),
                    SelectsProjectsOnWhichToBidAndAccept = table.Column<bool>(type: "bit", nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    ManagementResponsibilityId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementResponsibilityOwners", x => x.ManagementResponsibilityOwnerId);
                    table.ForeignKey(
                        name: "FK_ManagementResponsibilityOwners_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                    table.ForeignKey(
                        name: "FK_ManagementResponsibilityOwners_ManagementResponsibilities_ManagementResponsibilityId",
                        column: x => x.ManagementResponsibilityId,
                        principalSchema: "dbo",
                        principalTable: "ManagementResponsibilities",
                        principalColumn: "ManagementResponsibilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagementResponsibilityOwners_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "dbo",
                        principalTable: "Owners",
                        principalColumn: "OwnerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManagementResponsibilityOwners_DocumentId",
                schema: "dbo",
                table: "ManagementResponsibilityOwners",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementResponsibilityOwners_ManagementResponsibilityId",
                schema: "dbo",
                table: "ManagementResponsibilityOwners",
                column: "ManagementResponsibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementResponsibilityOwners_OwnerId",
                schema: "dbo",
                table: "ManagementResponsibilityOwners",
                column: "OwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ManagementResponsibilities_Owners_OwnerId",
                schema: "dbo",
                table: "ManagementResponsibilities",
                column: "OwnerId",
                principalSchema: "dbo",
                principalTable: "Owners",
                principalColumn: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManagementResponsibilities_Owners_OwnerId",
                schema: "dbo",
                table: "ManagementResponsibilities");

            migrationBuilder.DropTable(
                name: "ManagementResponsibilityOwners",
                schema: "dbo");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                schema: "dbo",
                table: "ManagementResponsibilities",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_ManagementResponsibilities_OwnerId",
                schema: "dbo",
                table: "ManagementResponsibilities",
                newName: "IX_ManagementResponsibilities_DocumentId");

            migrationBuilder.AddColumn<bool>(
                name: "ConductsMarketingAndSales",
                schema: "dbo",
                table: "ManagementResponsibilities",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasHiringFiringAuthorityForManagementPersonnel",
                schema: "dbo",
                table: "ManagementResponsibilities",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasSigningAuthorityForChecks",
                schema: "dbo",
                table: "ManagementResponsibilities",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsResponsibleForSigningContracts",
                schema: "dbo",
                table: "ManagementResponsibilities",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MakesAndApprovesMajorCapitalExpenses",
                schema: "dbo",
                table: "ManagementResponsibilities",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MakesFinancialDecisions",
                schema: "dbo",
                table: "ManagementResponsibilities",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SelectsProjectsOnWhichToBidAndAccept",
                schema: "dbo",
                table: "ManagementResponsibilities",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SignsCosignsForLoansLinesOfCredit",
                schema: "dbo",
                table: "ManagementResponsibilities",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SupervisesDayToDayOperations",
                schema: "dbo",
                table: "ManagementResponsibilities",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SupervisesFieldworkProduction",
                schema: "dbo",
                table: "ManagementResponsibilities",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhoActuallyDoesTheBiddingAndEstimating",
                schema: "dbo",
                table: "ManagementResponsibilities",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ManagementResponsibilities_Documents_DocumentId",
                schema: "dbo",
                table: "ManagementResponsibilities",
                column: "DocumentId",
                principalSchema: "dbo",
                principalTable: "Documents",
                principalColumn: "DocumentId");
        }
    }
}
