using NHibernate;
using System;
using System.Collections.Generic;
using WebGameBacklog.Shared;
using WebGameBacklog.Shared.Persistence;

namespace WebGameBacklog.Persistence.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public ISession Session
        {
            get
            {
                return NhUnitOfWork.Current.Session;
            }
        }

        public void Add(TEntity entity)
        {
            Session.Save(entity);
        }

        public void Delete(TEntity entity)
        {
            Session.Delete(entity);
        }

        public TEntity Get(Guid id)
        {
            return Session.Get<TEntity>(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Session.QueryOver<TEntity>().List<TEntity>();
        }
    }
}
