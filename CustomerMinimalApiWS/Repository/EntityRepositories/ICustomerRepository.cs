using CustomerMinimalApiWS.Entities;

namespace CustomerMinimalApiWS.Repository.EntityRepositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Update(Customer customer);
        void Save();
    }
}
