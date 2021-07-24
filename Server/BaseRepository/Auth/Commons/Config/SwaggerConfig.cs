using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Auth.Commons.Config {
    public static class SwaggerConfig {
        public static IServiceCollection ResolveSwagger (this IServiceCollection swagger) {

            //Swagger
             //Swagger
            swagger.AddSwaggerGen (c => {
                c.SwaggerDoc ("V1", new OpenApiInfo {
                    Version = "V1",
                        Title = "Autorizacao Service",
                        Description = "Microserviço responsável por fornecer as APIs de Autorização",
                        TermsOfService = new Uri ("https://example.com/terms")
                });
            });

            return swagger;
        }

        public static void UseSwaggerConfiguration (this IApplicationBuilder app, IWebHostEnvironment env) {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
             app.UseSwagger(c => {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    if(env.EnvironmentName.Equals("Development")){
                        swaggerDoc.Servers = new List<OpenApiServer> {
                            new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" }
                        };
                    }else{
                        swaggerDoc.Servers = new List<OpenApiServer> {
                            new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}/auth/" }
                        };
                    }
                });
                
            });

            //Swagger
            app.UseSwaggerUI (c => {
                if(env.EnvironmentName.Equals("Development")){
                    c.SwaggerEndpoint ("swagger/V1/swagger.json", "Autorizacao Service");
                }else{
                    c.SwaggerEndpoint ("/auth/swagger/V1/swagger.json", "Autorizacao Service");
                }
                c.RoutePrefix = string.Empty;
            });
        }
    }
}