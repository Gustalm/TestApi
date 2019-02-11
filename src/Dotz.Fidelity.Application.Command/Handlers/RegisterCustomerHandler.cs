using Dotz.Fidelity.Application.Command.Commands;
using Dotz.Fidelity.Application.Command.Responses;
using Dotz.Fidelity.CrossCutting;
using Dotz.Fidelity.Domain.Aggregates.Customer;
using Dotz.Fidelity.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelity.Application.Command.Handlers
{
    public class RegisterCustomerHandler : IRequestHandler<RegisterCustomerCommand, Result<RegisterCustomerResponse>>
    {
        private readonly ILogger<RegisterCustomerHandler> _logger;
        private readonly ICustomerRepository _customerRepository;
            
        public RegisterCustomerHandler(ILogger<RegisterCustomerHandler> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        public async Task<Result<RegisterCustomerResponse>> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerAlreadyTaken = await _customerRepository.Get(request.Email);
            if (customerAlreadyTaken != null)
                return Result<RegisterCustomerResponse>.Fail($"Email {request.Email} já cadastrado");

            if(string.IsNullOrEmpty(request.Password))
                return Result<RegisterCustomerResponse>.Fail($"Password vazio");

            var hashSalt = CreatePasswordHash(request.Password);
            var customer = new Customer(request.Cpf, request.Name, request.Email, request.BornDate, hashSalt.PasswordHash, hashSalt.PasswordSalt);
            var result = await _customerRepository.Register(customer);

            return Result<RegisterCustomerResponse>.Ok(new RegisterCustomerResponse(result.Id, result.Name));
        }

        private static (byte[] PasswordHash, byte[] PasswordSalt) CreatePasswordHash(string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                return (PasswordHash: hmac.Key, PasswordSalt: hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
