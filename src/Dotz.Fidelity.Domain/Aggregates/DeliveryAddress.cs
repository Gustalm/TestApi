namespace Dotz.Fidelity.Domain.Aggregates
{
    public class DeliveryAddress
    {
        //Entidade bem básica, nao queria complicar com estados/cidade etc.
        public DeliveryAddress(Customer customer, int zipCode, string street, bool main)
        {
            Street = street;
            Main = main;
            Customer = customer;
            ZipCode = zipCode;
        }

        public int Id { get; set; }
        public string Street { get; }
        public bool Main { get; }
        public Customer Customer { get; }
        public int ZipCode { get; }
    }
}
