using MicroserviceTemplate.Common.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace MicroserviceTemplate.Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            switch (exception)
            {
                case EntityNotFoundException:
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        var something2 = new { title = "Not found", status = (int)HttpStatusCode.NotFound };
                        string json = JsonConvert.SerializeObject(something2);

                        await context.Response.WriteAsync(json);
                        break;
                    }
                case ModelNotValidException:
                case EntityNotValidException:
                    {
                        const int statusCode = (int)HttpStatusCode.BadRequest;
                        context.Response.StatusCode = statusCode;
                        var returnObject = new { title = "Bad request", status = statusCode };
                        string json = JsonConvert.SerializeObject(returnObject);

                        await context.Response.WriteAsync(json);
                        break;
                    }
                case NotAuthorizedException:
                    {
                        const int statusCode = (int)HttpStatusCode.Unauthorized;
                        context.Response.StatusCode = statusCode;
                        var returnObject = new { title = "Unauthorized", status = statusCode };
                        string json = JsonConvert.SerializeObject(returnObject);

                        await context.Response.WriteAsync(json);
                        break;
                    }
                case EntityIdentityOverlapException:
                    {
                        const int statusCode = (int)HttpStatusCode.UnprocessableEntity;
                        context.Response.StatusCode = statusCode;
                        var returnObject = new { title = "Unprocessable entity", status = statusCode };
                        string json = JsonConvert.SerializeObject(returnObject);

                        await context.Response.WriteAsync(json);
                        break;
                    }
            }
        }
    }
}