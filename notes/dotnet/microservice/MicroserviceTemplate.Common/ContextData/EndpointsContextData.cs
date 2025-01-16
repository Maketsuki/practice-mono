namespace MicroserviceTemplate.Common
{
    public class EndpointsContextData
    {
        public EndpointsData Endpoints { get; set; }
    }

    public class EndpointsData
    {
        public string EditRights { get; set; }
        public string WriteRights { get; set; }
        public string ReadRights { get; set; }
    }
}