using Microsoft.AspNetCore.Mvc.Filters;

namespace MicroserviceTemplate.Infrastructure.ActionFilters
{
    public class LoggerAttribute : ActionFilterAttribute
    {
        private readonly ILogger<LoggerAttribute> _logger;

        public LoggerAttribute(ILogger<LoggerAttribute> logger)
        {
            this._logger = logger;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _logger.LogInformation("STARTED request to {controller} | {action}", context.RouteData.Values["controller"], context.RouteData.Values["action"]);
            ActionExecutedContext result = await next();

            if (result.Exception == null)
            {
                _logger.LogInformation("FINISHED request to {controller} | {action}", context.RouteData.Values["controller"], context.RouteData.Values["action"]);
            }
            else
            {
                _logger.LogError(result.Exception, "ERROR at {controller} | {action}", context.RouteData.Values["controller"], context.RouteData.Values["action"]);
            }
        }
    }
}