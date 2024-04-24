using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddAdditionalInformations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalInformations",
                schema: "dbo",
                columns: table => new
                {
                    AdditionalInformationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsInvolvedInLawsuit = table.Column<bool>(type: "bit", nullable: false),
                    IsInvolvedInBankruptcy = table.Column<bool>(type: "bit", nullable: false),
                    HasBeenDeniedCertification = table.Column<bool>(type: "bit", nullable: false),
                    RequiresAccommodationsDuringSiteVisit = table.Column<bool>(type: "bit", nullable: false),
                    LawsuitDocumentId = table.Column<int>(type: "int", nullable: true),
                    BankruptcyDocumentId = table.Column<int>(type: "int", nullable: true),
                    CertificationDenialDocumentId = table.Column<int>(type: "int", nullable: true),
                    SiteVisitAccomodationRequirementsDocumentId = table.Column<int>(type: "int", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalInformations", x => x.AdditionalInformationId);
                    table.ForeignKey(
                        name: "FK_AdditionalInformations_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalInformations_Documents_BankruptcyDocumentId",
                        column: x => x.BankruptcyDocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                    table.ForeignKey(
                        name: "FK_AdditionalInformations_Documents_CertificationDenialDocumentId",
                        column: x => x.CertificationDenialDocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                    table.ForeignKey(
                        name: "FK_AdditionalInformations_Documents_LawsuitDocumentId",
                        column: x => x.LawsuitDocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                    table.ForeignKey(
                        name: "FK_AdditionalInformations_Documents_SiteVisitAccomodationRequirementsDocumentId",
                        column: x => x.SiteVisitAccomodationRequirementsDocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInformations_ApplicationId",
                schema: "dbo",
                table: "AdditionalInformations",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInformations_BankruptcyDocumentId",
                schema: "dbo",
                table: "AdditionalInformations",
                column: "BankruptcyDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInformations_CertificationDenialDocumentId",
                schema: "dbo",
                table: "AdditionalInformations",
                column: "CertificationDenialDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInformations_LawsuitDocumentId",
                schema: "dbo",
                table: "AdditionalInformations",
                column: "LawsuitDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInformations_SiteVisitAccomodationRequirementsDocumentId",
                schema: "dbo",
                table: "AdditionalInformations",
                column: "SiteVisitAccomodationRequirementsDocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalInformations",
                schema: "dbo");
        }
    }
}
