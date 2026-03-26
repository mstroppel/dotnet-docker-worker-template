using Microsoft.Extensions.Options;

namespace Company.ProjectName;

public class ProjectNameWorker(
    ILogger<ProjectNameWorker> _logger,
    IOptions<ProjectNameSettings> _options) : BackgroundService
{
    private readonly ProjectNameSettings _settings = _options.Value;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("ProjectName worker started");

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Waiting for {Minutes} minutes until next sync cycle", _settings.WorkerDelay);
            await Task.Delay(TimeSpan.FromMinutes(_settings.WorkerDelay), stoppingToken);
        }

        _logger.LogInformation("ProjectName worker stopped");
    }
}
