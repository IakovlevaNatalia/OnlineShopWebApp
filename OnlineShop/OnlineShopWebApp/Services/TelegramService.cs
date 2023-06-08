﻿using System.Linq;
using OnlineShop.db;
using OnlineShop.db.Models;
using TelegramTourBot;
using Telegram.Bot.Types.Enums;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using User = OnlineShop.db.Models.User;


namespace OnlineShopWebApp.Services
{
    public class TelegramService
    {
        private readonly IChatBotApi chatBotApi;
        private readonly UserDbRepository userDbRepository;
        private readonly IOrdersRepository ordersRepository;

        private IConnection rabbitConnectionPublisher;
        private IModel rabbitChannelPublisher;

        private IConnection rabbitConnectionConsumer;
        private IModel rabbitChannelConsumer;

        public TelegramService(IChatBotApi chatBotApi, UserDbRepository userDbRepository,
            IOrdersRepository ordersRepository)
        {
            this.chatBotApi = chatBotApi;

            chatBotApi.Init();

            ordersRepository.OrderStatusUpdatedEvent += OrdersRepository_OrderStatusUpdatedEvent;

            this.userDbRepository = userDbRepository;
            this.ordersRepository = ordersRepository;

            //InitRabbit();
        }

        void InitRabbit()
        {
            ConnectionFactory factory = new ConnectionFactory();

            // "guest"/"guest" by default, limited to localhost connections
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.VirtualHost = "/";
            factory.HostName = "localhost";

            // this name will be shared by all connections instantiated by
            // this factory
            factory.ClientProvidedName = "online shop"; //"app:audit component:event-consumer";

            rabbitConnectionPublisher = factory.CreateConnection();
            rabbitConnectionConsumer = factory.CreateConnection();

            rabbitChannelPublisher = rabbitConnectionPublisher.CreateModel();
            {
                rabbitChannelPublisher.ExchangeDeclare("dev-ex-to-telegram", ExchangeType.Direct, true);
                rabbitChannelPublisher.QueueDeclare("dev-queue-to-telegram", true, false, false, null);
                rabbitChannelPublisher.QueueBind("dev-queue-to-telegram", "dev-ex-to-telegram", "", null);
            }

            rabbitChannelConsumer = rabbitConnectionConsumer.CreateModel();
            {
                rabbitChannelConsumer.ExchangeDeclare("dev-ex-to-web", ExchangeType.Direct, true);
                rabbitChannelConsumer.QueueDeclare("dev-queue-to-web", true, false, false, null);
                rabbitChannelConsumer.QueueBind("dev-queue-to-web", "dev-ex-to-web", "", null);
            }

            var consumer = new EventingBasicConsumer(rabbitChannelConsumer);

            consumer.Received += Consumer_Received;

            // this consumer tag identifies the subscription
            // when it has to be cancelled
            string consumerTag = rabbitChannelConsumer.BasicConsume("dev-queue-to-web", false, consumer);
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var json = Encoding.UTF8.GetString(e.Body.ToArray());

            var message = JsonConvert.DeserializeObject<QueueMessageModel>(json);

            MessageReceived(message);

            rabbitChannelConsumer.BasicAck(e.DeliveryTag, false);
        }

        private void OrdersRepository_OrderStatusUpdatedEvent(object sender, OrderStatusUpdatedEventArgs e)
        {
            var message = new QueueMessageModel()
            {
                ChatId = e.User.TelegramUserId!.Value,
                MessageReceive = BuildOrderUpdateStatusMessage(e)
            };

            var jsonMessage = JsonConvert.SerializeObject(message);

            var body = Encoding.UTF8.GetBytes(jsonMessage);

            rabbitChannelPublisher.BasicPublish(exchange: "dev-ex-to-telegram", routingKey: "", basicProperties: null,
                body: body);
        }

        private void MessageReceived(QueueMessageModel message)
        {
            if (message.MessageType == MessageType.Text)
            {
                var existingUser = userDbRepository.TryGetByTelegramUserId(message.UserId);

                if (existingUser != null)
                {
                    if (message.MessageReceive == "Order list")
                    {
                        var msg = BuildOrdersMessage(existingUser);
                        chatBotApi.SendKeyboard(message.ChatId, msg);
                    }
                    else if (message.MessageReceive == "Order status")
                    {
                        var msg = BuildOrderStatusMessage(existingUser);
                        chatBotApi.SendKeyboard(message.ChatId, msg);
                    }
                    else if (message.MessageReceive == "Contacts")
                    {
                        chatBotApi.SendKeyboard(message.ChatId,
                            $"Welcome to our new office!!! Phone:+12001234567");
                    }
                    else if (message.MessageReceive == "Special Offers")
                    {
                        chatBotApi.SendKeyboard(message.ChatId,
                            $"Discount 5% for all tours!!!");
                    }
                    else
                    {
                        chatBotApi.SendKeyboard(message.ChatId, "Choose action");
                    }
                }
                else
                {
                    chatBotApi.SendContactRequest(message.ChatId);
                }
            }
            else if (message.MessageType == MessageType.Contact)
            {
                var result = userDbRepository.UpdateTelegramUserId(message.Phone, message.UserId);

                if (result)
                {
                    var existingUser = userDbRepository.TryGetByTelegramUserId(message.UserId);

                    chatBotApi.SendKeyboard(message.ChatId, $"Welcome, {existingUser.FirstName}");
                }
                else
                {
                    chatBotApi.SendKeyboard(message.ChatId,
                        $"For registration click the linq");
                }
            }

        }

        public string BuildOrdersMessage(User user)
        {
            var orders = ordersRepository.TryGetByUserId(user.Id);
            if (orders.Count != 0)
            {
                var sb = new StringBuilder();
                foreach (var order in orders)
                {
                    sb.AppendLine($"Заказ #{order.Id}");
                    foreach (var item in order.Items)
                    {
                        sb.AppendLine($"{item.Product.Name} x{item.Amount} {item.Cost}");
                    }

                    sb.AppendLine($"Статус {order.Status}");
                }

                return sb.ToString();
            }
            else
            {
                return "У Вас пока нет заказов";
            }
        }

        public string BuildOrderStatusMessage(User user)
        {
            var orders = ordersRepository.TryGetByUserId(user.Id);
            if (orders.Count != 0)
            {
                var sb = new StringBuilder();
                foreach (var order in orders)
                {
                    sb.AppendLine($"Заказ #{order.Id}");
                    sb.AppendLine($"Статус {order.Status}");
                }

                return sb.ToString();
            }
            else
            {
                return "У Вас пока нет заказов";
            }
        }

        public string BuildOrderUpdateStatusMessage(OrderStatusUpdatedEventArgs e)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Статус Вашего заказа N {e.Order.Id}, {e.Order.Items.First().Product.Name} изменился с {e.OldStatus}");
            sb.AppendLine($" на {e.NewStatus}");

            return sb.ToString();

        }

    }
}

