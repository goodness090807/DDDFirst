using MassTransit;
using Microsoft.Extensions.Hosting;
using NotificationReceiver.Consumers;

namespace NotificationReceiver
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<EmailNotificationConsumer, EmailNotificationConsumerDefinition>();
                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host("host.docker.internal", "/", h =>
                            {
                                // TODO：這裡要改成自己的帳號密碼
                                h.Username("");
                                h.Password("");
                            });

                            cfg.ConfigureEndpoints(context);
                        });
                    });
                })
                .Build();

            await host.RunAsync();
        }
    }
}
