using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceTemplate.Domain.DTO
{
    public class UserManagerAuthorizationInfoDTO
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "validStart")]
        public DateTime? ValidStart { get; set; }

        [JsonProperty(PropertyName = "validEnd")]
        public DateTime? ValidEnd { get; set; }

        [JsonProperty(PropertyName = "userApplications")]
        public IDictionary<string, string> UserApplications { get; set; }

        [JsonProperty(PropertyName = "userDefaultLocale")]
        public string UserDefaultLocale { get; set; }
        [JsonProperty(PropertyName = "userUid")]
        public Guid? UserUid { get; set; }
        [JsonProperty(PropertyName = "organizationUid")]
        public Guid? OrganisationUid { get; set; }
        [JsonProperty(PropertyName = "unitUid")]
        public Guid? UnitUid { get; set; }
        [JsonProperty(PropertyName = "ssid")]
        public Guid? Ssid { get; set; }



        /// <summary>
        /// Is user active in UserManager.
        /// </summary>
        /// <returns>true if user is active in UserManager</returns>
        public bool IsActive()
        {
            bool isActive = this.Active;

            if (isActive)
            {
                if (this.ValidStart.HasValue)
                {
                    isActive = (this.ValidStart.Value <= DateTime.Now);
                }

                if (isActive && this.ValidEnd.HasValue)
                {
                    isActive = (this.ValidEnd.Value > DateTime.Now);
                }
            }

            return isActive;
        }
    }
}

