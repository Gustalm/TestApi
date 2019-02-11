using Dotz.Fidelity.Domain.SeedWorks;
using System.Linq;

namespace Dotz.Fidelity.Domain.Enums
{
    public class OperationType : Enumeration
    {
        public OperationType(int type, string description) : base(type, description) { }

        public static readonly OperationType Debit = new OperationType(1, "Debit");
        public static readonly OperationType Credit = new OperationType(1, "Credit");

        public static OperationType Get(int operationType) => GetAll<OperationType>().FirstOrDefault(x => x.Type == operationType);
    }
}
