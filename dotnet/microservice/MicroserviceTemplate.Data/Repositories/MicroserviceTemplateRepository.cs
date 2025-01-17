using MicroserviceTemplate.Domain.DTO.Thing;
using MicroserviceTemplate.Domain.Entities;
using MicroserviceTemplate.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceTemplate.Data.Repositories
{
    public class MicroserviceTemplateRepository : Repository<ThingEntity>, IMicroserviceTemplateRepository
    {
        public MicroserviceTemplateRepository(MicroserviceTemplateDbContext dbContext) : base(dbContext)
        { }

        public async Task<ThingEntity> GetByGuid(Guid guid)
        {
            IQueryable<ThingEntity> query = (from thing in dbContext.Thing where thing.Id.Equals(guid) select thing);
            return await query.SingleOrDefaultAsync();
        }

        public int ThisMethodIsForTestingPurposes(int x, int y)
        {
            return x + y;
        }
    }
}