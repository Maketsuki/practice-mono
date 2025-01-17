using MicroserviceTemplate.Common.Exceptions;
using MicroserviceTemplate.Domain.Entities;
using MicroserviceTemplate.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceTemplate.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected MicroserviceTemplateDbContext dbContext;

        public Repository(MicroserviceTemplateDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> GetById(Guid id)
        {
            T entity = await dbContext.Set<T>().FindAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException($"Entity of type '{typeof(T)}' was not found with id '{id}'.");
            }

            return entity;
        }

        public async Task Create(T entity)
        {
            dbContext.Set<T>().Add(entity);
            if (await SaveChanges() < 1)
            {
                throw new EntityPersistenceException("SaveChangesASync failed for new entity.");
            }
        }

        /// <summary>
        /// Saves all new entities from the list.
        /// </summary>
        /// <param name="entities">List of entities that will be created. Entities must of same type.</param>
        /// <returns></returns>
        public async Task CreateList(IList<T> entities)
        {
            if (entities != null && entities.Any())
            {
                dbContext.Set<T>().AddRange(entities);
                if (await SaveChanges() < 1)
                {
                    throw new EntityPersistenceException("SaveChangesASync failed for list of new entities.");
                }
            }
        }

        public async Task Update(T entity)
        {
            dbContext.Entry<T>(entity).State = EntityState.Modified;

            if (await SaveChanges() < 1)
            {
                throw new EntityPersistenceException("SaveChangesAsync failed to update entity.");
            }
        }

        public async Task UpdateList(IList<T> entities)
        {
            foreach (T t in entities)
            {
                dbContext.Entry<T>(t).State = EntityState.Modified;
            }
            if (await SaveChanges() < 1)
            {
                throw new EntityPersistenceException("SaveChangesAsync failed to update entity.");
            }
        }

        public async Task Delete(Guid id)
        {
            T entity = await GetById(id);
            dbContext.Set<T>().Remove(entity);
            if (await SaveChanges() < 1)
            {
                throw new EntityPersistenceException("SaveChangesAsync failed to delete entity");
            }
        }

        public async Task DeleteList(IList<T> entities)
        {
            if (entities != null && entities.Any())
            {
                foreach (T t in entities)
                {
                    dbContext.Set<T>().Remove(t);
                }
                if (await SaveChanges() < 1)
                {
                    throw new EntityPersistenceException("SaveChangesAsync failed to delete list of entities");
                }
            }
        }

        public async Task<int> SaveChanges()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (dbContext == null) return;
            dbContext.Dispose();
            dbContext = null;
        }
    }
}