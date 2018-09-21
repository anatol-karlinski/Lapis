using Lapis.Api.Helpers;
using Lapis.Api.Interfaces;
using Lapis.Api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lapis.Api.Infrastructure
{
    public static class DependencyInjectionRegistry
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtHelper, JwtHelper>();
        }
    }
}
