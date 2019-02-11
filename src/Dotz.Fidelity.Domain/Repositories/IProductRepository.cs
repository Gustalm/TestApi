using Dotz.Fidelity.Domain.Aggregates.Product;
using System.Collections.Generic;

namespace Dotz.Fidelity.Domain.Repositories
{
    public interface IProductRepository
    {
        IReadOnlyList<Product> Get();

        IReadOnlyList<Product> Get(int idCategory);
    }
}
