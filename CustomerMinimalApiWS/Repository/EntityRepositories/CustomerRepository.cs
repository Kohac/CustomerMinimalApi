using CustomerMinimalApiWS.Context;
using CustomerMinimalApiWS.Entities;

namespace CustomerMinimalApiWS.Repository.EntityRepositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private CustomerDbContext _context;
        public CustomerRepository(CustomerDbContext context)
            : base(context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Update(customer);
        }
    }
}
