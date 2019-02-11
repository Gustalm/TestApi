using Dotz.Fidelity.Domain.Aggregates.Customer;

namespace Dotz.Fidelity.Domain.Services
{
    public interface ICustomerService
    {
        Customer Authenticate(string email, string password);
        //IEnumerable<User> GetAll();
        Customer GetById(int id);
        Customer Create(Customer user, string password);
        void Update(Customer user, string password = null);
    }
}
