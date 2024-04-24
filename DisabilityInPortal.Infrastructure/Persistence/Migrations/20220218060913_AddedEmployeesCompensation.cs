using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddedEmployeesCompensation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeesCompensations",
                schema: "dbo",
                columns: table => new
                {
                    EmployeesCompensationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfFullAndPartTimeEmployees = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IsHiringAndFiring = table.Column<bool>(type: "bit", nullable: false),
                    HiringProcedures = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    FiringProcedures = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    IsHighestPaidPerson = table.Column<bool>(type: "bit", nullable: false),
                    IfNoWhyNotAndWhoIs = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SiteVisitorsComment = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    SiteVisitReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesCompensations", x => x.EmployeesCompensationId);
                    table.ForeignKey(
                        name: "FK_EmployeesCompensations_SiteVisitReviews_SiteVisitReviewId",
                        column: x => x.SiteVisitReviewId,
                        principalSchema: "dbo",
                        principalTable: "SiteVisitReviews",
                        principalColumn: "SiteVisitReviewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesCompensations_SiteVisitReviewId",
                schema: "dbo",
                table: "EmployeesCompensations",
                column: "SiteVisitReviewId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesCompensations",
                schema: "dbo");
        }
    }
}
