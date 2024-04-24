using System;
using System.Collections.Generic;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddUnspscData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var context = DisabilityInPortalDbContext.CreateContext())  
            {  
                var unspscCodesData = JsonConvert.DeserializeObject<IEnumerable<UnspscCode>>(UnspscCodes.Data);
                if (unspscCodesData == null)
                    throw new InvalidOperationException($"AddUnspscData deserializing error: {nameof(UnspscCode)}");

                context.UnspscCodes.AddRange(unspscCodesData);
                context.SaveChanges();
            } 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            using (var context = DisabilityInPortalDbContext.CreateContext())
            {
                context.UnspscCodes.RemoveRange(context.UnspscCodes);
                context.SaveChanges();
            }
        }
    }
}
