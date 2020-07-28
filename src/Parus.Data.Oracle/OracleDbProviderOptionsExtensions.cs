using Oracle.ManagedDataAccess.Client;
using Parus.Data.Abstractions;
using System;

namespace Parus.Data.Oracle
{
    public static class OracleDbProviderOptionsExtensions
    {
        public static IConnection UseOracle(this IConnection connection, string connectionString)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException(nameof(connectionString));
            }

            connection.ConnectionFactory = new ConnectionFactory<OracleConnection>(connectionString);

            return connection;
        }
    }
}
