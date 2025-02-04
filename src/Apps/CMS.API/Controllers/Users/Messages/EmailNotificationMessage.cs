using DDDFirst.Domain.Interfaces.MQModels;

namespace NotificationReceiver.Consumers
{
    public class EmailNotificationMessage : IEmailNotificationMessage
    {
        public EmailNotificationMessage(string email, string carbonCopies, string subject, string body)
        {
            Email = email;
            CarbonCopies = carbonCopies;
            Subject = subject;
            Body = body;
        }

        public string Email { get; }
        public string CarbonCopies { get; }
        public string Subject { get; }
        public string Body { get; }
    }
}
