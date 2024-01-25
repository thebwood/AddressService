namespace AddressService.ClassLibrary.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public int State { get; set; }
        public string PostalCode { get; set; }


    }
}
