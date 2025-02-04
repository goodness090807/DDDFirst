using Serilog;
using CMS.API.Extensions;
using DDDFirst.Application.Extensions;
using CMS.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddSerilogConfigure();

builder.Services.AddMySqlApplicationDbContext(builder.Configuration.GetConnectionString("MySQL")!);
builder.Services.AddUtils();
builder.Services.AddAutoRegisteredServices();
builder.Services.AddMassTransitProducer();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


// 記錄應用程式啟動訊息
Log.Information("Starting up {Application} in {Environment} environment",
    builder.Environment.ApplicationName, builder.Environment.EnvironmentName);

await app.RunAsync();

Log.Information("Shutting down {Application}", builder.Environment.ApplicationName);
await Log.CloseAndFlushAsync();
