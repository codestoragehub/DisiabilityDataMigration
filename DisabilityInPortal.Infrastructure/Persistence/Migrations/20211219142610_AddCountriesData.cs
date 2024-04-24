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
    public partial class AddCountriesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var context = DisabilityInPortalDbContext.CreateContext())  
            {  
                var countriesData = JsonConvert.DeserializeObject<IEnumerable<Country>>(Countries.Data);
                if (countriesData == null)
                    throw new InvalidOperationException($"AddCountriesData deserializing error: {nameof(Country)}");

                using (var transaction = context.Database.BeginTransaction())
                {
                    context.Countries.AddRange(countriesData);
                    context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [dbo].[Countries] ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT [dbo].[Countries] OFF");
                    
                    transaction.Commit();
                }
            } 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            using (var context = DisabilityInPortalDbContext.CreateContext())
            {
                context.Countries.RemoveRange(context.Countries);
                context.SaveChanges();
            }
        }
    }
}
