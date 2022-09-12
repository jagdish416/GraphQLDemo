using GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConnectionString(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services.AddDbContext<OrganizationManagementContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("OrganizationDb"));
            });
            return services;
        }
    }
}
