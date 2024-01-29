using AddressService.ClassLibrary.Models;
using AddressService.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace AddressService.API.Extensions;

public static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<AddressDbContext>();

            // Check if data already exists
            if (dbContext.Addresses.Any())
            {
                Console.WriteLine("Data already seeded.");
                return;
            }

            // Seed data
            dbContext.Addresses.AddRange(
                new Address(Guid.NewGuid(), "123 1st St", null, "Akron", "OH", "ZipCode 1"),
                new Address(Guid.NewGuid(), "234 Main St", null, "Columbus", "OH", "ZipCode 1")
            );

            dbContext.SaveChanges();
            Console.WriteLine("Data seeded successfully.");
        }
    }
}