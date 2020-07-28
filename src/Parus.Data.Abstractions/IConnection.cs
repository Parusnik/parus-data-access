namespace Parus.Data.Abstractions
{
    public interface IConnection
    {
        IConnectionFactory ConnectionFactory { get; set; }
    }
}
