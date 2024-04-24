using System;
using System.Collections.Generic;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddUkSicCodesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var context = DisabilityInPortalDbContext.CreateContext())  
            {
                var ukSicCodesData = JsonConvert.DeserializeObject<IEnumerable<UkSicCode>>(UkSicCodes.Data);
                if (ukSicCodesData == null)
                    throw new InvalidOperationException($"AddUkSicCodesData deserializing error: {nameof(UkSicCode)}");

                context.UkSicCodes.AddRange(ukSicCodesData);
                context.SaveChanges();
            } 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            using (var context = DisabilityInPortalDbContext.CreateContext())
            {
                context.UkSicCodes.RemoveRange(context.UkSicCodes);
                context.SaveChanges();
            }
        }
    }
}
