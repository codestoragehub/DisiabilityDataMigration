using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddedWorkflowHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkflowHistoryEvents",
                schema: "dbo",
                columns: table => new
                {
                    WorkflowHistoryEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldApplicationStatus = table.Column<int>(type: "int", nullable: false),
                    NewApplicationStatus = table.Column<int>(type: "int", nullable: false),
                    ApplicationStatusChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowHistoryEvents", x => x.WorkflowHistoryEventId);
                    table.ForeignKey(
                        name: "FK_WorkflowHistoryEvents_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkflowHistoryEvents_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowHistoryEvents_ApplicationId",
                schema: "dbo",
                table: "WorkflowHistoryEvents",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowHistoryEvents_ApplicationUserId",
                schema: "dbo",
                table: "WorkflowHistoryEvents",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkflowHistoryEvents",
                schema: "dbo");
        }
    }
}
