using System;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using FluentNHibernate.Cfg;

namespace Repositories
{
    public abstract class NHibernateConfigurator
    {
        public ISessionFactory BuildSessionFactory(string connectionName, Type t)
        {
            return GetConfiguration(connectionName, t).BuildSessionFactory();
        }

        private FluentConfiguration GetConfiguration(string connectionName, Type t)
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2005.ConnectionString(
                        c => c.FromConnectionStringWithKey(connectionName)))
                .Mappings(m => m.FluentMappings.AddFromAssembly(t.Assembly));
        }
    }
}