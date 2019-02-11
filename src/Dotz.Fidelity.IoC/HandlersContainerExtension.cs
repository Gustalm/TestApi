using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Dotz.Fidelity.Application.Command.Handlers;

namespace Dotz.Fidelity.IoC
{
    public static class HandlersContainerExtension
    {
        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AuthenticateCustomerHandler).Assembly);
        }
    }
}
