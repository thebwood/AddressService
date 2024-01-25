using AddressService.Domain.Services;
using AddressService.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace AddressService.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddTransient<IAddressDomainService, AddressDomainService>();
            return services;

        }
    }
}
