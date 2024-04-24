using System;
using System.Collections.Generic;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddNaicsCodesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var context = DisabilityInPortalDbContext.CreateContext())  
            {  
                var naicsCodesData = JsonConvert.DeserializeObject<IEnumerable<NaicsCode>>(NaicsCodes.Data);
                if (naicsCodesData == null)
                    throw new InvalidOperationException($"AddNaicsCodesData deserializing error: {nameof(NaicsCode)}");

                context.NaicsCodes.AddRange(naicsCodesData);
                context.SaveChanges();
            } 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            using (var context = DisabilityInPortalDbContext.CreateContext())
            {
                context.NaicsCodes.RemoveRange(context.NaicsCodes);
                context.SaveChanges();
            }
        }
    }
}
