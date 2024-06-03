using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AddressService.ClassLibrary.DTOs
{
    public class ResultDTO
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class ResultDTO<TValue> : ResultDTO
    {
        public TValue? Value { get => _value; set => _value = value;} 
        private TValue? _value;

        public ResultDTO()
        {
        }
    }
}
