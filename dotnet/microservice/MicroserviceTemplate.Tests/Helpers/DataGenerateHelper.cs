using MicroserviceTemplate.Domain.Entities;
using System;

namespace MicroserviceTemplate.Tests.Helpers
{
    /// <summary>
    /// Helper to generate data.
    /// </summary>

    public class DataGenerateHelper
    {
        // In most cases you need to generate test data. All data generation should be here, so there's no need to repeat the creation everywhere.
        public static ThingEntity GenerateTemplateEntity()
        {
            return new ThingEntity() { DateCreated = DateTime.Now, DateModified = DateTime.Now };
        }
    }
}