using DDDFirst.Domain.Interfaces.MQModels;
using MassTransit;

namespace NotificationReceiver.Consumers
{
    public class EmailNotificationConsumerDefinition : ConsumerDefinition<EmailNotificationConsumer>
    {
        public EmailNotificationConsumerDefinition()
        {
            EndpointName = "email-notification";
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<EmailNotificationConsumer> consumerConfigurator, IRegistrationContext context)
        {
            endpointConfigurator.UseMessageRetry(r => r.Interval(5, 1000));
        }
    }
}
