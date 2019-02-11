using Dotz.Fidelity.Application.Command.Commands;
using Dotz.Fidelity.CrossCutting;
using Dotz.Fidelity.Domain.Aggregates.Customer;
using Dotz.Fidelity.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelity.Application.Command.Handlers
{
    public class AuthenticateCustomerHandler : IRequestHandler<AuthenticateCustomerCommand, Result<Customer>>
    {
        private readonly ILogger<RegisterCustomerHandler> _logger;
        private readonly ICustomerRepository _customerRepository;
        public AuthenticateCustomerHandler(ICustomerRepository customerRepository, ILogger<RegisterCustomerHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<Result<Customer>> Handle(AuthenticateCustomerCommand request, CancellationToken cancellationToken)
        {
            var user = await _customerRepository.Get(request.Email);
            if (user is null)
                return Result<Customer>.Fail("Usuário ou senha inválidos");



            return null;
        }
    }
}
