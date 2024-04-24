using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddedOperationAndControl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyHistoryAndOwnerships_SiteVisitReviewDetails_SiteVisitReviewId",
                schema: "dbo",
                table: "CompanyHistoryAndOwnerships");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_SiteVisitReviewDetails_SiteVisitReviewId",
                schema: "dbo",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteVisitReviewDetails_Applications_ApplicationId",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteVisitReviewDetails_Users_UserId",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteVisitReviewOwners_SiteVisitReviewDetails_SiteVisitReviewId",
                schema: "dbo",
                table: "SiteVisitReviewOwners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SiteVisitReviewDetails",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropColumn(
                name: "FirmNotOwnedByPwd",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropColumn(
                name: "HasCommonEmployeesUse",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropColumn(
                name: "IsEquityOwnership",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropColumn(
                name: "IsInterFirmTransactions",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropColumn(
                name: "IsManagement",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropColumn(
                name: "IsOfficeOrFacilitiesSharing",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropColumn(
                name: "PwdCanNotDemonstrateInvestment",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropColumn(
                name: "PwdCapitalContributionNotCommensurate",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropColumn(
                name: "PwdExpertiseContributionNotCommensurate",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropColumn(
                name: "PwdMaintainsJobElseWhere",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropColumn(
                name: "PwdMaintainsNotOwnedFirm",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropColumn(
                name: "PwdNotControlDailyOperations",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.DropColumn(
                name: "PwdNotHaveTechnicalExpertise",
                schema: "dbo",
                table: "SiteVisitReviewDetails");

            migrationBuilder.RenameTable(
                name: "SiteVisitReviewDetails",
                schema: "dbo",
                newName: "SiteVisitReviews",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "PwdOperatesWithOtherIndividuals",
                schema: "dbo",
                table: "SiteVisitReviews",
                newName: "IsFormDetailsConfirmed");

            migrationBuilder.RenameIndex(
                name: "IX_SiteVisitReviewDetails_UserId",
                schema: "dbo",
                table: "SiteVisitReviews",
                newName: "IX_SiteVisitReviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SiteVisitReviewDetails_ApplicationId",
                schema: "dbo",
                table: "SiteVisitReviews",
                newName: "IX_SiteVisitReviews_ApplicationId");

            migrationBuilder.AlterColumn<string>(
                name: "RecommendationReasons",
                schema: "dbo",
                table: "SiteVisitReviews",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiteVisitReviews",
                schema: "dbo",
                table: "SiteVisitReviews",
                column: "SiteVisitReviewId");

            migrationBuilder.CreateTable(
                name: "OperationAndControls",
                schema: "dbo",
                columns: table => new
                {
                    OperationAndControlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerDutiesAndResponsibilities = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TimedevoteToBusiness = table.Column<int>(type: "int", nullable: false),
                    HowDecisionsMadeWhenOwnerUnavailable = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WhoHasFinalWordOnDecision = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WhoSupervisesOperations = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WhoSupervisesFieldwork = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WhoMakesFinancialDecision = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WhoConductMarketingSales = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WhoResponsibleForSigningContracts = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WhoMakesApprovesPurchases = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WhoSelectsProjectsToBid = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WhoActuallyBiddingAndEstimating = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyBiddingOrEstimatingProcedures = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    WhoHasSignatureAuthority = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    HowManySignaturesRequired = table.Column<int>(type: "int", nullable: false),
                    IsWorkingForOtherCompany = table.Column<bool>(type: "bit", nullable: false),
                    NameAndTypeOfOtherCompany = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TitleAndResponsibilityAtOtherCompany = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    BusinessPlanForCompanyFuture = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OperationSectionComments = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SiteVisitReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationAndControls", x => x.OperationAndControlId);
                    table.ForeignKey(
                        name: "FK_OperationAndControls_SiteVisitReviews_SiteVisitReviewId",
                        column: x => x.SiteVisitReviewId,
                        principalSchema: "dbo",
                        principalTable: "SiteVisitReviews",
                        principalColumn: "SiteVisitReviewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperationAndControls_SiteVisitReviewId",
                schema: "dbo",
                table: "OperationAndControls",
                column: "SiteVisitReviewId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyHistoryAndOwnerships_SiteVisitReviews_SiteVisitReviewId",
                schema: "dbo",
                table: "CompanyHistoryAndOwnerships",
                column: "SiteVisitReviewId",
                principalSchema: "dbo",
                principalTable: "SiteVisitReviews",
                principalColumn: "SiteVisitReviewId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_SiteVisitReviews_SiteVisitReviewId",
                schema: "dbo",
                table: "Offices",
                column: "SiteVisitReviewId",
                principalSchema: "dbo",
                principalTable: "SiteVisitReviews",
                principalColumn: "SiteVisitReviewId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteVisitReviewOwners_SiteVisitReviews_SiteVisitReviewId",
                schema: "dbo",
                table: "SiteVisitReviewOwners",
                column: "SiteVisitReviewId",
                principalSchema: "dbo",
                principalTable: "SiteVisitReviews",
                principalColumn: "SiteVisitReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteVisitReviews_Applications_ApplicationId",
                schema: "dbo",
                table: "SiteVisitReviews",
                column: "ApplicationId",
                principalSchema: "dbo",
                principalTable: "Applications",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteVisitReviews_Users_UserId",
                schema: "dbo",
                table: "SiteVisitReviews",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyHistoryAndOwnerships_SiteVisitReviews_SiteVisitReviewId",
                schema: "dbo",
                table: "CompanyHistoryAndOwnerships");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_SiteVisitReviews_SiteVisitReviewId",
                schema: "dbo",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteVisitReviewOwners_SiteVisitReviews_SiteVisitReviewId",
                schema: "dbo",
                table: "SiteVisitReviewOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteVisitReviews_Applications_ApplicationId",
                schema: "dbo",
                table: "SiteVisitReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteVisitReviews_Users_UserId",
                schema: "dbo",
                table: "SiteVisitReviews");

            migrationBuilder.DropTable(
                name: "OperationAndControls",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SiteVisitReviews",
                schema: "dbo",
                table: "SiteVisitReviews");

            migrationBuilder.RenameTable(
                name: "SiteVisitReviews",
                schema: "dbo",
                newName: "SiteVisitReviewDetails",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "IsFormDetailsConfirmed",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                newName: "PwdOperatesWithOtherIndividuals");

            migrationBuilder.RenameIndex(
                name: "IX_SiteVisitReviews_UserId",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                newName: "IX_SiteVisitReviewDetails_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SiteVisitReviews_ApplicationId",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                newName: "IX_SiteVisitReviewDetails_ApplicationId");

            migrationBuilder.AlterColumn<string>(
                name: "RecommendationReasons",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1500)",
                oldMaxLength: 1500,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FirmNotOwnedByPwd",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasCommonEmployeesUse",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEquityOwnership",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInterFirmTransactions",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsManagement",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOfficeOrFacilitiesSharing",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PwdCanNotDemonstrateInvestment",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PwdCapitalContributionNotCommensurate",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PwdExpertiseContributionNotCommensurate",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PwdMaintainsJobElseWhere",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PwdMaintainsNotOwnedFirm",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PwdNotControlDailyOperations",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PwdNotHaveTechnicalExpertise",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiteVisitReviewDetails",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                column: "SiteVisitReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyHistoryAndOwnerships_SiteVisitReviewDetails_SiteVisitReviewId",
                schema: "dbo",
                table: "CompanyHistoryAndOwnerships",
                column: "SiteVisitReviewId",
                principalSchema: "dbo",
                principalTable: "SiteVisitReviewDetails",
                principalColumn: "SiteVisitReviewId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_SiteVisitReviewDetails_SiteVisitReviewId",
                schema: "dbo",
                table: "Offices",
                column: "SiteVisitReviewId",
                principalSchema: "dbo",
                principalTable: "SiteVisitReviewDetails",
                principalColumn: "SiteVisitReviewId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteVisitReviewDetails_Applications_ApplicationId",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                column: "ApplicationId",
                principalSchema: "dbo",
                principalTable: "Applications",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteVisitReviewDetails_Users_UserId",
                schema: "dbo",
                table: "SiteVisitReviewDetails",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteVisitReviewOwners_SiteVisitReviewDetails_SiteVisitReviewId",
                schema: "dbo",
                table: "SiteVisitReviewOwners",
                column: "SiteVisitReviewId",
                principalSchema: "dbo",
                principalTable: "SiteVisitReviewDetails",
                principalColumn: "SiteVisitReviewId");
        }
    }
}
