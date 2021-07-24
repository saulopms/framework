using Auth.Repositories;
using Auth.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Commons.Config {
    public static class DependencyInjectionConfig {
        public static IServiceCollection ResolveDependencies (this IServiceCollection services) {
            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            //Services
            services.AddScoped<IUserService, UserService> ();

            return services;
        }
    }
}