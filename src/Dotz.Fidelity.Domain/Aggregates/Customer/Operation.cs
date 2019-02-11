namespace Dotz.Fidelity.Domain.Aggregates.Customer
{
    public class Operation
    {
        public Operation(Account account)
        {
            Account = account;
        }

        public Account Account { get; }
        
    }
}
