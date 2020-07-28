using Npgsql;
using Parus.Data.Abstractions;
using System;

namespace Parus.Data.PostgreSql
{
    public static class PostgreSqlDbProviderOptionsExtensions
    {
        public static IConnection UsePostgreSql(this IConnection connection, string connectionString)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException(nameof(connectionString));
            }

            connection.ConnectionFactory = new ConnectionFactory<NpgsqlConnection>(connectionString);

            return connection;
        }
    }
}
