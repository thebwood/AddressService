using AddressService.ClassLibrary.Models;

namespace AddressService.Domain.Services.Interfaces
{
    public interface IAddressDomainService
    {
        Task<Address> GetAddressById(Guid id);
        Task<List<Address>> GetAllAddresses();
        Task<Address> CreateAddress(Address address);
        Task<Address> UpdateAddress(Address address);
        Task<bool> DeleteAddress(Guid id);       
    }
}