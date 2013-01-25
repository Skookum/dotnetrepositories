using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Repositories.Interfaces;

namespace Repositories
{
    public class EntityFrameworkRepository : IRepository
    {
        private readonly DbContext _dbContext;

        public EntityFrameworkRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Get<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        public void Create<T>(T item) where T : class
        {
            _dbContext.Set<T>().Add(item);
            _dbContext.SaveChanges();
        }

        public void Create<T>(IEnumerable<T> items) where T : class
        {
            foreach (T item in items)
            {
                _dbContext.Set<T>().Add(item);
            }
            _dbContext.SaveChanges();
        }

        public void Update<T>(T item) where T : class
        {
            _dbContext.Entry(item).State = System.Data.EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Update<T>(IEnumerable<T> items) where T : class
        {
            foreach (T item in items)
            {
                _dbContext.Entry(item).State = System.Data.EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }

        public void Delete<T>(T item) where T : class
        {
            _dbContext.Set<T>().Remove(item);
            _dbContext.SaveChanges();
        }

        public void Delete<T>(IEnumerable<T> items) where T : class
        {
            foreach (T item in items)
            {
                _dbContext.Set<T>().Remove(item);
            }
            _dbContext.SaveChanges();
        }

        public void Refresh<T>(T item) where T : class
        {
            _dbContext.Entry(item).Reload();
        }
    }
}
