using MicroserviceTemplate.Common.Config;
using MicroserviceTemplate.Common.Exceptions;
using MicroserviceTemplate.Domain.DTO;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace MicroserviceTemplate.Managers
{
    public class UserManagerAPIManager : IUserManagerAPIManager
    {
        private ApplicationConfig config;
        private readonly IHttpClientFactory _httpClientFactory;
        public UserManagerAPIManager(ApplicationConfig config, IHttpClientFactory httpClientFactory)
        {
            this.config = config;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetKrakendToken()
        {
            //Get ssid with userid

            Guid? ssid = null;//contextData.User.Ssid;

            // Use user's ip as host
            string host = "";//contextData.User.IpAddress;
            string application = config.UserManager.ApplicationNameInUserManagement;
            string url = GetTokenExchangeUrl();
            var client = _httpClientFactory.CreateClient();

            // Generate JWT
            string jwt = GenerateUserManagerJwt(ssid, host);

            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, url);

            httpRequest.Headers.Add("APPLICATION", application);
            httpRequest.Headers.Add("Authorization", $"{jwt}");

            var response = await client.SendAsync(httpRequest);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                return responseContent;

            }
            else
            {

                throw new NotAuthorizedException($"UserManager didn't respond with 200. Response: " + response.StatusCode);
            }

        }
        private string GetTokenExchangeUrl()
        {
            string apiGatewayHost = config.ApiGateway.ApiGatewayHost;
            string getTokenExchange = config.ApiGateway.Endpoints.GetKrakendTokenFromUserManager;

            return apiGatewayHost + getTokenExchange;
        }
        /// <summary>
        /// Generates and signs JSON Web Token that is sent to UserManager in the headers of a request for example when requesting user's AuthorizationInfo from UserManager.
        /// </summary>
        /// <param name="ssid">User's session id in UserManager</param>
        /// <param name="host">User's host (IP)</param>
        /// <returns></returns>
        private string GenerateUserManagerJwt(Guid? ssid, string host)
        {
            int expiration = config.UserManager.UserManagerTokenExpiration;
            int issuedOffsetSeconds = config.UserManager.UserManagerTokenIssuedOffsetSeconds;
            string sharedSecret = config.UserManager.UserManagerTokenSigningKey;
            string issuer = config.UserManager.ApplicationNameInUserManagement;
            string audience = config.UserManager.UserManagerTokenAudience;
            string authenticationType = "ExternalBearer";

            IList<Claim> claims = new List<Claim>();
            //// Add ssid claim
            claims.Add(new Claim("ssid", ssid.ToString()));
            //// Add host claim
            claims.Add(new Claim("host", host));

            ClaimsIdentity subject = new ClaimsIdentity(claims, authenticationType);

            DateTime issuedAt = DateTime.UtcNow.AddSeconds(-issuedOffsetSeconds);
            DateTime expires = DateTime.UtcNow.AddMinutes(expiration);

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sharedSecret));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);

            //create the jwt
            var token = (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: issuer, audience: audience,
                        subject: subject, notBefore: issuedAt, expires: expires, issuedAt: issuedAt, signingCredentials: signingCredentials);

            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
        /// <summary>
        /// Sends authorization info request to UserManager.
        /// </summary>
        /// <param name="ssid">User's session id in UserManager</param>
        /// <returns>UserManagerAuthorizationInfoDTO</returns>
        public async Task<Tuple<UserManagerAuthorizationInfoDTO, HttpStatusCode>> GetAuthorizationInfo(Guid ssid, string ipAddress)
        {
            UserManagerAuthorizationInfoDTO authorizationInfo = null;
            // Use user's ip as host
            string host = ipAddress;
            string application = config.UserManager.ApplicationNameInUserManagement;//AppSettingHelper.GetApplicationNameInUserManagerAppSetting();
            string url = config.UserManager.UserManagerHost + config.UserManager.UserManagerAuthorizationInfoUrl;

            var client = _httpClientFactory.CreateClient();
            // Generate JWT
            string jwt = GenerateUserManagerJwt(ssid, host);

            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
            httpRequest.Headers.Add("APPLICATION", application);
            httpRequest.Headers.Add("Authorization", $"{jwt}");

            var response = await client.SendAsync(httpRequest);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                authorizationInfo = (UserManagerAuthorizationInfoDTO)JsonConvert.DeserializeObject<UserManagerAuthorizationInfoDTO>(responseContent);
                return new Tuple<UserManagerAuthorizationInfoDTO, HttpStatusCode>(authorizationInfo, response.StatusCode);
            }
            else
            {
                return new Tuple<UserManagerAuthorizationInfoDTO, HttpStatusCode>(null, response.StatusCode);
            }

        }
    }
}
