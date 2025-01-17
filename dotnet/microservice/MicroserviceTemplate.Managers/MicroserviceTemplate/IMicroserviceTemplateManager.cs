using MicroserviceTemplate.Domain.DTO.Thing;
using MicroserviceTemplate.Domain.Entities;

namespace MicroserviceTemplate.Managers
{
    public interface IMicroserviceTemplateManager : IManager<ThingEntity>
    {
        Task<ThingReturnDto> CreateNewThing(ThingCreateDto dto);

        Task<ThingReturnDto> GetThing(Guid guid);

        Task DeleteThing(Guid guid);

        int ThisMethodIsOnlyForTestingPurposes(int x, int y);
    }
}