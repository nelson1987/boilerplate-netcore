using FluentResults;
using Stargazer.Domain.Entities;
using Stargazer.Infrastructure;
using Stargazer.Infrastructure.Persistence.Repositories;
using Stargazer.Infrastructure.Producers;

namespace Stargazer.Application.Features.Movements;

public interface IAddMovementCommandHandler
{
    Task<Result> Handle(AddMovementCommand command, CancellationToken cancellationToken);
}

public class AddMovementCommandHandler : IAddMovementCommandHandler
{
    private readonly IMovementRepositoryAsync _writeRepository;
    private readonly IMovementProducerAsync _producer;
    private readonly IHttpExternalServiceClient _httpExternalServiceClient;
    public AddMovementCommandHandler(IMovementRepositoryAsync writeRepository,
        IMovementProducerAsync producer,
        IHttpExternalServiceClient httpExternalServiceClient)
    {
        _writeRepository = writeRepository;
        _producer = producer;
        _httpExternalServiceClient = httpExternalServiceClient;
    }
    public async Task<Result> Handle(AddMovementCommand command, CancellationToken cancellationToken)
    {
        //Buscar as contas a serem debitadas e creditadas
        //Persistir os dados
        //Publicar Transferencia
        var autorizado = await _httpExternalServiceClient.GetTaskAsync(cancellationToken);
        if (!autorizado) return Result.Fail("Não Autorizado.");

        Movement entity = command;
        await _writeRepository.CreateAsync(entity, cancellationToken);

        // MovementCreatedEvent createdEvent = entity;
        // //var createdEvent = new Domain.Entities.MovementCreatedEvent() { Conta = "Conta", Id = 1, Status = Domain.Entities.Status.Pending, Valor = 0.01M, LastModified = DateTime.UtcNow };
        // await _producer.Send(createdEvent, cancellationToken);

        return Result.Ok();
    }
}
