using DDDFirst.Domain.Interfaces.Utils;
using DDDFirst.Infrastructure.Repositories;
using DDDFirst.Infrastructure.Utils;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddMySqlApplicationDbContext(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "沒有設定連線字串哦");
            }

            services.AddDbContext<ApplicationDbContext>(optnios =>
            {
                optnios.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 31)));
            });

            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
            return services;
        }

        public static IServiceCollection AddMassTransitProducer(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("host.docker.internal", "/", h =>
                    {
                        // TODO：這裡要改成自己的帳號密碼
                        h.Username("");
                        h.Password("");
                    });
                });
            });
            return services;
        }
    }
}
