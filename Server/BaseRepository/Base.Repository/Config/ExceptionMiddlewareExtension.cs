using Base.Repository.ExceptionUtils;
using Base.Repository.Utils;
using Microsoft.AspNetCore.Builder;  
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;

namespace Base.Repository.Config
{
    public static class ExceptionMiddlewareExtension  
    {  
        public static IApplicationBuilder ConfigureExceptionHandler(this IApplicationBuilder app, string env)  
        {  
            app.UseExceptionHandler(appError =>  
            {  
                appError.Run(async context =>  
                {  
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;  
                    context.Response.ContentType = "application/json";  
  
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();  
                    if (contextFeature != null)  
                    {  
                        StandartError standartError = null;
                        var exception = contextFeature.Error;
                        var status = "500";
                        if (exception.InnerException != null)
                            if (Number.isNumber (exception.InnerException.Message))
                                status = exception.InnerException.Message;

                        HttpResponse response = context.Response;
                        response.StatusCode = Convert.ToInt32 (status);

                        if (status.Equals ("500"))
                            if(env.Equals("Development")){
                                standartError = standartError = new StandartError (response.StatusCode, exception.StackTrace);
                            }else{
                                standartError = new StandartError (response.StatusCode, "Serviço indisponível no momento, caso o problema persista entre em contato com a equipe de suporte.");
                            }
                        else
                            standartError = new StandartError (response.StatusCode, exception.Message);
                        await context.Response.WriteAsync(standartError.ToString());  
                    }  
                });  
            });  
            return app;
        }  
    } 
}