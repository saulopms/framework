using Frutas.Repositories;
using Frutas.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Frutas.Commons.Config {
    public static class DependencyInjectionConfig {
        public static IServiceCollection ResolveDependencies (this IServiceCollection services) {
            //Repositories
            services.AddScoped<IFrutaRepository, FrutaRepository>();
            services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
            //Services
            services.AddScoped<IFrutaService, FrutaService> ();
            services.AddScoped<ICarrinhoService, CarrinhoService>();

            return services;
        }
    }
}