using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth.Commons.Config {
    public static class ConfigSerialization {
        public static IServiceCollection JsonSerializationConfig (this IServiceCollection services) {
            services.AddMvc ()
                .AddNewtonsoftJson (options => {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());                    
                });
            return services;
        }

    }
}