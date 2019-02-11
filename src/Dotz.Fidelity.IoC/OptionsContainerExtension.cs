using Dotz.Fidelity.CrossCutting.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotz.Fidelity.IoC
{
    public static class OptionsContainerEx
    {
        public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringOption>(connectionStringOptions => connectionStringOptions.ConnectionString = configuration.GetConnectionString("ConnectionString"));
        }
    }
}
