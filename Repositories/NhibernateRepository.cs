using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Repositories.Interfaces;

namespace Repositories
{
    public class NhibernateRepository : IRepository, IDisposable
    {
        protected readonly ISession _session;

        public NhibernateRepository(ISession session)
        {
            _session = session;
            _session.FlushMode = FlushMode.Auto;
        }

        public IQueryable<T> Get<T>() where T : class
        {
            return _session.Query<T>();
        }

        public void Create<T>(T item) where T : class
        {
            _session.Save(item);
        }

        public void Create<T>(IEnumerable<T> items) where T : class
        {
            foreach (T item in items)
            {
                _session.Save(item);
            }
        }

        public void Update<T>(T item) where T : class
        {
            _session.Update(item);
        }

        public void Update<T>(IEnumerable<T> items) where T : class
        {
            foreach (T item in items)
            {
                _session.Update(item);
            }
        }

        public void Delete<T>(T item) where T : class
        {
            _session.Delete(item);
        }

        public void Delete<T>(IEnumerable<T> items) where T : class
        {
            foreach (T item in items)
            {
                _session.Delete(item);
            }
        }

        public void Refresh<T>(T item) where T : class
        {
            _session.Refresh(item);
        }

        public void Flush()
        {
            _session.Flush();
        }

        public void Dispose()
        {
            _session.Dispose();
        }
    }
}