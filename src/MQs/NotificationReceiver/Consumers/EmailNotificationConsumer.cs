using DDDFirst.Domain.Interfaces.MQModels;
using MassTransit;

namespace NotificationReceiver.Consumers
{
    public class EmailNotificationConsumer : IConsumer<IEmailNotificationMessage>
    {
        public Task Consume(ConsumeContext<IEmailNotificationMessage> context)
        {
            var message = context.Message;
            // Do something with the message
            Console.WriteLine($"Email: {message.Email}");

            return Task.CompletedTask;
        }
    }
}
