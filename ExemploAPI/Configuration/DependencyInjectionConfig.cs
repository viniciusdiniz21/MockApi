using ExemploAPI.Interfaces.Repositorio;
using ExemploAPI.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace ExemploAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DbContext>();

            services.AddScoped<IAuthRepositorio, AuthRepositorio>();

            return services;
        }
    }
}
