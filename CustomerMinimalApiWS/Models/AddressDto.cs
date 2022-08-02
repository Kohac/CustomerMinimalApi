namespace CustomerMinimalApiWS.Models
{
    public class AddressDto
    {
        public long HouseNumber { get; set; }
        public long OrientationNumber { get; set; }
        public long PostalCode { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
    }
}
