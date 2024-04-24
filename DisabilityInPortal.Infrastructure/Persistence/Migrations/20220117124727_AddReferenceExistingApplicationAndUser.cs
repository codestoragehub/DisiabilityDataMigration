using System;
using System.Collections.Generic;
using System.Linq;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Identity;
using DisabilityInPortal.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddReferenceExistingApplicationAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE Applications 
                SET ApplicationReference = 'APP-' + ('AA' + SUBSTRING(CONVERT(varchar(36), NEWID()), 0, 9))
                WHERE ApplicationReference IS NULL;

                UPDATE [Identity].Users
                SET UserReference = 'USR-' + ('UU' + SUBSTRING(CONVERT(varchar(36), NEWID()), 0, 9))
                WHERE UserReference IS NULL;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
