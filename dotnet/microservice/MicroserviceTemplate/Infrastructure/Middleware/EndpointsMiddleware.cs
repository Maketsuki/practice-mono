using MicroserviceTemplate.Common;
using MicroserviceTemplate.Common.Config;
using MicroserviceTemplate.Managers;
using MicroserviceTemplate.Managers.ApiManager;
using MicroserviceTemplate.Managers.Shared;
using Newtonsoft.Json;

namespace MicroserviceTemplate.Infrastructure.Middleware
{
    public class EndpointsMiddleware
    {
        private readonly RequestDelegate _next;

        public EndpointsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, EndpointsContextData contextEndpoints, IApiManager apiManager, ILogger<EndpointsMiddleware> logger, ApplicationConfig config, IUserManagerAPIManager userManager)
        {
            const string headerEndpoints = "X-Cloudia-Endpoints-URL";
            string endpoints = context.Request.Headers[headerEndpoints];
            string jwt = await userManager.GetKrakendToken();
            if (!string.IsNullOrEmpty(endpoints))
            {
                ApiRequestSpec<string> requestSpec = new ApiRequestSpec<string>.Builder()
                    .Host(config.ApiGateway.ApiGatewayHost)
                    .Path(endpoints)
                    .Header("Authorization", string.Format("Bearer " + jwt))
                    .Build();

                Result<string> returnValue = await apiManager.Get(requestSpec);
                string result = returnValue.Value;

                if (!string.IsNullOrEmpty(result))
                {
                    EndpointsData epd = JsonConvert.DeserializeObject<EndpointsData>(result);
                    if (epd != null)
                    {
                        contextEndpoints.Endpoints = epd;
                        logger.LogInformation("Successfully got endpoints data from '{endpoints}'", endpoints);
                        await _next(context);
                    }
                    else
                    {
                        logger.LogError("Tried to parse response from '{endpoints}' and result was: '{result}' but couldn't deserialize EndpointsData.", endpoints, result);
                        context.Response.Clear();
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("500");
                    }
                }
                else
                {
                    logger.LogError("Tried to get endpoints from '{endpoints}' but the response was empty", endpoints);
                    context.Response.Clear();
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("500");
                }
            }
            else
            {
                logger.LogError("Tried to get endpoints from '{headerEndpoints}' but headers were empty", headerEndpoints);
                context.Response.Clear();
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("500");
                return;
            }
        }
    }
}