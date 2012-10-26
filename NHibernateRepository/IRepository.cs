using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NHibernateRepository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(Expression<Func<T, bool>> expression);
        IQueryable<T> GetMany(Expression<Func<T, bool>> expression);
        bool Add(T entity);
        bool Add(IEnumerable<T> items);
        bool Update(T entity);
        bool Delete(T entity);
        bool Delete(IEnumerable<T> entities);
        T GetById(Guid? id);
    }
}