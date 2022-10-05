using Services.RabbitMQCore.Models;
using Services.RabbitMQCore.RabbitMQConfigurations.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Services.RabbitMQCore.RabbitMQConfigurations
{
    public class RabbitMQConfigurationAppService : IRabbitMQConfigurationAppService
    {
        protected IConfiguration _configuration;

        public RabbitMQConfigurationAppService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public RabbitMQConfig GetRabbitMQConfigData()
        {
            throw new System.NotImplementedException();
        }

        
    }
}
