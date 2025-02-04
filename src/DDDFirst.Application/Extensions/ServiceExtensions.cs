using DDDFirst.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DDDFirst.Application.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// --------------------------
        /// 實現自動註冊自己撰寫的服務
        /// --------------------------
        /// 
        /// 此實現的邏輯為，自己寫的Interface要繼承IAutoRegister介面
        /// </summary>
        public static IServiceCollection AddAutoRegisteredServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var baseServices = assembly.GetTypes()
                .Where(type => typeof(IAutoRegister).IsAssignableFrom(type))
                .Where(type => type != typeof(IAutoRegister))
                .Where(type => type.IsInterface);

            foreach (Type baseService in baseServices)
            {
                var implementType = Array.Find(assembly.GetTypes(), type => baseService.IsAssignableFrom(type) && !type.IsInterface);
                if (implementType == null)
                {
                    throw new NotImplementedException($"找不到{baseService.Name}的實作");
                }

                services.AddScoped(baseService, implementType);
            }

            return services;
        }
    }
}
