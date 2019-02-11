namespace Dotz.Fidelity.Domain.Aggregates.Customer
{
    public class DeliveryAddress
    {
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
