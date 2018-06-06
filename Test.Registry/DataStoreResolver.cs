using Framework.Data;
using Framework.UoW;
using Framework.Core;
using Framework.Sql;
using System.Configuration;

namespace Test.Registry
{
    public class DataStoreResolver : IDataStoreResolver
    {
        public const string CMSDataStoreKey = "CMSDataStore";

        public DataStoreResolver()
        { }

        public IDataStore Resolve(string dataStoreKey)
        {
            ArgumentValidator.IsNotNullOrEmpty("dataStoreKey", dataStoreKey);

            IConnectionString connectionString = GetConnectionString(dataStoreKey);

            switch (dataStoreKey)
            {
                case DataStoreResolver.CMSDataStoreKey:
                    return new CMSDataStore(connectionString, false);
                default:
                    return null;
            }
        }

        public static IConnectionString GetConnectionString(string dataStoreKey)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[dataStoreKey].ConnectionString;
            IConnectionString connection = ConnectionStringFactory.Build(connectionString);
            return connection;
        }
    }

}
