using Dotz.Fidelity.Application.Command.Responses;
using MediatR;
using System;

namespace Dotz.Fidelity.Application.Command.Commands
{
    public class RegisterCustomerCommand: IRequest<RegisterCustomerResponse>
    {
        public RegisterCustomerCommand(int cpf, string name, string email, string password, DateTime bornDate)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
            BornDate = bornDate;
        }

        public int Cpf { get; }
        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public DateTime BornDate { get; }
    }
}
