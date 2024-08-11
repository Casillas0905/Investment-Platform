namespace InvestmentPlatform.DBAcces;

public class WaitForDb<T> : IHostedService where T : Context
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        //is connected to db
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        //Task.CompleteTask
        throw new NotImplementedException();
    }
}