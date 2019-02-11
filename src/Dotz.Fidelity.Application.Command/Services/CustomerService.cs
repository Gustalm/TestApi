using Dotz.Fidelity.Domain.Aggregates.Customer;
using Dotz.Fidelity.Domain.Repositories;
using Dotz.Fidelity.Domain.Services;
using System;

namespace Dotz.Fidelity.Application.Command.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))

                _customerRepository.Get(email);

            throw new NotImplementedException();
        }

        public Customer Create(Customer user, string password)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer user, string password = null)
        {
            throw new NotImplementedException();
        }
    }
}
