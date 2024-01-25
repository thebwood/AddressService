using AddressService.ClassLibrary.Models;

namespace AddressService.Infrastructure.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAllAddresses();
        Task<Address> GetAddressById(Guid id);
        Task<Address> CreateAddress(Address address);
        Task<Address> UpdateAddress(Address address);
        Task<bool> DeleteAddress(Guid id);
    }
}