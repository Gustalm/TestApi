using System;
using System.Collections.Generic;

namespace Dotz.Fidelity.Domain.Aggregates
{
    public class Customer
    {
        public Customer(int id, int cpf, string name, string email, string password, DateTime bornDate)
            :this(cpf, name, email, password, bornDate)
        {
            Id = id;
        }

        public Customer(int cpf, string name, string email, string password, DateTime bornDate)
        {
            BornDate = bornDate;
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
        }

        public int Id { get; private set; }
        public DateTime BornDate { get; }
        public int Cpf { get; }
        public string Name { get; }
        public string Email { get; }
        public string Password { get; }

        public IList<DeliveryAddress> Addresses { get; }

        public void AddAddress(DeliveryAddress address)
        {
            if (!Addresses.Contains(address))
                Addresses.Add(address);
        }

        public void SetId(int id)
        {
            if (Id == default(int))
                Id = id;
        }
    }
}
