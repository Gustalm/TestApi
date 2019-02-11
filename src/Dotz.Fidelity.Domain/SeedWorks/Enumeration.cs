using System.Collections.Generic;
using System.Reflection;

namespace Dotz.Fidelity.Domain.SeedWorks
{
    public abstract class Enumeration
    {
        public int Type { get; }
        public string Description { get; }

        protected Enumeration()
        {

        }

        protected Enumeration(int type, string description)
        {
            Type = type;
            Description = description;
        }

        public override string ToString()
        {
            return Description;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var type = typeof(T);
            var fields = type.GetTypeInfo().GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i].GetValue(null) is T locatedValue)
                {
                    yield return locatedValue;
                }
            }
        }
    }
}
