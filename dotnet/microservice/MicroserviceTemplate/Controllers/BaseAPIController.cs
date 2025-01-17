using MicroserviceTemplate.Infrastructure.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceTemplate.Controllers
{
    [TypeFilter(typeof(LoggerAttribute))]
    public class BaseApiController : ControllerBase
    {
        public bool DoRollback { get; set; }
        public bool HasModelValidationError { get; set; }
    }
}
