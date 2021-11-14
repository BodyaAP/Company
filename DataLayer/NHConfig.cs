using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Reflection;

namespace DataLayer
{
    public static class NHConfig
    {
        public static ISessionFactory Configuration(string connectionString)
        {
            var cfg = new Configuration();

            //string DataSource = "localhost\\SQLEXPRESS01";
            //string InitialCatalog = "DevPaceDB";
            //string IntegratedSecurity = "True";
            //string ConnectionTimeout = "15";
            //string Encrypt = "False";
            //string TrustServerCertificate = "False";
            //string ApplicationIntent = "ReadWrite";
            //string MultiSubnetFailover = "False";

            cfg.DataBaseIntegration(x =>
            {
                //x.ConnectionString = DataSource +
                //                     InitialCatalog + IntegratedSecurity + ConnectionTimeout + Encrypt +
                //                     TrustServerCertificate + ApplicationIntent + MultiSubnetFailover;
                x.ConnectionStringName = connectionString;
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
            });

            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            return cfg.BuildSessionFactory();
        }
    }
}
