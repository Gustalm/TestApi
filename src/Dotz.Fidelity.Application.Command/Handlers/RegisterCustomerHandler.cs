using System.Threading;
using System.Threading.Tasks;
using Dotz.Fidelity.Application.Command.Commands;
using Dotz.Fidelity.Application.Command.Responses;
using Dotz.Fidelity.Domain.Aggregates;
using Dotz.Fidelity.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dotz.Fidelity.Application.Command.Handlers
{
    public class RegisterCustomerHandler : IRequestHandler<RegisterCustomerCommand, RegisterCustomerResponse>
    {
        private readonly ILogger<RegisterCustomerHandler> _logger;
        private readonly ICustomerRepository _customerRepository;
            
        public RegisterCustomerHandler(ILogger<RegisterCustomerHandler> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        public async Task<RegisterCustomerResponse> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.Cpf, request.Name, request.Email, request.Password, request.BornDate);

            var result = await _customerRepository.Register(customer);

            return new RegisterCustomerResponse(result.Id, result.Name);
        }
    }
}
