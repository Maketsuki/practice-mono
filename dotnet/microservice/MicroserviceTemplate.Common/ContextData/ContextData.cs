namespace MicroserviceTemplate.Common
{
    public class ContextData
    {
        public UserInfo User { get; set; }
        public string Hash { get; set; }
        public IList<Application> Applications { get; set; }
    }

    public class UserInfo
    {
        public string UserName { get; set; }
        public Guid UserGuid { get; set; }
        public string Name { get; set; }
        public Guid UnitGuid { get; set; }
        public Guid OrganisationGuid { get; set; }
        public string Language { get; set; }
        public Guid? Ssid { get; set; }
        public string IpAddress { get; set; }
    }

    public class Application
    {
        public string ApplicationIdentifier { get; set; }
        public string Url { get; set; }
    }
}