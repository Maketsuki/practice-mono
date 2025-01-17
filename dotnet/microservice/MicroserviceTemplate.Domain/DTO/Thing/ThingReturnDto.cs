using MicroserviceTemplate.Domain.Entities;

namespace MicroserviceTemplate.Domain.DTO.Thing
{
    public class ThingReturnDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }
        public int Age { get; set; }

        public ThingReturnDto(ThingEntity entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.Occupation = entity.Occupation;
            this.Age = entity.Age;
        }
    }
}