using MicroserviceTemplate.Domain.Entities;

namespace MicroserviceTemplate.Domain.Interfaces.Repositories
{
    public interface IMicroserviceTemplateRepository : IRepository<ThingEntity>
    {
        Task<ThingEntity> GetByGuid(Guid guid);

        int ThisMethodIsForTestingPurposes(int x, int y);
    }
}