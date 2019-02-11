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
    public class RegisterDeliveryAddressHandler : IRequestHandler<RegisterDeliveryAddressCommand, Result>
    {
        private readonly ILogger<RegisterCustomerHandler> _logger;
        private readonly ICustomerRepository _customerRepository;

        public RegisterDeliveryAddressHandler(ILogger<RegisterCustomerHandler> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }


        public async Task<Result> Handle(RegisterDeliveryAddressCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.Get(request.CustomerId);
            var address = new DeliveryAddress(customer, request.ZipCode, request.Street, request.MainAddress);

            customer.AddAddress(address);

            await _customerRepository.RegisterAddress(customer);

            return Result.Ok();
        }
    }
}
