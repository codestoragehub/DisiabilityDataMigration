using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class RemoveExistingOutsideFirmIndividuals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM OutsideFirmIndividuals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
