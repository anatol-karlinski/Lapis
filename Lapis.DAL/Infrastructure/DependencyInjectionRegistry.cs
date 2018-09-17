using Lapis.DAL.Interfaces;
using Lapis.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lapis.DAL.Infrastructure
{
    public static class DependencyInjectionRegistry
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
