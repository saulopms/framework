using System;
using Base.Repository.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Base.Repository.ExceptionUtils;

namespace Base.Repository.ExceptionUtils {
    public class FilterException : IExceptionFilter {
        public void OnException (ExceptionContext context) {
            var exception = context.Exception;
            var status = "500";
            StandartError standartError = null;

            if (exception.InnerException != null)
                if (Number.isNumber (exception.InnerException.Message))
                    status = exception.InnerException.Message;

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = Convert.ToInt32 (status);

            if (status.Equals ("500"))
                standartError = new StandartError (response.StatusCode, "Serviço indisponível no momento, caso o problema persista entre em contato com a equipe de suporte.");
            else
                standartError = new StandartError (response.StatusCode, exception.Message);

            response.ContentType = "application/json";
            context.Result = new ObjectResult (standartError);

            Console.WriteLine (context.ExceptionDispatchInfo.SourceException.StackTrace);
            Console.WriteLine (context.Exception.StackTrace);
            Console.WriteLine (context.Exception.Message);

        }

    }
}