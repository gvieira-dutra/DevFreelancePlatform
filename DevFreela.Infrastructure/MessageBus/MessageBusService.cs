﻿using DevFreela.Core.Services;
using RabbitMQ.Client;

namespace DevFreela.Infrastructure.MessageBus
{
    public class MessageBusService : IMessageBusService
    {
        // private readonly ConnectionFactory _factory;
        //public MessageBusService()
        //{
        //    _factory = new ConnectionFactory
        //    {
        //        HostName = "localhost"
        //    };
        //}

        public void Publish(string queue, byte[] message)
        {
            //using (var connection = _factory.CreateConnection())
            //{
            //    using (var channel = connection.CreateModel())
            //    {
            //        //ensure queue is created
            //        channel.QueueDeclare(
            //            queue: queue,
            //            durable: false,
            //            exclusive: false,
            //            autoDelete: false,
            //            arguments: null
            //        );

            //        //publish message
            //        channel.BasicPublish(
            //            exchange: "",
            //            routingKey: queue,
            //            basicProperties: null,
            //            body: message
            //        );

                    
            //    }
            //}
        }
    }
}
