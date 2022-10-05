using RabbitMQ.Client;

namespace Services.RabbitMQCore.Providers.Interfaces
{
    public interface IRabbitMQProvider
    {
        IModel RabbitMQChannel { get; }
    }
}
