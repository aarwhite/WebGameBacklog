using System;
using System.Collections.Generic;

namespace WebGameBacklog.Shared.Persistence
{
    public interface IRepository<TEntity> where TEntity :Entity
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(Guid id);

        void Add(TEntity entity);

        void Delete(TEntity entity);
    }
}
