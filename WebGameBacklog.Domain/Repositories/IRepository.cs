using System;
using System.Collections.Generic;
using WebGameBacklog.Shared.Persistence;

namespace WebGameBacklog.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity :Entity
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(Guid id);

        void Add(TEntity entity);

        void Delete(TEntity entity);
    }
}
