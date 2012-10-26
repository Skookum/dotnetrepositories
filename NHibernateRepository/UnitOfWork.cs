using System;
using NHibernate;
using System.Data;

namespace NHibernateRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private readonly ITransaction _transaction;

        public UnitOfWork(ISession session)
        {
            _session = session;
            _session.FlushMode = FlushMode.Auto;
            _transaction = _session.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Dispose()
        {
            _session.Close();
        }

        public void Commit()
        {
            if (!_transaction.IsActive)
            {
                throw new InvalidOperationException("No active transation");
            }
            _transaction.Commit();
        }

        public void Rollback()
        {
            if (_transaction.IsActive)
            {
                _transaction.Rollback();
            }
        }
    }
}
