
using Services.RabbitMQCore.Providers.Interfaces;
using RabbitMQ.Client;

namespace Services.RabbitMQCore.Providers
{
    public class RabbitMQProvider : IRabbitMQProvider
    {
        public RabbitMQProvider(IModel rabbitMQChannel)
        {
            RabbitMQChannel = rabbitMQChannel;
        }
        public IModel RabbitMQChannel { get; private set; }
    }
}
