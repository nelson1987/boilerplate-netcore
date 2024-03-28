using FluentResults;
using FluentValidation;
using Stargazer.Domain.Entities;

namespace Stargazer.Application.Features.Movements;
public record AddMovementCommand
{
    public decimal Valor { get; init; }
    public Status Status { get; init; }

    public static implicit operator Movement(AddMovementCommand v)
    {
        return new Movement
        {
            Valor = v.Valor,
            Status = Status.Pending
        };
    }
}

public class AddMovementCommandValidator : AbstractValidator<AddMovementCommand>
{
    public AddMovementCommandValidator()
    {
        RuleFor(x => x.Status).IsInEnum();
        RuleFor(x => x.Valor).NotEmpty();
        RuleFor(x => x.Valor).GreaterThan(0);
    }
}

public interface IAddMovementCommandHandler
{
    Task<Result> Handle(AddMovementCommand command, CancellationToken cancellationToken);
}

public class AddMovementCommandHandler : IAddMovementCommandHandler
{
    //private readonly IMovementRepositoryAsync _writeRepository;
    //private readonly IProducer _producer;
    //private readonly IHttpExternalServiceClient _httpExternalServiceClient;
    //public AddMovementCommandHandler(IMovementRepositoryAsync writeRepository,
    //    IProducer producer,
    //    IHttpExternalServiceClient httpExternalServiceClient)
    //{
    //    _writeRepository = writeRepository;
    //    _producer = producer;
    //    _httpExternalServiceClient = httpExternalServiceClient;
    //}
    public async Task<Result> Handle(AddMovementCommand command, CancellationToken cancellationToken)
    {
        //Buscar as contas a serem debitadas e creditadas
        //Persistir os dados
        //Publicar Transferencia
        /*
        var autorizado = await _httpExternalServiceClient.GetTaskAsync(cancellationToken);
        if (!autorizado) return Result.Fail("Não Autorizado.");

        Movement entity = command;
        await _writeRepository.CreateAsync(entity, cancellationToken);

        MovementEvent @event = entity;
        await _producer.Send(@event, cancellationToken);

        return Result.Ok();
        */
        throw new NotImplementedException();
    }
}