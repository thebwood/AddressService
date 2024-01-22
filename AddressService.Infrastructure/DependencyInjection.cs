using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace AddressService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
        {
            return services;
        }

    }
}
