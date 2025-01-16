using MicroserviceTemplate.Domain.DTO.Thing;
using MicroserviceTemplate.Domain.Entities;
using MicroserviceTemplate.Domain.Interfaces.Repositories;

namespace MicroserviceTemplate.Managers.MicroserviceTemplate
{
    public class MicroserviceTemplateManager : Manager<ThingEntity>, IMicroserviceTemplateManager
    {
        private readonly IMicroserviceTemplateRepository _microserviceTemplateRepository;

        public MicroserviceTemplateManager(IMicroserviceTemplateRepository microserviceTemplateRepository) : base(microserviceTemplateRepository)
        {
            this._microserviceTemplateRepository = microserviceTemplateRepository;
        }

        public async Task<ThingReturnDto> CreateNewThing(ThingCreateDto dto)
        {
            ThingEntity newThing = new()
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Occupation = dto.Occupation,
                Age = dto.Age
            };

            await _microserviceTemplateRepository.Create(newThing);

            return new ThingReturnDto(newThing);
        }

        public async Task<ThingReturnDto> GetThing(Guid guid)
        {
            ThingEntity thing = await _microserviceTemplateRepository.GetByGuid(guid);

            return new ThingReturnDto(thing);
        }

        public async Task DeleteThing(Guid guid)
        {
            await _microserviceTemplateRepository.Delete(guid);
        }

        public int ThisMethodIsOnlyForTestingPurposes(int x, int y)
        {
            if (y == 0)
                throw new Exception("Y was 0 so this exception was thrown");

            int something = _microserviceTemplateRepository.ThisMethodIsForTestingPurposes(x, y);
            return x * y + something;
        }
    }
}