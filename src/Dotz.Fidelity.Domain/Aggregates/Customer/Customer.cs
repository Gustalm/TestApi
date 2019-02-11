using System;
using System.Collections.Generic;

namespace Dotz.Fidelity.Domain.Aggregates.Customer
{
    public class Customer
    {
        public Customer(int id, int cpf, string name, string email, DateTime bornDate, byte[] passwordHash, byte[] passwordSalt)
            :this(cpf, name, email, bornDate, passwordHash, passwordSalt)
        {
            Id = id;
        }

        public Customer(int cpf, string name, string email, DateTime bornDate, byte[] passwordHash, byte[] passwordSalt)
        {
            BirthDate = bornDate;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Cpf = cpf;
            Name = name;
            Email = email;
        }

        public int Id { get; private set; }
        public DateTime BirthDate { get; }
        public int Cpf { get; }
        public string Name { get; }
        public string Email { get; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

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
