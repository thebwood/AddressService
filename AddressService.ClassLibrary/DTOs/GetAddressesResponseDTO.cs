using AddressService.ClassLibrary.ViewModels;

namespace AddressService.ClassLibrary.DTOs
{
    public class GetAddressesResponseDTO
    {
        public GetAddressesResponseDTO()
        {
            AddressList = new List<AddressViewModel>();
        }

        public List<AddressViewModel> AddressList { get; set; }

    }
}
