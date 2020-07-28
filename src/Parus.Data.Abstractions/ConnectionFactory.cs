using System;
using System.Data;
using System.Data.Common;

namespace Parus.Data.Abstractions
{
    public class ConnectionFactory<TConnection> : IConnectionFactory
        where TConnection : DbConnection, new()
    {
        private readonly string _connectionString;

        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Type DbConnectionType => typeof(TConnection);

        public IDbConnection CreateConnection() => new TConnection { ConnectionString = _connectionString };
    }
}
