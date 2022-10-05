

using Services.RabbitMQCore.Models;

namespace Services.RabbitMQCore.RabbitMQConfigurations.Interfaces
{
    public interface IRabbitMQConfigurationAppService
    {
        RabbitMQConfig GetRabbitMQConfigData();
    }
}
