using Dotz.Fidelity.CrossCutting;
using MediatR;

namespace Dotz.Fidelity.Application.Command.Commands
{
    public class RegisterDeliveryAddressCommand : IRequest<Result>
    {
        public RegisterDeliveryAddressCommand(int id, int zipCode, string street, int number, bool mainAddress)
        {
            CustomerId = id;
            ZipCode = zipCode;
            Street = street;
            Number = number;
            MainAddress = mainAddress;
        }

        public int CustomerId { get; }
        public int ZipCode { get; }
        public string Street { get; }
        public int Number { get; }
        public bool MainAddress { get; }
    }
}
