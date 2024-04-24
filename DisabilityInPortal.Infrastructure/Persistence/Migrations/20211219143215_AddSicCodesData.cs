using System;
using System.Collections.Generic;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddSicCodesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var context = DisabilityInPortalDbContext.CreateContext())  
            {
                var sicCodesData = JsonConvert.DeserializeObject<IEnumerable<SicCode>>(SicCodes.Data);
                if (sicCodesData == null)
                    throw new InvalidOperationException($"AddSicCodesData deserializing error: {nameof(SicCode)}");

                context.SicCodes.AddRange(sicCodesData);
                context.SaveChanges();
            } 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            using (var context = DisabilityInPortalDbContext.CreateContext())
            {
                context.SicCodes.RemoveRange(context.SicCodes);
                context.SaveChanges();
            }
        }
    }
}
