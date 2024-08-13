namespace InvestmentPlatform.DBAcces;

public class WaitForDb<T> : IHostedService where T : Context
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<WaitForDb<T>> _logger;

    public WaitForDb(IServiceProvider serviceProvider, ILogger<WaitForDb<T>> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Wait for db");
        int maxAttempts = 10;
        int delayMilliseconds = 2000; // 2 seconds delay between attempts

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<T>();
                    await context.Database.CanConnectAsync(cancellationToken);
                }

                _logger.LogInformation("Successfully connected to the database.");
                return; // Connection successful, exit the method
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Attempt {attempt} of {maxAttempts} failed to connect to the database. Retrying in {delayMilliseconds / 1000} seconds...");
                _logger.LogError(ex, "Database connection attempt failed.");
            }

            await Task.Delay(delayMilliseconds, cancellationToken); // Wait before retrying
        }

        _logger.LogError("Failed to connect to the database after multiple attempts.");
        throw new InvalidOperationException("Database connection failed after multiple attempts.");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        // No special cleanup needed on stop
        return Task.CompletedTask;
    }
}
