using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class CertificationAgencyDataModifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 5);

            migrationBuilder.AddColumn<bool>(
                name: "IsInternationalOrganisation",
                schema: "dbo",
                table: "CertificationAgencies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUsOrganisation",
                schema: "dbo",
                table: "CertificationAgencies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 1,
                column: "IsUsOrganisation",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 2,
                column: "IsUsOrganisation",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 3,
                columns: new[] { "DocumentType", "IsDocumentRequired", "IsInternationalOrganisation" },
                values: new object[] { null, false, true });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 4,
                columns: new[] { "DocumentType", "IsDocumentRequired", "IsUsOrganisation" },
                values: new object[] { 2, true, true });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 6,
                columns: new[] { "DocumentType", "IsDocumentRequired", "IsUsOrganisation" },
                values: new object[] { 2, true, true });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 7,
                columns: new[] { "IsInternationalOrganisation", "Name" },
                values: new object[] { true, "MSDUK (United Kingdom)" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 8,
                columns: new[] { "IsInternationalOrganisation", "Name" },
                values: new object[] { true, "CAMSC (Canada)" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 9,
                columns: new[] { "IsInternationalOrganisation", "Name" },
                values: new object[] { true, "Supply Nation (Australia)" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 10,
                columns: new[] { "IsInternationalOrganisation", "Name" },
                values: new object[] { true, "SASDC (South Africa)" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 11,
                columns: new[] { "IsInternationalOrganisation", "Name" },
                values: new object[] { true, "Integrare (Brazil)" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 12,
                columns: new[] { "IsUsOrganisation", "Name" },
                values: new object[] { true, "CVE - VA VERIFIED" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInternationalOrganisation",
                schema: "dbo",
                table: "CertificationAgencies");

            migrationBuilder.DropColumn(
                name: "IsUsOrganisation",
                schema: "dbo",
                table: "CertificationAgencies");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 3,
                columns: new[] { "DocumentType", "IsDocumentRequired" },
                values: new object[] { 2, true });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 4,
                columns: new[] { "DocumentType", "IsDocumentRequired" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 6,
                columns: new[] { "DocumentType", "IsDocumentRequired" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 7,
                column: "Name",
                value: "NVBDC");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 8,
                column: "Name",
                value: "MSDUK (United Kingdom)");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 9,
                column: "Name",
                value: "CAMSC (Canada)");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 10,
                column: "Name",
                value: "Supply Nation (Australia)");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 11,
                column: "Name",
                value: "SASDC (South Africa)");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CertificationAgencies",
                keyColumn: "CertificationAgencyId",
                keyValue: 12,
                column: "Name",
                value: "Integrare (Brazil)");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "CertificationAgencies",
                columns: new[] { "CertificationAgencyId", "DocumentType", "IsDocumentRequired", "Name" },
                values: new object[] { 5, null, false, "USPAACC" });
        }
    }
}
