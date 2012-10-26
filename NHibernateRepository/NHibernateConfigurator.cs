using FluentNHibernate.Cfg.Db;
using NHibernate;
using FluentNHibernate.Cfg;

namespace NHibernateRepository
{
    public static class NHibernateConfigurator
    {
        public static ISessionFactory BuildSessionFactory()
        {
            return GetConfiguration().BuildSessionFactory();
        }

        private static FluentConfiguration GetConfiguration()
        {
            //need to add .Mappings when you put in a real
            //project to pull in
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2005.ConnectionString(
                        c => c.FromConnectionStringWithKey("ProjectDatabaseConnectionString")));
        }
    }
}