using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Contexts;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddInitialAdditionalDocumentListForEachApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @$"INSERT INTO {nameof(IDisabilityInPortalDbContext.AdditionalDocumentLists)} 
                (
                    {nameof(AdditionalDocumentList.ApplicationId)},
                    {nameof(AuditBaseEntity.DateCreated)}                    
                )
                SELECT {nameof(Application.ApplicationId)},
                       GETUTCDATE()
                FROM {nameof(IDisabilityInPortalDbContext.Applications)}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM {nameof(IDisabilityInPortalDbContext.AdditionalDocumentLists)}");
        }
    }
}
