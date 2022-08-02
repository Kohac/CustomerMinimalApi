using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerMinimalApiWS.Entities
{
    public class Address
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [ForeignKey("Customer")]
        public long CustomerId { get; set; }
        public long HouseNumber { get; set; }
        public long OrientationNumber { get; set; }
        [MaxLength(5),MinLength(4)]
        public long PostalCode { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
    }
}
