using AddressService.ClassLibrary.DTOs;
using AddressService.ClassLibrary.Models;
using AddressService.Domain.Services.Interfaces;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AddressService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressDomainService _addressDomainService;
        public AddressesController(IAddressDomainService addressDomainService)
        {
            _addressDomainService = addressDomainService;
        }

        [HttpGet]
        public async Task<ActionResult<GetAddressesResponseDTO>> GetAllAddresses()
        {
            GetAddressesResponseDTO response = new GetAddressesResponseDTO();
            List<Address> addresses = await _addressDomainService.GetAllAddresses();
            List<AddressDTO> addressDTOs = addresses.Select(a => new AddressDTO(a.Id, a.StreetAddress, a.StreetAddress2, a.City, a.State, a.PostalCode)).ToList();

            response.AddressList = addressDTOs;

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GetAddressResponseDTO>> GetAddressById(Guid id)
        {
            GetAddressResponseDTO response = new GetAddressResponseDTO();
            Address? address = await _addressDomainService.GetAddressById(id);
            if (address == null)
            {
                return NotFound();
            }
            AddressDTO addressDTO = new AddressDTO(address.Id, address.StreetAddress, address.StreetAddress2, address.City, address.State, address.PostalCode);
            response.Address = addressDTO;
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Result>> CreateAddress([FromBody] AddAddressRequestDTO requestDTO)
        {
            Result<AddressDTO> response = new Result<AddressDTO>();
            try
            {

                Address address = new Address(null, requestDTO.Address.StreetAddress, requestDTO.Address.StreetAddress2, requestDTO.Address.City, requestDTO.Address.State, requestDTO.Address.PostalCode);
                Address createdAddress = await _addressDomainService.CreateAddress(address);
                AddressDTO createdAddressDTO = new AddressDTO(createdAddress.Id, createdAddress.StreetAddress, createdAddress.StreetAddress2, createdAddress.City, createdAddress.State, createdAddress.PostalCode);
                
                response.StatusCode = HttpStatusCode.Created;
                response.Success = true;
                response.Value = createdAddressDTO;
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Result>> UpdateAddress(Guid id, [FromBody] UpdateAddressRequestDTO requestDTO)
        {
            Result<AddressDTO> response = new Result<AddressDTO>();
            try
            {
                Address? address = await _addressDomainService.GetAddressById(id);
                if (address == null)
                {

                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Success = false;
                    return NotFound(response);

                }

                
                address.StreetAddress = requestDTO.Address.StreetAddress;
                address.StreetAddress2 = requestDTO.Address.StreetAddress2;
                address.City = requestDTO.Address.City;
                address.State = requestDTO.Address.State;
                address.PostalCode = requestDTO.Address.PostalCode;

                Address updatedAddress = await _addressDomainService.UpdateAddress(address);
                AddressDTO updatedAddressDTO = new AddressDTO(updatedAddress.Id, updatedAddress.StreetAddress, updatedAddress.StreetAddress2, updatedAddress.City, updatedAddress.State, updatedAddress.PostalCode);

                response.StatusCode = HttpStatusCode.OK;
                response.Success = true;
                response.Value = updatedAddressDTO;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAddress(Guid id)
        {
            Address? address = await _addressDomainService.GetAddressById(id);
            if (address == null)
            {
                return NotFound();
            }
            await _addressDomainService.DeleteAddress(id);
            return Ok();
        }
    }
}
