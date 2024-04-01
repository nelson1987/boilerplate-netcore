namespace Stargazer.Infrastructure.Bases;
public interface IHttpExternalServiceClient
{
    Task<bool> GetTaskAsync(CancellationToken cancellationToken = default);
}

public class HttpExternalServiceClient : IHttpExternalServiceClient
{
    public Task<bool> GetTaskAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true);
        //throw new NotImplementedException();
    }
}