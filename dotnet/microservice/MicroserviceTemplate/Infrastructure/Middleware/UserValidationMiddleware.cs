using MicroserviceTemplate.Common;
using MicroserviceTemplate.Common.Config;
using MicroserviceTemplate.Domain.DTO;
using MicroserviceTemplate.Managers;
using System.Net;

namespace MicroserviceTemplate.Infrastructure.Middleware
{
    public class UserValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public UserValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ContextData contextData, IUserManagerAPIManager userManager, ILogger<UserValidationMiddleware> logger, ApplicationConfig config)
        {
            string ipAddress = GetUsersRealIp(context);
            string username = context.Request.Headers["X-Cloudia-Username"];
            string userid = context.Request.Headers["X-Cloudia-UID"];
            string ssid = context.Request.Headers["X-Cloudia-SSID"];
            string hash = context.Request.Headers["X-Cloudia-HASH"];

            string jtw = context.Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(ssid))
            {
                Tuple<UserManagerAuthorizationInfoDTO, HttpStatusCode> userInfo = await userManager.GetAuthorizationInfo(Guid.Parse(ssid), ipAddress);
                if (userInfo.Item2 == HttpStatusCode.OK && userInfo.Item1 is not null)
                {
                    contextData.User = new UserInfo
                    {
                        IpAddress = ipAddress,
                        Language = userInfo.Item1.UserDefaultLocale,
                        Name = userInfo.Item1.Name,
                        OrganisationGuid = userInfo.Item1.OrganisationUid.Value,
                        UserGuid = userInfo.Item1.UserUid.Value,
                        UnitGuid = userInfo.Item1.UnitUid.Value,
                        UserName = userInfo.Item1.Username,
                        Ssid = userInfo.Item1.Ssid
                    };

                    contextData.Hash = hash;

                    contextData.Applications = new List<Application>();

                    if (userInfo.Item1.UserApplications.Count > 0)
                    {
                        foreach (KeyValuePair<string, string> pair in userInfo.Item1.UserApplications)
                        {
                            contextData.Applications.Add(new Application() { ApplicationIdentifier = pair.Key, Url = pair.Value });
                        }
                    }
                    logger.LogInformation("User information get successfully with UUID: {userUid} returned for username {username}", userInfo.Item1.UserUid, userInfo.Item1.Username);
                    await _next(context);
                }
                else
                {
                    logger.LogError("User {username} tried to get AuthorizationInfo from user manager but usermanager answered with {userInfo}", username, (int)userInfo.Item2);
                    context.Response.Clear();
                    context.Response.StatusCode = (int)userInfo.Item2;
                    await context.Response.WriteAsync("401");
                }
            }
            else
            {
                logger.LogError("User {username} tried to get AuthorizationInfo from user manager but didn't have SSID.", username);
                context.Response.Clear();
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("403");
            }
        }

        private static string GetUsersRealIp(HttpContext context)
        {
            HttpRequest request = context.Request;

            if (string.IsNullOrEmpty(request.Headers["HTTP_X_FORWARDED_FOR"]))
            {
                return context.Connection.RemoteIpAddress.ToString();
            }

            string tmpAddress = request.Headers["HTTP_X_FORWARDED_FOR"];
            if (!tmpAddress.Contains(':')) return tmpAddress;

            int position = tmpAddress.IndexOf(":");
            if (position > 0)
            {
                tmpAddress = tmpAddress[..position];
            }
            return tmpAddress;
        }
    }
}