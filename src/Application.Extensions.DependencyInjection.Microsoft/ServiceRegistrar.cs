using Application.Things.Commands;
using Application.Things.Queries;
using Domain.Contracts.Things;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions.DependencyInjection.Microsoft
{
    internal static class ServiceRegistrar
    {
        internal static void AddRequiredServices(IServiceCollection services, ApplicationConfiguration configuration)
        {
            services.AddScoped<ICreateThingCommand, CreateThingCommand>();
            services.AddScoped<IReadAllThingsQuery, ReadAllThingsQuery>();
        }
    }
}
