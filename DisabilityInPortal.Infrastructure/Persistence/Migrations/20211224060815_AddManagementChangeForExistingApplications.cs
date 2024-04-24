using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Contexts;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddManagementChangeForExistingApplications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @$"INSERT INTO {nameof(IDisabilityInPortalDbContext.ManagementChanges)} 
                (
                    {nameof(ManagementChange.ApplicationId)},
                    {nameof(ManagementChange.HasOrIntendToEnterIntoAnyTypeOfAgreement)}
                )
                SELECT {nameof(Application.ApplicationId)}, 'false'
                FROM {nameof(IDisabilityInPortalDbContext.Applications)}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM {nameof(IDisabilityInPortalDbContext.ManagementChanges)}");
        }
    }
}