namespace Dotz.Fidelity.Domain.Aggregates.Product
{
    public class Product
    {
        public Product(int id, string name, int stock, int unitPrice)
        {
            Id = id;
            Name = name;
            Stock = stock;
            UnitPrice = unitPrice;
        }

        public int Id { get; }
        public string Name { get; }
        public int Stock { get; }
        public int UnitPrice { get; }
        public Category Category { get; set; }
    }
}
