using AddressService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AddressService.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using AddressDbContext dbContext = scope.ServiceProvider.GetRequiredService<AddressDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
