using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProyectoMigracion.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMigracion.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(ApiException))
            {
                var exception = (ApiException)context.Exception;

                var validation = new
                {
                    Title = "Exception",
                    Message = exception.message,
                    StatusCode = exception.statusCode
                };

                var jsonError = new
                {
                    errors = new[] { validation }
                };

                if (exception.statusCode == 404)
                {
                    context.Result = new NotFoundObjectResult(jsonError);
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    context.ExceptionHandled = true;
                }
                else
                {
                    context.Result = new BadRequestObjectResult(jsonError);
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.ExceptionHandled = true;
                }
            }
        }
    }
}
