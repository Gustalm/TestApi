using System;

namespace Dotz.Fidelity.Domain.Aggregates.Customer
{
    public class Account
    {
        public Account(int id, Customer customer, DateTime modified)
        {
            Customer = customer;
            Modified = modified;
        }

        public Customer Customer { get; }
        public DateTime Modified { get; }
    }
}
