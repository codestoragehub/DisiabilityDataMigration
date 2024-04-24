using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Contexts;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddPaymentDetailForExistingApplications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @$"INSERT INTO {nameof(IDisabilityInPortalDbContext.PaymentDetails)} 
                (
                    {nameof(PaymentDetail.ApplicationId)},
                    {nameof(PaymentDetail.IsRecertification)},
                    {nameof(PaymentDetail.IsExpeditedApplication)},
                    {nameof(PaymentDetail.NumberOfDaysToExpedite)}
                )
                SELECT {nameof(Application.ApplicationId)}, 'false', 'true', 30
                FROM {nameof(IDisabilityInPortalDbContext.Applications)}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM {nameof(IDisabilityInPortalDbContext.PaymentDetails)}");
        }
    }
}
