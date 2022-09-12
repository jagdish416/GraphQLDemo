using GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConnectionString(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPooledDbContextFactory<OrganizationManagementContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("OrganizationDb"));
                options.UseInternalServiceProvider(serviceProvider);
            });
            return services;
        }
    }
}
