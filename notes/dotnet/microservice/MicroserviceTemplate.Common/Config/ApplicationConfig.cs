namespace MicroserviceTemplate.Common.Config
{
    public class ApplicationConfig
    {
        public ApiGateway ApiGateway { get; set; }
        public UserManager UserManager { get; set; }
    }

    public class ApiGateway
    {
        public string ApiGatewayHost { get; set; }
        public Endpoints Endpoints { get; set; }
    }

    public class Endpoints
    {
        public string GetUserWithEmail { get; set; }
        public string GetKrakendTokenFromUserManager { get; set; }
    }

    public class UserManager
    {
        public string UserManagerHost { get; set; }
        public int UserManagerTokenExpiration { get; set; }
        public int UserManagerTokenIssuedOffsetSeconds { get; set; }
        public string UserManagerTokenSigningKey { get; set; }
        public string UserManagerTokenAudience { get; set; }
        public string ApplicationNameInUserManagement { get; set; }
        public string UserManagerAuthorizationInfoUrl { get; set; }
        public string UserManagerLogout { get; set; }
    }
}