using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddSupplierProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sp");

            migrationBuilder.CreateTable(
                name: "SupplierProfiles",
                schema: "sp",
                columns: table => new
                {
                    SupplierProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegalBusinessName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DoingBusinessAs = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FormerCompanyNames = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyWebsiteAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TaxIdType = table.Column<int>(type: "int", nullable: true),
                    FederalTaxId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    IsFranchise = table.Column<bool>(type: "bit", nullable: true),
                    CerificationType = table.Column<int>(type: "int", nullable: false),
                    HowDidYouHearAboutUs = table.Column<int>(type: "int", nullable: true),
                    OtherHowDidYouHearAboutUs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossIncomeLastYear = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossIncome2ndLastYear = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossIncome3rdLastYear = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberOfEmployees = table.Column<int>(type: "int", nullable: false),
                    NumOfYearInBusiness = table.Column<int>(type: "int", nullable: false),
                    IndustryType = table.Column<int>(type: "int", nullable: false),
                    IndustryTypeOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractorLicenseNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ContractorTradeSpecialty = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    PrimaryOwnerEthnicity = table.Column<int>(type: "int", nullable: false),
                    IsPrimaryOwnerLGBTQ = table.Column<bool>(type: "bit", nullable: false),
                    OwnerContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerContactMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificationNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CertificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CertificationExpirationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Facebooklink = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Twiterlink = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    VideoLink = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProfiles", x => x.SupplierProfileId);
                    table.ForeignKey(
                        name: "FK_SupplierProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SupplierProfileAddresses",
                schema: "sp",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddressType = table.Column<int>(type: "int", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    City = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZipCodePlus4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ext = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    SupplierProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProfileAddresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_SupplierProfileAddresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_SupplierProfileAddresses_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "dbo",
                        principalTable: "States",
                        principalColumn: "StateId");
                    table.ForeignKey(
                        name: "FK_SupplierProfileAddresses_SupplierProfiles_SupplierProfileId",
                        column: x => x.SupplierProfileId,
                        principalSchema: "sp",
                        principalTable: "SupplierProfiles",
                        principalColumn: "SupplierProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierProfileAddresses_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierProfileCapabilities",
                schema: "sp",
                columns: table => new
                {
                    SupplierProfileCapabilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductServiceDescription = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    GeographicalServiceArea = table.Column<int>(type: "int", nullable: false),
                    SupplierProfileId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProfileCapabilities", x => x.SupplierProfileCapabilityId);
                    table.ForeignKey(
                        name: "FK_SupplierProfileCapabilities_SupplierProfiles_SupplierProfileId",
                        column: x => x.SupplierProfileId,
                        principalSchema: "sp",
                        principalTable: "SupplierProfiles",
                        principalColumn: "SupplierProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierProfileCapabilities_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SupplierProfileDocuments",
                schema: "sp",
                columns: table => new
                {
                    SupplierProfileDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SupplierProfileId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProfileDocuments", x => x.SupplierProfileDocumentId);
                    table.ForeignKey(
                        name: "FK_SupplierProfileDocuments_SupplierProfiles_SupplierProfileId",
                        column: x => x.SupplierProfileId,
                        principalSchema: "sp",
                        principalTable: "SupplierProfiles",
                        principalColumn: "SupplierProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierProfileDocuments_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SupplierProfileLegalStructure",
                schema: "sp",
                columns: table => new
                {
                    SupplierProfileLegalStructureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegalStructureType = table.Column<int>(type: "int", nullable: false),
                    LegalStructureTypeOther = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    SupplierProfileId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProfileLegalStructure", x => x.SupplierProfileLegalStructureId);
                    table.ForeignKey(
                        name: "FK_SupplierProfileLegalStructure_SupplierProfiles_SupplierProfileId",
                        column: x => x.SupplierProfileId,
                        principalSchema: "sp",
                        principalTable: "SupplierProfiles",
                        principalColumn: "SupplierProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NaicsCodeSupplierProfileCapability",
                schema: "dbo",
                columns: table => new
                {
                    NaicsCodesCode = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    SupplierProfileCapabilitiesSupplierProfileCapabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaicsCodeSupplierProfileCapability", x => new { x.NaicsCodesCode, x.SupplierProfileCapabilitiesSupplierProfileCapabilityId });
                    table.ForeignKey(
                        name: "FK_NaicsCodeSupplierProfileCapability_NaicsCodes_NaicsCodesCode",
                        column: x => x.NaicsCodesCode,
                        principalSchema: "dbo",
                        principalTable: "NaicsCodes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NaicsCodeSupplierProfileCapability_SupplierProfileCapabilities_SupplierProfileCapabilitiesSupplierProfileCapabilityId",
                        column: x => x.SupplierProfileCapabilitiesSupplierProfileCapabilityId,
                        principalSchema: "sp",
                        principalTable: "SupplierProfileCapabilities",
                        principalColumn: "SupplierProfileCapabilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SicCodeSupplierProfileCapability",
                schema: "dbo",
                columns: table => new
                {
                    SicCodesCode = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    SupplierProfileCapabilitiesSupplierProfileCapabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SicCodeSupplierProfileCapability", x => new { x.SicCodesCode, x.SupplierProfileCapabilitiesSupplierProfileCapabilityId });
                    table.ForeignKey(
                        name: "FK_SicCodeSupplierProfileCapability_SicCodes_SicCodesCode",
                        column: x => x.SicCodesCode,
                        principalSchema: "dbo",
                        principalTable: "SicCodes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SicCodeSupplierProfileCapability_SupplierProfileCapabilities_SupplierProfileCapabilitiesSupplierProfileCapabilityId",
                        column: x => x.SupplierProfileCapabilitiesSupplierProfileCapabilityId,
                        principalSchema: "sp",
                        principalTable: "SupplierProfileCapabilities",
                        principalColumn: "SupplierProfileCapabilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierProfileCapabilityUkSicCode",
                schema: "dbo",
                columns: table => new
                {
                    SupplierProfileCapabilitiesSupplierProfileCapabilityId = table.Column<int>(type: "int", nullable: false),
                    UkSicCodesCode = table.Column<string>(type: "nvarchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProfileCapabilityUkSicCode", x => new { x.SupplierProfileCapabilitiesSupplierProfileCapabilityId, x.UkSicCodesCode });
                    table.ForeignKey(
                        name: "FK_SupplierProfileCapabilityUkSicCode_SupplierProfileCapabilities_SupplierProfileCapabilitiesSupplierProfileCapabilityId",
                        column: x => x.SupplierProfileCapabilitiesSupplierProfileCapabilityId,
                        principalSchema: "sp",
                        principalTable: "SupplierProfileCapabilities",
                        principalColumn: "SupplierProfileCapabilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierProfileCapabilityUkSicCode_UkSicCodes_UkSicCodesCode",
                        column: x => x.UkSicCodesCode,
                        principalSchema: "dbo",
                        principalTable: "UkSicCodes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierProfileCapabilityUnNumberCode",
                schema: "dbo",
                columns: table => new
                {
                    SupplierProfileCapabilitiesSupplierProfileCapabilityId = table.Column<int>(type: "int", nullable: false),
                    UnNumberCodesCode = table.Column<string>(type: "nvarchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProfileCapabilityUnNumberCode", x => new { x.SupplierProfileCapabilitiesSupplierProfileCapabilityId, x.UnNumberCodesCode });
                    table.ForeignKey(
                        name: "FK_SupplierProfileCapabilityUnNumberCode_SupplierProfileCapabilities_SupplierProfileCapabilitiesSupplierProfileCapabilityId",
                        column: x => x.SupplierProfileCapabilitiesSupplierProfileCapabilityId,
                        principalSchema: "sp",
                        principalTable: "SupplierProfileCapabilities",
                        principalColumn: "SupplierProfileCapabilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierProfileCapabilityUnNumberCode_UnNumberCodes_UnNumberCodesCode",
                        column: x => x.UnNumberCodesCode,
                        principalSchema: "dbo",
                        principalTable: "UnNumberCodes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierProfileCapabilityUnspscCode",
                schema: "dbo",
                columns: table => new
                {
                    SupplierProfileCapabilitiesSupplierProfileCapabilityId = table.Column<int>(type: "int", nullable: false),
                    UnspscCodesCode = table.Column<string>(type: "nvarchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProfileCapabilityUnspscCode", x => new { x.SupplierProfileCapabilitiesSupplierProfileCapabilityId, x.UnspscCodesCode });
                    table.ForeignKey(
                        name: "FK_SupplierProfileCapabilityUnspscCode_SupplierProfileCapabilities_SupplierProfileCapabilitiesSupplierProfileCapabilityId",
                        column: x => x.SupplierProfileCapabilitiesSupplierProfileCapabilityId,
                        principalSchema: "sp",
                        principalTable: "SupplierProfileCapabilities",
                        principalColumn: "SupplierProfileCapabilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierProfileCapabilityUnspscCode_UnspscCodes_UnspscCodesCode",
                        column: x => x.UnspscCodesCode,
                        principalSchema: "dbo",
                        principalTable: "UnspscCodes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierProfileCertificationAgencies",
                schema: "sp",
                columns: table => new
                {
                    SupplierProfileCertificationAgencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierProfileId = table.Column<int>(type: "int", nullable: false),
                    CertificationAgencyId = table.Column<int>(type: "int", nullable: false),
                    SupplierProfileDocumentId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProfileCertificationAgencies", x => x.SupplierProfileCertificationAgencyId);
                    table.ForeignKey(
                        name: "FK_SupplierProfileCertificationAgencies_CertificationAgencies_CertificationAgencyId",
                        column: x => x.CertificationAgencyId,
                        principalSchema: "dbo",
                        principalTable: "CertificationAgencies",
                        principalColumn: "CertificationAgencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierProfileCertificationAgencies_SupplierProfileDocuments_SupplierProfileDocumentId",
                        column: x => x.SupplierProfileDocumentId,
                        principalSchema: "sp",
                        principalTable: "SupplierProfileDocuments",
                        principalColumn: "SupplierProfileDocumentId");
                    table.ForeignKey(
                        name: "FK_SupplierProfileCertificationAgencies_SupplierProfiles_SupplierProfileId",
                        column: x => x.SupplierProfileId,
                        principalSchema: "sp",
                        principalTable: "SupplierProfiles",
                        principalColumn: "SupplierProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierProfileContractReferences",
                schema: "sp",
                columns: table => new
                {
                    SupplierProfileContractReferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyOrOrganizationName = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    BuyerOrRepresentative = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    ProductOrService = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    DollarValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplierProfileDocumentId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SupplierProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProfileContractReferences", x => x.SupplierProfileContractReferenceId);
                    table.ForeignKey(
                        name: "FK_SupplierProfileContractReferences_SupplierProfileAddresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "sp",
                        principalTable: "SupplierProfileAddresses",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_SupplierProfileContractReferences_SupplierProfileDocuments_SupplierProfileDocumentId",
                        column: x => x.SupplierProfileDocumentId,
                        principalSchema: "sp",
                        principalTable: "SupplierProfileDocuments",
                        principalColumn: "SupplierProfileDocumentId");
                    table.ForeignKey(
                        name: "FK_SupplierProfileContractReferences_SupplierProfiles_SupplierProfileId",
                        column: x => x.SupplierProfileId,
                        principalSchema: "sp",
                        principalTable: "SupplierProfiles",
                        principalColumn: "SupplierProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierProfileContractReferences_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NaicsCodeSupplierProfileCapability_SupplierProfileCapabilitiesSupplierProfileCapabilityId",
                schema: "dbo",
                table: "NaicsCodeSupplierProfileCapability",
                column: "SupplierProfileCapabilitiesSupplierProfileCapabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_SicCodeSupplierProfileCapability_SupplierProfileCapabilitiesSupplierProfileCapabilityId",
                schema: "dbo",
                table: "SicCodeSupplierProfileCapability",
                column: "SupplierProfileCapabilitiesSupplierProfileCapabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileAddresses_CountryId",
                schema: "sp",
                table: "SupplierProfileAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileAddresses_StateId",
                schema: "sp",
                table: "SupplierProfileAddresses",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileAddresses_SupplierProfileId",
                schema: "sp",
                table: "SupplierProfileAddresses",
                column: "SupplierProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileAddresses_UserId",
                schema: "sp",
                table: "SupplierProfileAddresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileCapabilities_SupplierProfileId",
                schema: "sp",
                table: "SupplierProfileCapabilities",
                column: "SupplierProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileCapabilities_UserId",
                schema: "sp",
                table: "SupplierProfileCapabilities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileCapabilityUkSicCode_UkSicCodesCode",
                schema: "dbo",
                table: "SupplierProfileCapabilityUkSicCode",
                column: "UkSicCodesCode");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileCapabilityUnNumberCode_UnNumberCodesCode",
                schema: "dbo",
                table: "SupplierProfileCapabilityUnNumberCode",
                column: "UnNumberCodesCode");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileCapabilityUnspscCode_UnspscCodesCode",
                schema: "dbo",
                table: "SupplierProfileCapabilityUnspscCode",
                column: "UnspscCodesCode");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileCertificationAgencies_CertificationAgencyId",
                schema: "sp",
                table: "SupplierProfileCertificationAgencies",
                column: "CertificationAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileCertificationAgencies_SupplierProfileDocumentId",
                schema: "sp",
                table: "SupplierProfileCertificationAgencies",
                column: "SupplierProfileDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileCertificationAgencies_SupplierProfileId",
                schema: "sp",
                table: "SupplierProfileCertificationAgencies",
                column: "SupplierProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileContractReferences_AddressId",
                schema: "sp",
                table: "SupplierProfileContractReferences",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileContractReferences_SupplierProfileDocumentId",
                schema: "sp",
                table: "SupplierProfileContractReferences",
                column: "SupplierProfileDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileContractReferences_SupplierProfileId",
                schema: "sp",
                table: "SupplierProfileContractReferences",
                column: "SupplierProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileContractReferences_UserId",
                schema: "sp",
                table: "SupplierProfileContractReferences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileDocuments_SupplierProfileId",
                schema: "sp",
                table: "SupplierProfileDocuments",
                column: "SupplierProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileDocuments_UserId",
                schema: "sp",
                table: "SupplierProfileDocuments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfileLegalStructure_SupplierProfileId",
                schema: "sp",
                table: "SupplierProfileLegalStructure",
                column: "SupplierProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProfiles_UserId",
                schema: "sp",
                table: "SupplierProfiles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NaicsCodeSupplierProfileCapability",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SicCodeSupplierProfileCapability",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SupplierProfileCapabilityUkSicCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SupplierProfileCapabilityUnNumberCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SupplierProfileCapabilityUnspscCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SupplierProfileCertificationAgencies",
                schema: "sp");

            migrationBuilder.DropTable(
                name: "SupplierProfileContractReferences",
                schema: "sp");

            migrationBuilder.DropTable(
                name: "SupplierProfileLegalStructure",
                schema: "sp");

            migrationBuilder.DropTable(
                name: "SupplierProfileCapabilities",
                schema: "sp");

            migrationBuilder.DropTable(
                name: "SupplierProfileAddresses",
                schema: "sp");

            migrationBuilder.DropTable(
                name: "SupplierProfileDocuments",
                schema: "sp");

            migrationBuilder.DropTable(
                name: "SupplierProfiles",
                schema: "sp");
        }
    }
}
