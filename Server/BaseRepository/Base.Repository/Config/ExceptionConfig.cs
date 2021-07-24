using Base.Repository.ExceptionUtils;
using Microsoft.Extensions.DependencyInjection;

namespace Base.Repository.Config
{
    public static class ExceptionConfig {
        public static IServiceCollection ResolveExceptionHandler (this IServiceCollection services) {
            services.AddMvcCore(option => {
                option.Filters.Add (new FilterException());
            });

            return services;
        }
    }
}