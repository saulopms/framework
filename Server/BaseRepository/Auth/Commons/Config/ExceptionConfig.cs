using Microsoft.Extensions.DependencyInjection;
using Base.Repository.ExceptionUtils;

namespace autorizacao_service.Commons.Config {
    public static class ExceptionConfig {
        public static IServiceCollection ResolveExceptionHandler (this IServiceCollection services) {
            services.AddMvc (option => {
                option.Filters.Add (new FilterException ());
            });
         
            return services;
        }
    }
}