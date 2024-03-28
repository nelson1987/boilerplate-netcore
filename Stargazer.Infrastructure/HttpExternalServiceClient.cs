namespace Stargazer.Infrastructure;
public interface IHttpExternalServiceClient
{
    Task<bool> GetTaskAsync(CancellationToken cancellationToken = default);
}

public class HttpExternalServiceClient : IHttpExternalServiceClient
{
    public Task<bool> GetTaskAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}