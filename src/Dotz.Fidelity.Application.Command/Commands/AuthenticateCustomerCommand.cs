using Dotz.Fidelity.CrossCutting;
using Dotz.Fidelity.Domain.Aggregates.Customer;
using MediatR;

namespace Dotz.Fidelity.Application.Command.Commands
{
    public class AuthenticateCustomerCommand: IRequest<Result<Customer>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
