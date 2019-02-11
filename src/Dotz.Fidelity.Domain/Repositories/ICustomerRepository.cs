using Dotz.Fidelity.Domain.Aggregates.Customer;
using System.Threading.Tasks;

namespace Dotz.Fidelity.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> Register(Customer customer);
        Task<Customer> RegisterAddress(Customer customer);
        Task<Customer> Get(string email);
        Task<Customer> Get(int id);

    }
}
