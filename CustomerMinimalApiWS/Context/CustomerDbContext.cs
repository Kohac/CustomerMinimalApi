using CustomerMinimalApiWS.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerMinimalApiWS.Context
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
