using System;
using System.Collections.Generic;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;

#nullable disable

namespace DisabilityInPortal.Infrastructure.Persistence.Migrations
{
    public partial class AddStatesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var context = DisabilityInPortalDbContext.CreateContext())  
            {  
                var statesData = JsonConvert.DeserializeObject<IEnumerable<State>>(States.Data);
                if (statesData == null)
                    throw new InvalidOperationException($"AddStatesData deserializing error: {nameof(State)}");
                
                using (var transaction = context.Database.BeginTransaction())
                {
                    context.States.AddRange(statesData);
                    context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [dbo].[States] ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [dbo].[States] OFF");
                    
                    transaction.Commit();
                }
            } 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            using (var context = DisabilityInPortalDbContext.CreateContext())
            {
                context.States.RemoveRange(context.States);
                context.SaveChanges();
            }
        }
    }
}
