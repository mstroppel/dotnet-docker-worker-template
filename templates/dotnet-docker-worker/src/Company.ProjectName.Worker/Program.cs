using Microsoft.Extensions.Options;
using Company.ProjectName;
using Company.ProjectName.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();

builder.Services.AddSingleton<IOptions<ProjectNameSettings>>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var settings = new ProjectNameSettings
    {
        WorkerDelay = config.GetValueOrThrow<int>("WORKER_DELAY"),
    };
    return Options.Create(settings);
});

builder.Services.AddHostedService<ProjectNameWorker>();

var host = builder.Build();
host.Run();
