using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    public static class InfrastructureDependencyInjection
    {
        public static void RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ISqlDataAccess, SqlDataAccess>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
