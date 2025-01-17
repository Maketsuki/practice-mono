using MicroserviceTemplate.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceTemplate.Managers
{
    public interface IUserManagerAPIManager
    {
        Task<string> GetKrakendToken();
        Task<Tuple<UserManagerAuthorizationInfoDTO, HttpStatusCode>> GetAuthorizationInfo(Guid ssid, string ipAddress);
    }
}
