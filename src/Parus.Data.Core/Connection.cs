using Parus.Data.Abstractions;

namespace Parus.Data.Core
{
    public class Connection : IConnection
    {
        public IConnectionFactory ConnectionFactory { get; set; }
    }
}
