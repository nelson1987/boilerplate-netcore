using Stargazer.Domain.Bases;

namespace Stargazer.Infrastructure
{
    public interface IConsumer
    {
        Task<AuditableBaseEvent?> Consume(CancellationToken cancellationToken = default);
    }

    public interface IProducer
    {
        Task Send(AuditableBaseEvent @event, CancellationToken cancellationToken = default);
    }

    public interface IMailSender
    {
        Task Send(MailSettings message, CancellationToken cancellationToken = default);
    }

    public interface IHttpExternalServiceClient
    {
        Task<bool> GetTaskAsync(CancellationToken cancellationToken = default);
    }
}