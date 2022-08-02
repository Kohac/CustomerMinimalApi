using System.ComponentModel.DataAnnotations;

namespace CustomerMinimalApiWS.Entities
{
    public class Customer
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [MinLength(2), MaxLength(50)]
        public string? Forename { get; set; }
        [MinLength(2), MaxLength(50)]
        public string? Surname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public Address Address { get; set; } = new Address();
    }
}
