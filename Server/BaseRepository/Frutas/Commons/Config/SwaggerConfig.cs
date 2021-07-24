using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Frutas.Commons.Config {
    public static class SwaggerConfig {
        public static IServiceCollection ResolveSwagger (this IServiceCollection swagger) {

            //Swagger
             //Swagger
            swagger.AddSwaggerGen (c => {
                c.SwaggerDoc ("V1", new OpenApiInfo {
                    Version = "V1",
                        Title = "Frutas Service",
                        Description = "Microserviço responsável por fornecer as APIs de Frutas",
                        TermsOfService = new Uri ("https://example.com/terms")
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
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
                    c.SwaggerEndpoint ("swagger/V1/swagger.json", "Frutas Service");
                }else{
                    c.SwaggerEndpoint ("/auth/swagger/V1/swagger.json", "Frutas Service");
                }
                c.RoutePrefix = string.Empty;
            });
        }
    }
}