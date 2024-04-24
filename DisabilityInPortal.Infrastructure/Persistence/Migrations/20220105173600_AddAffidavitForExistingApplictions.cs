using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Contexts;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddAffidavitForExistingApplictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @$"INSERT INTO {nameof(IDisabilityInPortalDbContext.Affidavits)} 
                (
                    {nameof(Affidavit.ApplicationId)}, 
                    {nameof(Affidavit.IsAccepted)}, 
                    {nameof(Affidavit.AcceptedDate)},
                    {nameof(Affidavit.Browser)},
                    {nameof(Affidavit.OS)},
                    {nameof(Affidavit.IP)}
                )
                SELECT {nameof(Application.ApplicationId)}, 
                    'false', 
                    null,
                    null,
                    null,
                    null
                FROM {nameof(IDisabilityInPortalDbContext.Applications)}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM {nameof(IDisabilityInPortalDbContext.Affidavits)}");
        }
    }
}
