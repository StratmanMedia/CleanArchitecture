using Data.EFCore.Extensions.DependencyInjection.Microsoft;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions.DependencyInjection.Microsoft
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyDatabase(this IServiceCollection services,
            DataConfiguration configuration)
        {
            ServiceRegistrar.AddRequiredServices(services, configuration);

            return services;
        }
    }
}