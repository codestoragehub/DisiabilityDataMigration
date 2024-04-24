using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class ModifyFileUploadForCertificationAgency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 12,
                columns: new[] { "DocumentType", "IsDocumentRequired" },
                values: new object[] { 41, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 12,
                columns: new[] { "DocumentType", "IsDocumentRequired" },
                values: new object[] { null, false });
        }
    }
}
