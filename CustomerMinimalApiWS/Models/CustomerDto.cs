namespace CustomerMinimalApiWS.Models
{
    public class CustomerDto
    {
        public string? Forename { get; set; }
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AddressDto Address { get; set; } = new();
    }
}
