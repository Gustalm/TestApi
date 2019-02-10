namespace Dotz.Fidelity.Application.Command.Responses
{
    public class RegisterCustomerResponse
    {
        public RegisterCustomerResponse(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}
