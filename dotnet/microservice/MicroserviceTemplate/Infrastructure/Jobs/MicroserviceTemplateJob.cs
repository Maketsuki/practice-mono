using log4net;
using Quartz;

namespace MicroserviceTemplate.Infrastructure.Jobs
{
    public class MicroserviceTemplateJob : IJob
    {
        [NonSerialized]
        private static readonly ILog _logger = LogManager.GetLogger(typeof(MicroserviceTemplateJob));

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                _logger.Info("STARTING scheduled run of MicroserviceTemplateJob.");

                _logger.Info("FINISHED scheduled run of MicroserviceTemplateJob.");
            }
            catch (Exception ex)
            {
                _logger.Error("MicroserviceTemplateJob encountered error.", ex);
            }
            return Task.CompletedTask;
        }
    }
}