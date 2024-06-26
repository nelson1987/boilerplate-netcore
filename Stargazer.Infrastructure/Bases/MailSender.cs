﻿using Stargazer.Domain.Bases;

namespace Stargazer.Infrastructure.Bases;

public interface IMailSender
{
    Task Send(MailSettings message, CancellationToken cancellationToken = default);
}

public class MailSender : IMailSender
{
    public Task Send(MailSettings message, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}