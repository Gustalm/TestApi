using Dotz.Fidelity.Domain.Repositories;
using Dotz.Fidelity.Infra.Data.CustomerRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Dotz.Fidelity.IoC
{
    public static class RepositoriesContainerExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
