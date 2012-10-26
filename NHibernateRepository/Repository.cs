using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;

namespace NHibernateRepository
{
    public abstract class Repository<T> where T : class 
    {
        protected readonly ISession _session;

        protected Repository(ISession session)
        {
            _session = session;
            _session.FlushMode = FlushMode.Auto;
        }

        public bool Add(T entity)
        {
            _session.Save(entity);
            return true;
        }

        public bool Add(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                _session.Save(item);
            }
            return true;
        }

        public bool Update(T entity)
        {
            _session.Update(entity);
            return true;
        }

        public bool Delete(T entity)
        {
            _session.Delete(entity);
            return true;
        }

        public bool Delete(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                Delete(entity);
            }
            return true;
        }

        public virtual T GetById(Guid? id)
        {
            return _session.Get<T>(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _session.Query<T>();
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return GetMany(expression).SingleOrDefault();
        }

        public IQueryable<T> GetMany(Expression<Func<T, bool>> expression)
        {
            return GetAll().Where(expression).AsQueryable();
        }
    }
}