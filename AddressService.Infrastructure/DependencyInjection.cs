using Microsoft.EntityFrameworkCore;
using AddressService.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using AddressService.Infrastructure.Repositories.Interfaces;
using AddressService.Infrastructure.Repositories;

namespace AddressService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string? connectionString)
        {
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddDbContext<AddressDbContext>(
                options => options.UseNpgsql(connectionString ?? string.Empty));

            return services;
        }

    }
}
