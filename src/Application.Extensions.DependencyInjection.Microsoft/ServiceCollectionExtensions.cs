using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions.DependencyInjection.Microsoft
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyApplication(this IServiceCollection services,
            ApplicationConfiguration configuration)
        {
            ServiceRegistrar.AddRequiredServices(services, configuration);

            return services;
        }
    }
}