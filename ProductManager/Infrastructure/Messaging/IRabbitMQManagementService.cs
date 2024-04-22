using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Messaging
{
    public interface IRabbitMQManagementService
    {
        public Task SendMessage<T>(T message, string queueName);
        public Task ConsumeMessage(string queueName);
    }
}
