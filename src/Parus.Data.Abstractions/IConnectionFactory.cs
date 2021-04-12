using System;
using System.Data;

namespace Parus.Data.Abstractions
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection()
        Type DbConnectionType { get; }
    }
}
