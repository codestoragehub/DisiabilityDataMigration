using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeOffset = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AffectedColumns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "CertificationAgencies",
                schema: "dbo",
                columns: table => new
                {
                    CertificationAgencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDocumentRequired = table.Column<bool>(type: "bit", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationAgencies", x => x.CertificationAgencyId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "dbo",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iso2Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iso3Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumericCode = table.Column<int>(type: "int", nullable: false),
                    PhoneCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencySymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tld = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "NaicsCodes",
                schema: "dbo",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaicsCodes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SicCodes",
                schema: "dbo",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Division = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    MajorGroup = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    IndustryGroup = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SicCodes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "UkSicCodes",
                schema: "dbo",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Section = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    SectionDescription = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UkSicCodes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "UnspscCodes",
                schema: "dbo",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnspscCodes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsUSABasedCompany = table.Column<bool>(type: "bit", nullable: false),
                    IsStartUpCompany = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "dbo",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationRoleId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_ApplicationRoleId",
                        column: x => x.ApplicationRoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationRoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_ApplicationRoleId",
                        column: x => x.ApplicationRoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "dbo",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegalBusinessName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DoingBusinessAs = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FormerCompanyNames = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyWebsiteAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TaxIdType = table.Column<int>(type: "int", nullable: true),
                    FederalTaxId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessAcquisition = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsBusinessStartedByCurrentOwnership = table.Column<bool>(type: "bit", nullable: true),
                    BusinessHistory = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IndustryType = table.Column<int>(type: "int", nullable: true),
                    LegalStructureType = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    IsFranchise = table.Column<bool>(type: "bit", nullable: true),
                    IsContractorCompany = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_Companies_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "dbo",
                        principalTable: "States",
                        principalColumn: "StateId");
                    table.ForeignKey(
                        name: "FK_Companies_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                schema: "dbo",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HowDidYouHearAboutUs = table.Column<int>(type: "int", nullable: true),
                    ReferredBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ApplicationCreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ApplicationSubmittedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ApplicationApprovedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ApplicationExpirationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ApplicationStatus = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Applications_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_Applications_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "dbo",
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
                    County = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_Addresses_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "dbo",
                        principalTable: "States",
                        principalColumn: "StateId");
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Capabilities",
                schema: "dbo",
                columns: table => new
                {
                    CapabilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductServiceDescription = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    GeographicalServiceArea = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capabilities", x => x.CapabilityId);
                    table.ForeignKey(
                        name: "FK_Capabilities_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                schema: "dbo",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_Documents_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagementAtOutsideFirms",
                schema: "dbo",
                columns: table => new
                {
                    ManagementAtOutsideFirmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasAnyManagementOutsideAtFirm = table.Column<bool>(type: "bit", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementAtOutsideFirms", x => x.ManagementAtOutsideFirmId);
                    table.ForeignKey(
                        name: "FK_ManagementAtOutsideFirms_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagementContributions",
                schema: "dbo",
                columns: table => new
                {
                    ManagementContributionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfIndividual = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Equipment = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    RealEstate = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Other = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementContributions", x => x.ManagementContributionId);
                    table.ForeignKey(
                        name: "FK_ManagementContributions_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstates",
                schema: "dbo",
                columns: table => new
                {
                    RealEstateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasFullTimeOffice = table.Column<bool>(type: "bit", nullable: false),
                    IsHomeBusinessHeadquarters = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.RealEstateId);
                    table.ForeignKey(
                        name: "FK_RealEstates_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportationDetails",
                schema: "dbo",
                columns: table => new
                {
                    TransportationDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoesCompanyInvolveTransportation = table.Column<bool>(type: "bit", nullable: false),
                    OperatingStatus = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CommonCarrier = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IndependentCarrier = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InsuranceCarrier = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Commodities = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsFleetContracted = table.Column<bool>(type: "bit", nullable: false),
                    IsFleetLeased = table.Column<bool>(type: "bit", nullable: false),
                    IsFleetOwned = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationDetails", x => x.TransportationDetailId);
                    table.ForeignKey(
                        name: "FK_TransportationDetails_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CapabilityNaicsCode",
                schema: "dbo",
                columns: table => new
                {
                    CapabilitiesCapabilityId = table.Column<int>(type: "int", nullable: false),
                    NaicsCodesCode = table.Column<string>(type: "nvarchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapabilityNaicsCode", x => new { x.CapabilitiesCapabilityId, x.NaicsCodesCode });
                    table.ForeignKey(
                        name: "FK_CapabilityNaicsCode_Capabilities_CapabilitiesCapabilityId",
                        column: x => x.CapabilitiesCapabilityId,
                        principalSchema: "dbo",
                        principalTable: "Capabilities",
                        principalColumn: "CapabilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapabilityNaicsCode_NaicsCodes_NaicsCodesCode",
                        column: x => x.NaicsCodesCode,
                        principalSchema: "dbo",
                        principalTable: "NaicsCodes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CapabilitySicCode",
                schema: "dbo",
                columns: table => new
                {
                    CapabilitiesCapabilityId = table.Column<int>(type: "int", nullable: false),
                    SicCodesCode = table.Column<string>(type: "nvarchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapabilitySicCode", x => new { x.CapabilitiesCapabilityId, x.SicCodesCode });
                    table.ForeignKey(
                        name: "FK_CapabilitySicCode_Capabilities_CapabilitiesCapabilityId",
                        column: x => x.CapabilitiesCapabilityId,
                        principalSchema: "dbo",
                        principalTable: "Capabilities",
                        principalColumn: "CapabilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapabilitySicCode_SicCodes_SicCodesCode",
                        column: x => x.SicCodesCode,
                        principalSchema: "dbo",
                        principalTable: "SicCodes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CapabilityUkSicCode",
                schema: "dbo",
                columns: table => new
                {
                    CapabilitiesCapabilityId = table.Column<int>(type: "int", nullable: false),
                    UkSicCodesCode = table.Column<string>(type: "nvarchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapabilityUkSicCode", x => new { x.CapabilitiesCapabilityId, x.UkSicCodesCode });
                    table.ForeignKey(
                        name: "FK_CapabilityUkSicCode_Capabilities_CapabilitiesCapabilityId",
                        column: x => x.CapabilitiesCapabilityId,
                        principalSchema: "dbo",
                        principalTable: "Capabilities",
                        principalColumn: "CapabilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapabilityUkSicCode_UkSicCodes_UkSicCodesCode",
                        column: x => x.UkSicCodesCode,
                        principalSchema: "dbo",
                        principalTable: "UkSicCodes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CapabilityUnspscCode",
                schema: "dbo",
                columns: table => new
                {
                    CapabilitiesCapabilityId = table.Column<int>(type: "int", nullable: false),
                    UnspscCodesCode = table.Column<string>(type: "nvarchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapabilityUnspscCode", x => new { x.CapabilitiesCapabilityId, x.UnspscCodesCode });
                    table.ForeignKey(
                        name: "FK_CapabilityUnspscCode_Capabilities_CapabilitiesCapabilityId",
                        column: x => x.CapabilitiesCapabilityId,
                        principalSchema: "dbo",
                        principalTable: "Capabilities",
                        principalColumn: "CapabilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapabilityUnspscCode_UnspscCodes_UnspscCodesCode",
                        column: x => x.UnspscCodesCode,
                        principalSchema: "dbo",
                        principalTable: "UnspscCodes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddressDocuments",
                schema: "dbo",
                columns: table => new
                {
                    AddressDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressType = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDocuments", x => x.AddressDocumentId);
                    table.ForeignKey(
                        name: "FK_AddressDocuments_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "dbo",
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressDocuments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationCertificationAgencies",
                schema: "dbo",
                columns: table => new
                {
                    ApplicationCertificationAgencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    CertificationAgencyId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationCertificationAgencies", x => x.ApplicationCertificationAgencyId);
                    table.ForeignKey(
                        name: "FK_ApplicationCertificationAgencies_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationCertificationAgencies_CertificationAgencies_CertificationAgencyId",
                        column: x => x.CertificationAgencyId,
                        principalSchema: "dbo",
                        principalTable: "CertificationAgencies",
                        principalColumn: "CertificationAgencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationCertificationAgencies_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateTable(
                name: "Contractors",
                schema: "dbo",
                columns: table => new
                {
                    ContractorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseNumber = table.Column<int>(type: "int", nullable: false),
                    TradeSpecialty = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.ContractorId);
                    table.ForeignKey(
                        name: "FK_Contractors_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_Contractors_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateTable(
                name: "DisabilityImpacts",
                schema: "dbo",
                columns: table => new
                {
                    DisabilityImpactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabilityImpacts", x => x.DisabilityImpactId);
                    table.ForeignKey(
                        name: "FK_DisabilityImpacts_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisabilityImpacts_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateTable(
                name: "Diversities",
                schema: "dbo",
                columns: table => new
                {
                    DiversityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiversityType = table.Column<int>(type: "int", nullable: false),
                    DiversityTypeValue = table.Column<int>(type: "int", nullable: false),
                    CertifyingOrganization = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ExpirationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CertificationNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GenderOther = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EthnicityOther = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diversities", x => x.DiversityId);
                    table.ForeignKey(
                        name: "FK_Diversities_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diversities_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                schema: "dbo",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentType = table.Column<string>(type: "nvarchar(270)", maxLength: 270, nullable: true),
                    Ownership = table.Column<int>(type: "int", nullable: false),
                    EquipmentUsed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipmentId);
                    table.ForeignKey(
                        name: "FK_Equipments_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateTable(
                name: "ManagementResponsibilities",
                schema: "dbo",
                columns: table => new
                {
                    ManagementResponsibilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    WhoActuallyDoesTheBiddingAndEstimating = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementResponsibilities", x => x.ManagementResponsibilityId);
                    table.ForeignKey(
                        name: "FK_ManagementResponsibilities_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagementResponsibilities_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                schema: "dbo",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Authority = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    GenderOther = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ownership = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DisabilityStatus = table.Column<bool>(type: "bit", nullable: false),
                    ParticipatesShareVoting = table.Column<bool>(type: "bit", nullable: false),
                    DailyManagement = table.Column<bool>(type: "bit", nullable: false),
                    USCitizen = table.Column<bool>(type: "bit", nullable: false),
                    Ethinicity = table.Column<int>(type: "int", nullable: false),
                    EthinicityOther = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsLGBT = table.Column<bool>(type: "bit", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_Owners_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Owners_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateTable(
                name: "TrustDetails",
                schema: "dbo",
                columns: table => new
                {
                    TrustDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsBusinessControlledByTrust = table.Column<bool>(type: "bit", nullable: false),
                    IsIrrevocable = table.Column<bool>(type: "bit", nullable: true),
                    IsBenefactor = table.Column<bool>(type: "bit", nullable: false),
                    IsGrantor = table.Column<bool>(type: "bit", nullable: false),
                    IsTrustee = table.Column<bool>(type: "bit", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrustDetails", x => x.TrustDetailId);
                    table.ForeignKey(
                        name: "FK_TrustDetails_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrustDetails_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                schema: "dbo",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleLicensePlateId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Ownership = table.Column<int>(type: "int", nullable: false),
                    VehicleUsed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateTable(
                name: "OutsideFirmIndividuals",
                schema: "dbo",
                columns: table => new
                {
                    OutsideFirmIndividualId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndividualName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ManagementType = table.Column<int>(type: "int", nullable: false),
                    FirmWorkingType = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    ManagementAtOutsideFirmId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutsideFirmIndividuals", x => x.OutsideFirmIndividualId);
                    table.ForeignKey(
                        name: "FK_OutsideFirmIndividuals_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                    table.ForeignKey(
                        name: "FK_OutsideFirmIndividuals_ManagementAtOutsideFirms_ManagementAtOutsideFirmId",
                        column: x => x.ManagementAtOutsideFirmId,
                        principalSchema: "dbo",
                        principalTable: "ManagementAtOutsideFirms",
                        principalColumn: "ManagementAtOutsideFirmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                schema: "dbo",
                columns: table => new
                {
                    FacilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityType = table.Column<int>(type: "int", nullable: false),
                    SquareFeet = table.Column<float>(type: "real", nullable: false),
                    Ownership = table.Column<int>(type: "int", nullable: false),
                    RentalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    RealEstateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.FacilityId);
                    table.ForeignKey(
                        name: "FK_Facilities_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "dbo",
                        principalTable: "Addresses",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_Facilities_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                    table.ForeignKey(
                        name: "FK_Facilities_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalSchema: "dbo",
                        principalTable: "RealEstates",
                        principalColumn: "RealEstateId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressDocuments_AddressId",
                schema: "dbo",
                table: "AddressDocuments",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressDocuments_DocumentId",
                schema: "dbo",
                table: "AddressDocuments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ApplicationId",
                schema: "dbo",
                table: "Addresses",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CompanyId",
                schema: "dbo",
                table: "Addresses",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                schema: "dbo",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateId",
                schema: "dbo",
                table: "Addresses",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                schema: "dbo",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationCertificationAgencies_ApplicationId_CertificationAgencyId",
                schema: "dbo",
                table: "ApplicationCertificationAgencies",
                columns: new[] { "ApplicationId", "CertificationAgencyId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationCertificationAgencies_CertificationAgencyId",
                schema: "dbo",
                table: "ApplicationCertificationAgencies",
                column: "CertificationAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationCertificationAgencies_DocumentId",
                schema: "dbo",
                table: "ApplicationCertificationAgencies",
                column: "DocumentId",
                unique: true,
                filter: "[DocumentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CompanyId",
                schema: "dbo",
                table: "Applications",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                schema: "dbo",
                table: "Applications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Capabilities_ApplicationId",
                schema: "dbo",
                table: "Capabilities",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CapabilityNaicsCode_NaicsCodesCode",
                schema: "dbo",
                table: "CapabilityNaicsCode",
                column: "NaicsCodesCode");

            migrationBuilder.CreateIndex(
                name: "IX_CapabilitySicCode_SicCodesCode",
                schema: "dbo",
                table: "CapabilitySicCode",
                column: "SicCodesCode");

            migrationBuilder.CreateIndex(
                name: "IX_CapabilityUkSicCode_UkSicCodesCode",
                schema: "dbo",
                table: "CapabilityUkSicCode",
                column: "UkSicCodesCode");

            migrationBuilder.CreateIndex(
                name: "IX_CapabilityUnspscCode_UnspscCodesCode",
                schema: "dbo",
                table: "CapabilityUnspscCode",
                column: "UnspscCodesCode");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CountryId",
                schema: "dbo",
                table: "Companies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_StateId",
                schema: "dbo",
                table: "Companies",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserId",
                schema: "dbo",
                table: "Companies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_CompanyId",
                schema: "dbo",
                table: "Contractors",
                column: "CompanyId",
                unique: true,
                filter: "[CompanyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_DocumentId",
                schema: "dbo",
                table: "Contractors",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityImpacts_ApplicationId",
                schema: "dbo",
                table: "DisabilityImpacts",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilityImpacts_DocumentId",
                schema: "dbo",
                table: "DisabilityImpacts",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Diversities_ApplicationId",
                schema: "dbo",
                table: "Diversities",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Diversities_DocumentId",
                schema: "dbo",
                table: "Diversities",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ApplicationId",
                schema: "dbo",
                table: "Documents",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CompanyId",
                schema: "dbo",
                table: "Documents",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UserId",
                schema: "dbo",
                table: "Documents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_ApplicationId",
                schema: "dbo",
                table: "Equipments",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_DocumentId",
                schema: "dbo",
                table: "Equipments",
                column: "DocumentId",
                unique: true,
                filter: "[DocumentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_AddressId",
                schema: "dbo",
                table: "Facilities",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_DocumentId",
                schema: "dbo",
                table: "Facilities",
                column: "DocumentId",
                unique: true,
                filter: "[DocumentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_RealEstateId",
                schema: "dbo",
                table: "Facilities",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementAtOutsideFirms_ApplicationId",
                schema: "dbo",
                table: "ManagementAtOutsideFirms",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManagementContributions_ApplicationId",
                schema: "dbo",
                table: "ManagementContributions",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementResponsibilities_ApplicationId",
                schema: "dbo",
                table: "ManagementResponsibilities",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManagementResponsibilities_DocumentId",
                schema: "dbo",
                table: "ManagementResponsibilities",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_NaicsCodes_Description",
                schema: "dbo",
                table: "NaicsCodes",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_OutsideFirmIndividuals_DocumentId",
                schema: "dbo",
                table: "OutsideFirmIndividuals",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_OutsideFirmIndividuals_ManagementAtOutsideFirmId",
                schema: "dbo",
                table: "OutsideFirmIndividuals",
                column: "ManagementAtOutsideFirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_ApplicationId",
                schema: "dbo",
                table: "Owners",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_DocumentId",
                schema: "dbo",
                table: "Owners",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_ApplicationId",
                schema: "dbo",
                table: "RealEstates",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_ApplicationRoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "ApplicationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SicCodes_Description",
                schema: "dbo",
                table: "SicCodes",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                schema: "dbo",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportationDetails_ApplicationId",
                schema: "dbo",
                table: "TransportationDetails",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrustDetails_ApplicationId",
                schema: "dbo",
                table: "TrustDetails",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrustDetails_DocumentId",
                schema: "dbo",
                table: "TrustDetails",
                column: "DocumentId",
                unique: true,
                filter: "[DocumentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UkSicCodes_Description",
                schema: "dbo",
                table: "UkSicCodes",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_UnspscCodes_Description",
                schema: "dbo",
                table: "UnspscCodes",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_ApplicationUserId",
                schema: "Identity",
                table: "UserClaims",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_ApplicationRoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "ApplicationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_ApplicationUserId",
                schema: "Identity",
                table: "UserRoles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ApplicationId",
                schema: "dbo",
                table: "Vehicles",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DocumentId",
                schema: "dbo",
                table: "Vehicles",
                column: "DocumentId",
                unique: true,
                filter: "[DocumentId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressDocuments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicationCertificationAgencies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AuditLogs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CapabilityNaicsCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CapabilitySicCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CapabilityUkSicCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CapabilityUnspscCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Contractors",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DisabilityImpacts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Diversities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Equipments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Facilities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ManagementContributions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ManagementResponsibilities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OutsideFirmIndividuals",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Owners",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "TransportationDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TrustDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Vehicles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CertificationAgencies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "NaicsCodes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SicCodes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UkSicCodes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Capabilities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UnspscCodes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RealEstates",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ManagementAtOutsideFirms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Documents",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Applications",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "States",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "dbo");
        }
    }
}
