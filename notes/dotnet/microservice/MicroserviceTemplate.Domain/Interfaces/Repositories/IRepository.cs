using MicroserviceTemplate.Domain.Entities;

namespace MicroserviceTemplate.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> GetById(Guid id);

        Task Create(T entity);

        /// <summary>
        /// Saves all new entities from the list.
        /// </summary>
        /// <param name="entities">List of entities that will be created. Entities must of same type.</param>
        /// <returns></returns>
        Task CreateList(IList<T> entities);

        Task Update(T entity);

        Task UpdateList(IList<T> entities);

        Task Delete(Guid id);

        Task DeleteList(IList<T> entities);

        Task<int> SaveChanges();

        void Dispose();
    }
}