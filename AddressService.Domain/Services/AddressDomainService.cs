using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressService.ClassLibrary.Models;
using AddressService.Domain.Services.Interfaces;
using AddressService.Infrastructure.Repositories.Interfaces;

namespace AddressService.Domain.Services
{
    public class AddressDomainService : IAddressDomainService
    {

        private readonly IAddressRepository _addressRepository;
        public AddressDomainService(IAddressRepository addressRepository) 
        {
            _addressRepository = addressRepository;
        }

        public async Task<Address> CreateAddress(Address address)
        {

            return await _addressRepository.CreateAddress(address);
        }

        public async Task<bool> DeleteAddress(Guid id)
        {
            return await _addressRepository.DeleteAddress(id);
        }

        public async Task<Address?> GetAddressById(Guid id)
        {
            return await _addressRepository.GetAddressById(id);
        }

        public async Task<List<Address>> GetAllAddresses()
        {
            return await _addressRepository.GetAllAddresses();
        }

        public async Task<Address> UpdateAddress(Address address)
        {
            return await _addressRepository.UpdateAddress(address);
        }
    }
}
