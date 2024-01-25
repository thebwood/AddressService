using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressService.ClassLibrary.Models;
using AddressService.Infrastructure.Repositories.Interfaces;

namespace AddressService.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public Task<Address> CreateAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAddress(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetAddressById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Address>> GetAllAddresses()
        {
            throw new NotImplementedException();
        }

        public Task<Address> UpdateAddress(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
