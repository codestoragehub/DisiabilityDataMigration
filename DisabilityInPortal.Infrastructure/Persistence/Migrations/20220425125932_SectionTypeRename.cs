using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class SectionTypeRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sectiontype",
                schema: "dbo",
                table: "SectionReviews",
                newName: "SectionType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SectionType",
                schema: "dbo",
                table: "SectionReviews",
                newName: "Sectiontype");
        }
    }
}
