using AddressService.ClassLibrary.Models;
using AddressService.Infrastructure.Data;
using AddressService.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AddressService.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressDbContext _addressDbContext;
        public AddressRepository(AddressDbContext addressDbContext)
        {
            _addressDbContext = addressDbContext;
        }
        public async Task<Address> CreateAddress(Address address)
        {
            _addressDbContext.Addresses.Add(address);
            await _addressDbContext.SaveChangesAsync();
            return address;
        }

        public async Task<bool> DeleteAddress(Guid id)
        {
            _addressDbContext.Addresses.Remove(new Address(id));
            await _addressDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Address?> GetAddressById(Guid id)
        {
            Address? address = await _addressDbContext.Addresses.SingleOrDefaultAsync(x => x.Id == id);
            return address;
        }

        public async Task<List<Address>> GetAllAddresses()
        {
            return await _addressDbContext.Addresses.ToListAsync();
        }

        public async Task<Address> UpdateAddress(Address address)
        {
            
            _addressDbContext.Addresses.Update(address);
            await _addressDbContext.SaveChangesAsync();
            return address;
        }
    }
}
