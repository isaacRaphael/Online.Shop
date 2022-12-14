using Services.RabbitMQCore.Providers.Interfaces;
using Services.RabbitMQCore.RabbitMQConfigurations.Interfaces;
using Services.RabbitMQCore.Services.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CartApp.Models;

namespace Floward.OnlineStore.RabbitMQCore.Services
{
    public class RabbitMQAppService : IRabbitMQAppService
    {
        private readonly IRabbitMQConfigurationAppService _rabbitMQConfigurationAppService;
        private readonly IRabbitMQProvider _rabbitMQProviders;

        public RabbitMQAppService(IRabbitMQProvider rabbitMQProvider, IRabbitMQConfigurationAppService rabbitMQConfigurationAppService)
        {
            _rabbitMQProviders = rabbitMQProvider;
            _rabbitMQConfigurationAppService = rabbitMQConfigurationAppService;
        }

        public void SendMessage<T>(List<T> messages, Product product)
        {
            if (!messages.Any()) return;

            var rabbitMQConfig = _rabbitMQConfigurationAppService.GetRabbitMQConfigData();

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(messages));
            _rabbitMQProviders.RabbitMQChannel.BasicPublish(rabbitMQConfig.Exchange, $"{product}", true, null, body);
        }

        public T ReceiveMessage<T>()
        {
            var message = "";
            var rabbitMQConfig = _rabbitMQConfigurationAppService.GetRabbitMQConfigData();            

            var consumer = new EventingBasicConsumer(_rabbitMQProviders.RabbitMQChannel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                message = Encoding.UTF8.GetString(body);

                //Process messages here. 

                if (string.IsNullOrEmpty(message))
                {
                    _rabbitMQProviders.RabbitMQChannel.BasicAck(ea.DeliveryTag, false);
                }
            };
            _rabbitMQProviders.RabbitMQChannel.BasicConsume(rabbitMQConfig.Queue, false, consumer);

            return JsonConvert.DeserializeObject<T>(message);
        }
    }
}
