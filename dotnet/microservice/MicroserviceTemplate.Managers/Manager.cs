using MicroserviceTemplate.Common.Exceptions;
using MicroserviceTemplate.Domain.Entities;
using MicroserviceTemplate.Domain.Interfaces.Repositories;

namespace MicroserviceTemplate.Managers
{
    public class Manager<T> : IManager<T> where T : Entity
    {
        private readonly IRepository<T> _repository;

        public Manager(IRepository<T> repository)
        {
            this._repository = repository;
        }

        public async Task<T> Get(Guid id)
        {
            T entity = await _repository.GetById(id);

            if (entity == null)
            {
                throw new EntityNotFoundException($"{typeof(T)} with id {id} not found.");
            }
            return entity;
        }

        public async Task Create(T entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task Update(T entity)
        {
            await _repository.Update(entity);
        }
    }
}