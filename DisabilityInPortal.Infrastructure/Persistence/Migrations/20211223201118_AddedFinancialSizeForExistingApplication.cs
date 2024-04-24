using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Contexts;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddedFinancialSizeForExistingApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @$"INSERT INTO {nameof(IDisabilityInPortalDbContext.FinancialSizeInfos)} 
                (
                    {nameof(FinancialSizeInfo.ApplicationId)}, 
                    {nameof(FinancialSizeInfo.ServicesProvided)}, 
                    {nameof(FinancialSizeInfo.IndustryType)},
                    {nameof(FinancialSizeInfo.IndustryTypeOther)},
                    {nameof(FinancialSizeInfo.CurrentEmployeesNo)},
                    {nameof(FinancialSizeInfo.DocumentId)}
                )
                SELECT {nameof(Application.ApplicationId)}, 
                    null, 
                    '{(int)IndustryType.None}',
                    null,
                    0,
                    null
                FROM {nameof(IDisabilityInPortalDbContext.Applications)}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM {nameof(IDisabilityInPortalDbContext.FinancialSizeInfos)}");
        }
    }
}
