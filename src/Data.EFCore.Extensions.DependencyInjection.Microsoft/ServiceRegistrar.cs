using Data.EFCore.Repositories;
using Domain.Contracts.Things;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.EFCore.Extensions.DependencyInjection.Microsoft
{
    internal static class ServiceRegistrar
    {
        internal static void AddRequiredServices(IServiceCollection services, DataConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(builder => builder.UseSqlServer(configuration.ConnectionString));
            services.AddScoped<IDatabaseContext>(provider => provider.GetService<DatabaseContext>());
            services.AddScoped<IThingRepository, ThingRepository>();
        }
    }
}
