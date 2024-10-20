

namespace FoodApp.Api.VerticalSlicing.Common.RabbitMQServices
{
    public class RabbitMQConsumerService : IHostedService
    {

        IConnection _connection;
        IModel _channel;
        private readonly EmailSenderHelper _emailSenderHelper;

        public RabbitMQConsumerService(EmailSenderHelper emailSenderHelper)
        {
            _emailSenderHelper = emailSenderHelper;
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += Consumer_Received;
            _channel.BasicConsume(queue: "OrderStatus_Update_queue", autoAck: false, consumer: consumer);
            _channel.BasicConsume(queue: "InvoiceGenerated_queue", autoAck: false, consumer: consumer);
            _channel.BasicConsume(queue: "OrderCreated_queue", autoAck: false, consumer: consumer);

            return Task.CompletedTask;
        }

        private async void Consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            var messageBody = Encoding.UTF8.GetString(e.Body.ToArray());

            var routingKey = e.RoutingKey;

        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _channel.Close();
            _connection.Close();
            return Task.CompletedTask;
        }
    }
}
