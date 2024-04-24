using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Contexts;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddDisabilityImpactForExistingApplications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @$"INSERT INTO {nameof(IDisabilityInPortalDbContext.DisabilityImpacts)} 
                (   {nameof(DisabilityImpact.ApplicantInformation)},                
                    {nameof(DisabilityImpact.ApplicationId)}
                )
                SELECT null, 
                     {nameof(Application.ApplicationId)}
                FROM {nameof(IDisabilityInPortalDbContext.Applications)}
                WHERE NOT EXISTS ( SELECT ApplicationId FROM 
                                    {nameof(IDisabilityInPortalDbContext.DisabilityImpacts)} 
                                    WHERE {nameof(DisabilityImpact.ApplicationId)}={nameof(Application.ApplicationId)})
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM {nameof(IDisabilityInPortalDbContext.DisabilityImpacts)}");
        }
    }
}
