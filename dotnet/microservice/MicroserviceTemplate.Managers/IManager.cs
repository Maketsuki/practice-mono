using MicroserviceTemplate.Domain.Entities;

namespace MicroserviceTemplate.Managers
{
    public interface IManager<T> where T : IEntity
    {
        Task<T> Get(Guid id);

        Task Create(T entity);

        Task Delete(Guid id);

        Task Update(T entity);
    }
}