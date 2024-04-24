using System;
using System.Collections.Generic;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddUnNumberCodeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var context = DisabilityInPortalDbContext.CreateContext())  
            {  
                var unNumberCodesData = JsonConvert.DeserializeObject<IEnumerable<UnNumberCode>>(UnNumberCodes.Data);
                if (unNumberCodesData == null)
                    throw new InvalidOperationException($"AddUnNumberCodeData deserializing error: {nameof(UnNumberCode)}");

                context.UnNumberCodes.AddRange(unNumberCodesData);
                context.SaveChanges();
            } 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            using (var context = DisabilityInPortalDbContext.CreateContext())
            {
                context.UnNumberCodes.RemoveRange(context.UnNumberCodes);
                context.SaveChanges();
            }
        }
    }
}