using Dotz.Fidelity.Application.Command.Responses;
using Dotz.Fidelity.CrossCutting;
using MediatR;
using System;

namespace Dotz.Fidelity.Application.Command.Commands
{
    public class RegisterCustomerCommand: IRequest<Result<RegisterCustomerResponse>>
    {
        public RegisterCustomerCommand()
        {
        }

        public RegisterCustomerCommand(int cpf, string name, string email, string password, DateTime bornDate)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
            BornDate = bornDate;
        }

        public int Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BornDate { get; set; }
    }
}
