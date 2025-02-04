using Serilog;
using Serilog.Sinks.Grafana.Loki;

namespace CMS.API.Extensions
{
    public static class HostExtensions
    {
        public static void AddSerilogConfigure(this IHostBuilder host)
        {
            host.UseSerilog((hostingContext, loggerConfiguration) =>
            {
                var lokiUrl = hostingContext.Configuration["LokiUrl"]!;
                loggerConfiguration
                    .ReadFrom.Configuration(hostingContext.Configuration)
                    .MinimumLevel.Debug() // 設定預設的日誌級別為 Debug
                    //.MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning) // 覆蓋 Microsoft 的日誌級別為 Warning
                    //.MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning) // 覆蓋 System 的日誌級別為 Warning
                    .Enrich.FromLogContext()
                    .Enrich.WithProperty("Application", hostingContext.HostingEnvironment.ApplicationName) // 添加全域性的屬性 Application
                    .Enrich.WithProperty("Environment", hostingContext.HostingEnvironment.EnvironmentName)
                    .WriteTo.Console()
                    .WriteTo.GrafanaLoki(lokiUrl, new List<LokiLabel>()
                    {
                        new (){ Key = "service_name", Value = hostingContext.HostingEnvironment.ApplicationName }
                    },
                    new List<string> { "Application", "Environment" },
                    null,
                    null ,
                    Serilog.Events.LogEventLevel.Information);
            });
        }
    }
}
