using AddressService.ClassLibrary.ViewModels;

namespace AddressService.ClassLibrary.DTOs
{
    public class GetAddressesResponseDTO
    {
        public GetAddressesResponseDTO()
        {
            AddressList = new List<AddressDTO>();
        }

        public List<AddressDTO> AddressList { get; set; }

    }
}
