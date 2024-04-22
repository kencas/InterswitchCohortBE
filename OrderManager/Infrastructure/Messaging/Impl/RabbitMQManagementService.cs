using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Infrastructure.Messaging.Impl
{
    
    public class RabbitMQManagementService : IRabbitMQManagementService
    {
        private IConnectionFactory factory;
        private readonly IRepositoryWrapper _repository;
        protected readonly IConfiguration Configuration;

        public RabbitMQManagementService(IRepositoryWrapper repository, IConfiguration _configuration)
        {
            Configuration = _configuration;
            _repository = repository;

            factory = new ConnectionFactory()
            {
                HostName = "localhost", // Replace with your RabbitMQ server address
                Port = 5672, // Default RabbitMQ port
                UserName = "guest", // Default username
                Password = "guest", // Default password
            };
        }
        public async Task ConsumeMessage(string queueName)
        {
            try
            {
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += (model, eventArgs) =>
                        {
                            var body = eventArgs.Body.ToArray();
                            var message = Encoding.UTF8.GetString(body);
                            Console.WriteLine(message);
                        };

                        channel.BasicConsume(queue: queueName,
                         autoAck: true,
                         consumer: consumer);
                    }
                }
                Console.WriteLine("Consume Message");
            }
            catch (Exception ex) 
            {
                
            }
           
        }

        public async Task SendMessage<T>(T message, string queueName)
        {
            
            // Create a connection
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                    var json = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(json);
                    channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
                    Console.WriteLine($"Sent: {message}");
                }
            }
        }
    }
}