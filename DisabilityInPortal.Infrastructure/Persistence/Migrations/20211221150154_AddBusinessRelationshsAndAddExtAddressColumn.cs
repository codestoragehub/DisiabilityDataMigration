using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddBusinessRelationshsAndAddExtAddressColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ext",
                schema: "dbo",
                table: "Addresses",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BusinessRelationships",
                schema: "dbo",
                columns: table => new
                {
                    BusinessRelationshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasSubsidiariesOrAffiliate = table.Column<bool>(type: "bit", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    ExplanationOfOralOrImpliedAgreement = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BusinessName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    RelationshipType = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessRelationships", x => x.BusinessRelationshipId);
                    table.ForeignKey(
                        name: "FK_BusinessRelationships_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "dbo",
                        principalTable: "Addresses",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_BusinessRelationships_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessRelationships_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "dbo",
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessRelationships_AddressId",
                schema: "dbo",
                table: "BusinessRelationships",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessRelationships_ApplicationId",
                schema: "dbo",
                table: "BusinessRelationships",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessRelationships_DocumentId",
                schema: "dbo",
                table: "BusinessRelationships",
                column: "DocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessRelationships",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "Ext",
                schema: "dbo",
                table: "Addresses");
        }
    }
}
