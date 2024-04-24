using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddCertificationAgenciesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "CertificationAgencies",
                columns: new[] { "CertificationAgencyId", "DocumentType", "IsDocumentRequired", "Name" },
                values: new object[,]
                {
                    { 1, 2, true, "NGLCC" },
                    { 2, 2, true, "WBENC" },
                    { 3, 2, true, "WEConnect International (Global)" },
                    { 4, null, false, "NMSDC" },
                    { 5, null, false, "USPAACC" },
                    { 6, null, false, "NAVOBA" },
                    { 7, null, false, "NVBDC" },
                    { 8, null, false, "MSDUK (United Kingdom)" },
                    { 9, null, false, "CAMSC (Canada)" },
                    { 10, null, false, "Supply Nation (Australia)" },
                    { 11, null, false, "SASDC (South Africa)" },
                    { 12, null, false, "Integrare (Brazil)" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 12);
        }
    }
}
