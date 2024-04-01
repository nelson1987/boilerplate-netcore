using FluentResults;
using Stargazer.Domain.Features.Movements;
using Stargazer.Infrastructure.Bases;
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

        Movement entity = command.MapToEntity();
        await _writeRepository.CreateAsync(entity, cancellationToken);

        MovementCreatedEvent createdEvent = entity.MapToEvent();
        await _producer.Send(createdEvent, cancellationToken);

        return Result.Ok();
    }
}
